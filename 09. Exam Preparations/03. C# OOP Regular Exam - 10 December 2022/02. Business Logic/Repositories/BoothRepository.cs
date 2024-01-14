using System;
using System.Collections.Generic;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Models.Booths.Contracts;

namespace ChristmasPastryShop.Repositories
{
    public class BoothRepository : IRepository<IBooth>
    {
        //Fields
        private readonly List<IBooth> booths;

        //Constructor
        public BoothRepository()
        {
            this.booths = new List<IBooth>();
        }

        //Properties
        public IReadOnlyCollection<IBooth> Models => this.booths;

        //Methods
        public void AddModel(IBooth model)
        {
            this.booths.Add(model);
        }
    }
}
