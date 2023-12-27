namespace Shapes
{
    public class Rectangle : Shape
    {
        private int x;
        private int y;

        public Rectangle(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get => x; 
            private set => x = value; 
        }
        public int Y 
        {
            get => y;
            private set => y = value; 
        }

        public override double CalculateArea()
        {
            return this.X * this.Y;
        }

        public override double CalculatePerimeter()
        {
            return (this.X * 2) + (this.Y * 2);
        }

        
    }
}
