
using Raiding.Models.Interfaces;

namespace Raiding.Models.Heroes
{
    public abstract class BaseHero : IBaseHero
    {
        protected BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public int Power { get; private set; }
        public string Name { get; private set; }


        public abstract string CastAbility();

    }
}
