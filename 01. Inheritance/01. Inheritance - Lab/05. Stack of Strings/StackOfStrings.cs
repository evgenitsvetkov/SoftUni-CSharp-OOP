namespace _05._Stack_of_Strings
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (this.Count > 0)
            {
                return false;
            }
            return true;
        }

        public Stack<string> AddRange(IEnumerable<string> range)
        {
            foreach (var item in range)
            {
                this.Push(item);
            }
            return this;
        }
    }
}
