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
        //Fields
        private int boothId;
        private int capacity;
        private readonly IRepository<IDelicacy> delicacies;
        private readonly IRepository<ICocktail> cocktails;
        private double currentBill;
        private double turnover;
        private bool isReserved;

        //Constructor
        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;

            this.delicacies = new DelicacyRepository();
            this.cocktails = new CocktailRepository();
            currentBill = 0;
            turnover = 0;
            isReserved = false;
        }

        //Properties
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

        public double CurrentBill => currentBill;

        public double Turnover => turnover;

        public bool IsReserved => isReserved;

        //Methods
        public void UpdateCurrentBill(double amount)
        {
            currentBill += amount;
        }
        public void Charge()
        {
            turnover = currentBill;
            currentBill = 0;
        }

        public void ChangeStatus()
        {
            isReserved = !IsReserved;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Booth: {BoothId}");
            stringBuilder.AppendLine($"Capacity: {capacity}");
            stringBuilder.AppendLine($"Turnover: {turnover:f2}");
            stringBuilder.AppendLine($"-Cocktail menu:");

            foreach (var cocktail in cocktails.Models)
            {
                stringBuilder.AppendLine(cocktail.ToString());
            }
            stringBuilder.AppendLine($"-Delicacy menu:");

            foreach (var delicacy in delicacies.Models)
            {
                stringBuilder.AppendLine(delicacy.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }

    }
}
