using NUnit.Framework;

namespace VehicleGarage.Tests
{
    public class VehicleTests
    {
        [TestCase("VW", "Golf", "CB4444CA")]
        [TestCase("Toyota", "Rav4", "CB1111CC")]
        public void ConstructorShouldInitializeAllValue(string make, string model, string licensePlateNumber)
        {
            Vehicle vehicle = new Vehicle(make, model, licensePlateNumber);

            Assert.AreEqual(vehicle.Brand, make);
            Assert.AreEqual(vehicle.Model, model);
            Assert.AreEqual(vehicle.LicensePlateNumber, licensePlateNumber);
            Assert.AreEqual(vehicle.IsDamaged, false);
            Assert.AreEqual(vehicle.BatteryLevel, 100);
        }
    }
}