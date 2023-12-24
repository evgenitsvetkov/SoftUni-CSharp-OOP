namespace Animals;

public class StartUp
{
    static void Main(string[] args)
    {
        string animalType;

        while ((animalType = Console.ReadLine()) != "Beast!")
        {
            string[] tokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            try
            {
                switch (animalType)
                {
                    case "Dog":
                        Dog dog = new(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        Console.WriteLine(animalType);
                        Console.WriteLine(dog.ToString());
                        break;
                    case "Frog":
                        Frog frog = new(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        Console.WriteLine(animalType);
                        Console.WriteLine(frog.ToString());
                        break;
                    case "Cat":
                        Cat cat = new(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        Console.WriteLine(animalType);
                        Console.WriteLine(cat.ToString());
                        break;
                    case "Tomcat":
                        Tomcat tomcat = new(tokens[0], int.Parse(tokens[1]));
                        Console.WriteLine(animalType);
                        Console.WriteLine(tomcat.ToString());
                        break;
                    case "Kitten":
                        Kitten kitten = new(tokens[0], int.Parse(tokens[1]));
                        Console.WriteLine(animalType);
                        Console.WriteLine(kitten.ToString());
                        break;
                }
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }


        }
    }
}