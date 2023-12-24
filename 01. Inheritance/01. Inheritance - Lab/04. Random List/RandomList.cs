namespace _04._Random_List
{
    public class RandomList : List<string>
    {
        private Random random;

        public RandomList()
        {
            random = new Random();
        }

        public Random Random { get => random; set => random = value; }

        public string RandomString()
        {
            if (Count == 0)
            {
                throw new ArgumentException("The list is empty");
            }

            int index = Random.Next(0, Count);
            string stringIndex = this[index];

            RemoveAt(index);

            return stringIndex;

        }
    }
}
