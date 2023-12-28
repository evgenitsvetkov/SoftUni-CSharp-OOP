
//Input
string[] elements = Console.ReadLine().Split();

//ACTION
int sum = 0;

foreach (string value in elements)
{
    try
    {
        int currentNumber = int.Parse(value);

        sum += currentNumber;
    }
    catch (FormatException)
    {
        Console.WriteLine($"The element '{value}' is in wrong format!");
    }
    catch (OverflowException)
    {
        Console.WriteLine($"The element '{value}' is out of range!");
    }
    finally
    {
        Console.WriteLine($"Element '{value}' processed - current sum: {sum}");
    }
}

Console.WriteLine($"The total sum of all integers is: {sum}");