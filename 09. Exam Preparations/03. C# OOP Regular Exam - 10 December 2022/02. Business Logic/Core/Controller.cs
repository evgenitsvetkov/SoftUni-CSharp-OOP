using System;
using System.Linq;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Utilities.Messages;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {

        //Fields
        private readonly BoothRepository booths;

        //Constructor
        public Controller()
        {
            booths = new BoothRepository();
        }

        //Methods
        public string AddBooth(int capacity)
        {
            Booth booth = new Booth(booths.Models.Count + 1, capacity);

            booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, booth.BoothId, booth.Capacity);
        }
        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != nameof(Gingerbread) && delicacyTypeName != nameof(Stolen))
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            if (this.booths.Models.Any(b => b.DelicacyMenu.Models.Any(dm => dm.Name == delicacyName)))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            IDelicacy delicacy;

            if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else
            {
                delicacy = new Stolen(delicacyName);
            }

            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            booth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName != nameof(Hibernation) && cocktailTypeName != nameof(MulledWine))
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            if (this.booths.Models.Any(b => b.CocktailMenu.Models.Any(cm => cm.Name == cocktailName && cm.Size == size)))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            ICocktail cocktail;

            if (cocktailTypeName == nameof(Hibernation))
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else
            {
                cocktail = new MulledWine(cocktailName, size);
            }

            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            booth.CocktailMenu.AddModel(cocktail);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
            var availableBooths = this.booths.Models
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault();
                        
            if (availableBooths == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            availableBooths.ChangeStatus();

            return string.Format(OutputMessages.BoothReservedSuccessfully, availableBooths.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string[] splitOrder = order.Split("/", StringSplitOptions.RemoveEmptyEntries);

            string itemTypeName = splitOrder[0];
            string itemName = splitOrder[1];
            int countOfTheOrderedPieces = int.Parse(splitOrder[2]);
            
            //Finding Booth
            Booth currentBooth = (Booth)booths.Models.First(b => b.BoothId == boothId);

            //Finding Item
            //Cocktail
            if (itemTypeName == "Hibernation" || itemTypeName == "MulledWine")
            {
                string size = splitOrder[3];

                if (!currentBooth.CocktailMenu.Models.Any(c => c.Name == itemName))
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }

                var desiredCocktail = currentBooth.CocktailMenu.Models
                    .FirstOrDefault(c => c.GetType().Name == itemTypeName && c.Name == itemName && c.Size == size);

                if (desiredCocktail == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, itemName);
                }

                currentBooth.UpdateCurrentBill(desiredCocktail.Price * countOfTheOrderedPieces);

                return string.Format(OutputMessages.SuccessfullyOrdered, currentBooth.BoothId, countOfTheOrderedPieces, itemName);
            }

            //Delicacy
            else if (itemTypeName == "Gingerbread" || itemTypeName == "Stolen")
            {
                if (!currentBooth.DelicacyMenu.Models.Any(d => d.Name == itemName))
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }

                var desiredDelicacy = currentBooth.DelicacyMenu.Models
                    .FirstOrDefault(d => d.GetType().Name == itemTypeName && d.Name == itemName);

                if (desiredDelicacy == null)
                {
                    return string.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                }

                currentBooth.UpdateCurrentBill(desiredDelicacy.Price * countOfTheOrderedPieces);

                return string.Format(OutputMessages.SuccessfullyOrdered, currentBooth.BoothId, countOfTheOrderedPieces, itemName);
            }
            else
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

        }
        public string LeaveBooth(int boothId)
        {
            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {booth.CurrentBill:f2} lv");

            booth.Charge();
            booth.ChangeStatus();

            sb.AppendLine($"Booth {boothId} is now available!");

            return sb.ToString().TrimEnd();
        }

        public string BoothReport(int boothId)
        {
            Booth currentBooth = (Booth)booths.Models.First(b => b.BoothId == boothId);

            return currentBooth.ToString();
        }



    }
}
