namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            File music = new Music("Artist", "Album", 2, 20);
            File picture = new Picture("Car", 5, 10);

            StreamProgressInfo streamProgressInfo = new StreamProgressInfo(picture);
            streamProgressInfo.CalculateCurrentPercent();
        }
    }
}
