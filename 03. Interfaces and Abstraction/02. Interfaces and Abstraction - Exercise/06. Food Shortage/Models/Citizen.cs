
using BorderControl.Models.Interfaces;

namespace BorderControl.Models
{
    public class Citizen : IIds, IBirthable, IBuyer, INameable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public int Food { get; private set; }


        public void BuyFood()
        {
            Food += 10;
        }
    }
}
