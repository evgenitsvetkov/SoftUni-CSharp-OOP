using System.Collections.Generic;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        //Fields
        private readonly List<IDelicacy> delicacies;

        //Constructor
        public DelicacyRepository()
        {
            this.delicacies = new List<IDelicacy>();
        }

        //Properties
        public IReadOnlyCollection<IDelicacy> Models => this.delicacies;

        //Methods
        public void AddModel(IDelicacy model)
        {
            delicacies.Add(model);
        }
    }
}
