using System;
using System.Collections.Generic;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        //Fields
        private readonly List<ICocktail> cocktails;

        //Constructor
        public CocktailRepository()
        {
            this.cocktails = new List<ICocktail>();
        }

        //Properties
        public IReadOnlyCollection<ICocktail> Models => this.cocktails;

        //Methods
        public void AddModel(ICocktail model)
        {
            cocktails.Add(model);
        }
    }
}
