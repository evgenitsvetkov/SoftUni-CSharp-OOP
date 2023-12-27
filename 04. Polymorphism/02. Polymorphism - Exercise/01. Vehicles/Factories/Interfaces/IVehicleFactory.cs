
using Vehicles.Models.Interfaces;

namespace Vehicles.Factories.Interfaces
{
    public interface IVehicleFactory
    {
        IVehicles Create(string type, double fuelQuantity, double fuelConsumption);
    }
}
