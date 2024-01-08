using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Linq;
using System.Reflection;

namespace VehicleGarage.Tests
{
    public class GarageTests
    {
        [TestCase(10)]
        [TestCase(1)]
        public void ConstructorShouldInitializeAllValues(int capacity)
        {
            Garage garage = new Garage(capacity);

            Assert.AreEqual(garage.Capacity, capacity);
            Assert.IsNotNull(garage.Vehicles);
        }

        [TestCase(5, "VW", "Golf", "CB0002CC")]
        [TestCase(5, "VW", "Passat", "CA1111CA")]
        public void AddVehicleShouldAddIfGarageHaveEnoughCapacityAndVehicleDoesNotExist(int capacity, string brand, string model, string plateNumber)
        {
            Garage garage = new Garage(capacity);
            Vehicle vehicle = new Vehicle(brand, model, plateNumber);
           
            var result = garage.AddVehicle(vehicle);

            Assert.IsTrue(result);
            Assert.Contains(vehicle, garage.Vehicles);
        }

        [TestCase(5, "VW", "Golf", "CB0002CC")]
        [TestCase(5, "VW", "Passat", "CA1111CA")]
        public void AddVehicleShouldReturnFalseIfCarAlreadyExists(int capacity, string brand, string model, string plateNumber)
        {
            Garage garage = new Garage(capacity);
            Vehicle vehicle = new Vehicle(brand, model, plateNumber);

            garage.AddVehicle(vehicle);
            var result = garage.AddVehicle(vehicle);

            Assert.IsFalse(result);


        }

        [Test]
        public void AddVehicleShouldReturnFalseIfGarageIsFull()
        {
            Garage garage = new Garage(2);

            Vehicle vehicle = new Vehicle("VW", "Golf", "CB0002CC");
            Vehicle vehicle2 = new Vehicle("VW", "Passat", "CA1111CA");
            Vehicle vehicle3 = new Vehicle("VW", "Jetta", "CB4444CB");

            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);
            var result = garage.AddVehicle(vehicle3);
            var contains = garage.Vehicles.Any(x => x.Brand == vehicle3.Brand && x.Model == vehicle3.Model
            && x.LicensePlateNumber == vehicle3.LicensePlateNumber);

            Assert.IsFalse(result);
            Assert.IsFalse(contains);

        }

        [Test]
        public void ChargeVehiclesShouldChargeUnderTheGivenValue()
        {
            Garage garage = new Garage(10);

            Vehicle vehicle = new Vehicle("VW", "Golf", "CB0002CC");
            Vehicle vehicle2 = new Vehicle("VW", "Passat", "CA1111CA");
            Vehicle vehicle3 = new Vehicle("VW", "Jetta", "CB4444CB");
            Vehicle vehicle4 = new Vehicle("VW", "Golf R", "CB5555CC");
            Vehicle vehicle5 = new Vehicle("VW", "Passat CC", "CA7777CA");

            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);
            garage.AddVehicle(vehicle3);
            garage.AddVehicle(vehicle4);
            garage.AddVehicle(vehicle5);

            garage.DriveVehicle(vehicle.LicensePlateNumber, 90, false);
            garage.DriveVehicle(vehicle2.LicensePlateNumber, 70, false);
            garage.DriveVehicle(vehicle3.LicensePlateNumber, 50, false);
            garage.DriveVehicle(vehicle4.LicensePlateNumber, 10, false);

            var chargedVehicles = garage.ChargeVehicles(50);

            Assert.AreEqual(chargedVehicles, 3);
            Assert.AreEqual(vehicle.BatteryLevel, 100);
            Assert.AreEqual(vehicle2.BatteryLevel, 100);
            Assert.AreEqual(vehicle3.BatteryLevel, 100);
            Assert.AreEqual(vehicle4.BatteryLevel, 90);
            Assert.AreEqual(vehicle5.BatteryLevel, 100);
        }

        [Test]
        public void DriveVehicleShouldNotMoveIfBatteryDranageIsAbove100OrHigherOfOurBattery()
        {
            Garage garage = new Garage(10);

            Vehicle vehicle = new Vehicle("VW", "Golf", "CB0002CC");
            Vehicle vehicle2 = new Vehicle("VW", "Passat", "CA1111CA");
            Vehicle vehicle3 = new Vehicle("VW", "Jetta", "CB4444CB");
            Vehicle vehicle4 = new Vehicle("VW", "Golf R", "CB5555CC");
            Vehicle vehicle5 = new Vehicle("VW", "Passat CC", "CA7777CA");

            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);
            garage.AddVehicle(vehicle3);
            garage.AddVehicle(vehicle4);
            garage.AddVehicle(vehicle5);

            garage.DriveVehicle(vehicle.LicensePlateNumber, 120, false);
            
            garage.DriveVehicle(vehicle2.LicensePlateNumber, 50, false);
            garage.DriveVehicle(vehicle2.LicensePlateNumber, 60, false);

            garage.DriveVehicle(vehicle3.LicensePlateNumber, 60, true);
            garage.DriveVehicle(vehicle3.LicensePlateNumber, 10, true);

            Assert.AreEqual(100, vehicle.BatteryLevel);
            Assert.AreEqual(50, vehicle2.BatteryLevel);
            Assert.AreEqual(40, vehicle3.BatteryLevel);

        }
        [Test]
        public void RepairVehicleShouldRepairAllDamagedVehicles()
        {
            Garage garage = new Garage(10);

            Vehicle vehicle = new Vehicle("VW", "Golf", "CB0002CC");
            Vehicle vehicle2 = new Vehicle("VW", "Passat", "CA1111CA");
            Vehicle vehicle3 = new Vehicle("VW", "Jetta", "CB4444CB");
            Vehicle vehicle4 = new Vehicle("VW", "Golf R", "CB5555CC");
            Vehicle vehicle5 = new Vehicle("VW", "Passat CC", "CA7777CA");

            garage.AddVehicle(vehicle);
            garage.AddVehicle(vehicle2);
            garage.AddVehicle(vehicle3);
            garage.AddVehicle(vehicle4);
            garage.AddVehicle(vehicle5);

            garage.DriveVehicle(vehicle.LicensePlateNumber, 30, true);
            garage.DriveVehicle(vehicle2.LicensePlateNumber, 50, true);
            garage.DriveVehicle(vehicle3.LicensePlateNumber, 40, true);

            var result = garage.RepairVehicles();
            var allVehiclesAreRepaired = garage.Vehicles.All(x => !x.IsDamaged);

            Assert.AreEqual($"Vehicles repaired: 3", result);
            Assert.IsTrue(allVehiclesAreRepaired);

        }
    }
}
