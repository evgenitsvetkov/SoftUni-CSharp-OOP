
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public abstract class Mammal : Animal, IAnimal
    {
        protected Mammal(string name, double weight, string livingRegion)
            : base(name, weight)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }

    }
}
