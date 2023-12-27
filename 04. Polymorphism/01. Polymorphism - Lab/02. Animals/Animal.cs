namespace Animals
{
    public class Animal
    {
        private string name;
        private string favoriteFood;

        protected Animal(string name, string favoriteFood)
        {
            this.Name = name;
            this.FavoriteFood = favoriteFood;
        }

        public string Name 
        { 
            get => name; 
            set => name = value; 
        }

        public string FavoriteFood 
        { 
            get => favoriteFood; 
            set => favoriteFood = value; 
        }

        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my favourite food is {this.FavoriteFood}";
        }

    }
}
