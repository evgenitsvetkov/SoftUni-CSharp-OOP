
namespace Raiding.Models.Heroes
{
    public class Warrior : BaseHero
    {
        private const int DefaultPower = 100;
        public Warrior(string name)
            : base(name, DefaultPower)
        {
        }

        public override string CastAbility()
             => $"{this.GetType().Name} - {Name} hit for {Power} damage";
    }
}
