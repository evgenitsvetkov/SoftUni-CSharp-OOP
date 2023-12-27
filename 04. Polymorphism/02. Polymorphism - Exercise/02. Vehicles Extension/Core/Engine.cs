using Vehicles.Core.Interfaces;
using Vehicles.Factories.Interfaces;
using Vehicles.IO;
using Vehicles.IO.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;
using System.Collections.Generic;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IVehicleFactory vehicleFactory;
       
        private ICollection<IVehicles> vehicles;

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;

            vehicles = new List<IVehicles>();
        }

        public void Run()
        {
            IVehicles car = CreateVehicle();
            IVehicles truck = CreateVehicle();
            IVehicles bus = CreateVehicle();

            vehicles.Add(car);
            vehicles.Add(truck);
            vehicles.Add(bus);

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                try
                {
                    ProcessCommand();
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            foreach (var vehicle in vehicles)
            {
               Console.WriteLine(vehicle);
            }

        }

        private IVehicles CreateVehicle()
        {
            string[] tokens = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IVehicles vehicle = vehicleFactory.Create(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]), double.Parse(tokens[3]));

            return vehicle;
        }

        private void ProcessCommand()
        {
            string[] commandTokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = commandTokens[0];
            string vehicleTypeName = commandTokens[1];

            IVehicles vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleTypeName);

            if (vehicle is null)
            {
                throw new ArgumentException("Invalid vehicle");
            }

            if (command == "Drive")
            {
                double distance = double.Parse(commandTokens[2]);
                writer.WriteLine(vehicle.Drive(distance));
            }
            else if (command == "Refuel")
            {
                double amount = double.Parse(commandTokens[2]);
                vehicle.Refuel(amount);
            }
            else if (command == "DriveEmpty")
            {
                double distance = double.Parse(commandTokens[2]);
                writer.WriteLine(vehicle.Drive(distance, false));
            }

            
        }
    }
}
