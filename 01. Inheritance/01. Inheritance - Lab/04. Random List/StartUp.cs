using _04._Random_List;

namespace CustomRandomList
{
    public class StartUp 
    {
       static void Main()
        {
            RandomList randomList = new RandomList();
            randomList.Add("Apple");
            randomList.Add("Banana");
            randomList.Add("Cherry");

            Console.WriteLine("Random element: " + randomList.RandomString());

            Console.ReadLine();
        }
    }

}