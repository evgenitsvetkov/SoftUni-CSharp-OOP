using System;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int boothId;
        private int capacity;
        private readonly IRepository<IDelicacy> delicacies;
        private readonly IRepository<ICocktail> cocktails;

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;

            this.delicacies = new DelicacyRepository();
            this.cocktails = new CocktailRepository();
            this.CurrentBill = 0;
            this.Turnover = 0;
            this.IsReserved = false;
        }

        public int BoothId { get => boothId; private set => boothId = value; }

        public int Capacity
        {
            get => capacity; 
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }

                capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu => this.delicacies;

        public IRepository<ICocktail> CocktailMenu => this.cocktails;

        public double CurrentBill { get; private set; }

        public double Turnover { get; private set; }

        public bool IsReserved { get; private set; }

        public void UpdateCurrentBill(double amount)
        {
            this.CurrentBill += amount;
        }
        public void Charge()
        {
            this.Turnover = this.CurrentBill;
            this.CurrentBill = 0;
        }

        public void ChangeStatus()
        {
            this.IsReserved = !IsReserved;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Booth: {BoothId}");
            stringBuilder.AppendLine($"Capacity: {Capacity}");
            stringBuilder.AppendLine($"Turnover: {Turnover:f2}");
            stringBuilder.AppendLine($"-Cocktail menu:");

            foreach (var cocktail in CocktailMenu.Models)
            {
                stringBuilder.AppendLine($"--{cocktail.ToString()}");
            }
            stringBuilder.AppendLine($"-Delicacy menu:");

            foreach (var delicacy in DelicacyMenu.Models)
            {
                stringBuilder.AppendLine($"--{delicacy.ToString()}");
            }

            return stringBuilder.ToString().TrimEnd();
        }

    }
}
