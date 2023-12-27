
namespace Vehicles.Models.Interfaces
{
    public interface IVehicles
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        string Drive(double distance);

        void Refuel(double amount);
    }
}
