using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        public readonly List<IVehicle> vehicles;

        public VehicleRepository()
        {
            this.vehicles = new List<IVehicle>();
        }

        public void AddModel(IVehicle model)
        {
            this.vehicles.Add(model);
        }

        public IVehicle FindById(string identifier)
        {
            var vehicle = vehicles.FirstOrDefault(x => x.LicensePlateNumber == identifier);

            return vehicle;
        }

        public IReadOnlyCollection<IVehicle> GetAll()
        {
            return this.vehicles;
        }

        public bool RemoveById(string identifier)
        {
            var vehicle = this.FindById(identifier);

            return this.vehicles.Remove(vehicle);
        }
    }
}
