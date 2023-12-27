
using BorderControl.Models.Interfaces;

namespace BorderControl.Models
{
    public class Person : IIds, IBirthable
    {
        

        public Person(string id, string name, int age, string birthdate)
        {
            Id = id;
            Name = name;
            Age = age;
            Birthdate = birthdate;
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Birthdate { get; private set; }
    }
}
