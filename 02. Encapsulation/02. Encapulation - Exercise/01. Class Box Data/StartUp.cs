//INPUT
using ClassBoxData;

try
{
    double length = double.Parse(Console.ReadLine());
    double width = double.Parse(Console.ReadLine());
    double height = double.Parse(Console.ReadLine());

    Box box = new Box(length, width, height);

    Console.WriteLine($"Surface Area - {box.Surface():f2}");
    Console.WriteLine($"Lateral Surface Area - {box.LateralSurface():f2}");
    Console.WriteLine($"Volume - {box.Volume():f2}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}