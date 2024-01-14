using System;
using System.Collections.Generic;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Models.Booths.Contracts;

namespace ChristmasPastryShop.Repositories
{
    public class BoothRepository : IRepository<IBooth>
    {
        private readonly List<IBooth> booths;

        public BoothRepository()
        {
            this.booths = new List<IBooth>();
        }

        public IReadOnlyCollection<IBooth> Models => this.booths;

        public void AddModel(IBooth model)
        {
            this.booths.Add(model);
        }
    }
}
