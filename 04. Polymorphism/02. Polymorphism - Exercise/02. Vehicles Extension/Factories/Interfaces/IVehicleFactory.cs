using VehiclesExtension.Models.Interfaces;

namespace VehiclesExtension.Factories.Interfaces
{
    public interface IVehicleFactory
    {
        IVehicles Create(string type, double fuelQuantity, double fuelConsumption, double tankCapacity);
    }
}
