
namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int heigh)
        {
            Width = width;
            Heigh = heigh;
        }

        public int Width { get; set; }

        public int Heigh { get; set; }

        public void Draw()
        {
            DrawLine(this.width, '*', '*');

            for (int i = 1; i < this.height - 1; ++i)
            {
                DrawLine(this.width, '*', ' ');
            }
            DrawLine(this.width, '*', '*');
        }

        private void DrawLine(int width, char end, char mid)
        {
            Console.WriteLine(end);
            for (int i = 1; i < width - 1; ++i)
            {
                Console.WriteLine(mid);
            }
            Console.WriteLine(end);
        }
    }
}
