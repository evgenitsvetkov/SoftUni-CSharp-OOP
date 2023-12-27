
namespace VehiclesExtension.Models.Interfaces
{
    public interface IVehicles
    {
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        string Drive(double distance, bool isIncreasedConsumption = true);

        void Refuel(double amount);
    }
}
