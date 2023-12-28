using System.Security.Cryptography.X509Certificates;

//Input
int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int countOfExeptions = 0;

//Action
while (countOfExeptions < 3)
{
    string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string commandType = command[0];

    try
    {
        //Replace Command

        if (commandType == "Replace")
        {
            int firstIndex = int.Parse(command[1]);
            int element = int.Parse(command[2]);

            numbers[firstIndex] = element;
        }

        //Show Command
        else if (commandType == "Show")
        {
            int firstIndex = int.Parse(command[1]);

            Console.WriteLine(numbers[firstIndex]);
        }

        //Print Command
        else if (commandType == "Print")
        {
            int firstIndex = int.Parse(command[1]);
            int secondIndex = int.Parse(command[2]);

            if (firstIndex < 0 || firstIndex >= numbers.Length
                || secondIndex < 0 || secondIndex >= numbers.Length)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = firstIndex; i <= secondIndex - 1; i++)
            {
                Console.Write(numbers[i] + ", ");
            }

            Console.WriteLine(numbers[secondIndex]);
        }
    }
    catch (IndexOutOfRangeException)
    {
        Console.WriteLine("The index does not exist!");
        countOfExeptions++;
    }
    catch (FormatException)
    {
        Console.WriteLine("The variable is not in the correct format!");
        countOfExeptions++;
    }
}
Console.WriteLine(string.Join(", ", numbers));