
using NeedForSpeed;

public class StartUp
{
    public static void Main(string[] args)
    {
        Car car = new(100, 100);
        car.Drive(10);
        System.Console.WriteLine(car.Fuel);

        SportCar Sportcar = new(100, 100);
        Sportcar.Drive(6);
        System.Console.WriteLine(Sportcar.Fuel);

    }


}