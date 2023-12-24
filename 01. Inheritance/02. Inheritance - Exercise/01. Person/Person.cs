using System.Text;

namespace _01._Person
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get => name; 
            set
            {
                name = value;
            }
        }
        public int Age
        {
            get => age; 
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid age");
                }
                age = value;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}", this.Name, this.Age));
            
            return stringBuilder.ToString().TrimEnd();      
        }
    }
}
