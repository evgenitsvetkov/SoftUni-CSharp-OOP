using System;
using System.Collections.Generic;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        private readonly List<ICocktail> cocktails;

        public CocktailRepository()
        {
            this.cocktails = new List<ICocktail>();
        }

        public IReadOnlyCollection<ICocktail> Models => this.cocktails;

        public void AddModel(ICocktail model)
        {
            cocktails.Add(model);
        }
    }
}
