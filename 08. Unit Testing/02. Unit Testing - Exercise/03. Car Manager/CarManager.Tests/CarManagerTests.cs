namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void CarConstructorShouldWorkCorrectly()
        {
            Car car = new Car("VW", "Caddy", 10, 50);

            string expectedMake = "VW";
            string expectedModel = "Caddy";
            double expectedFuelConsumption = 10;
            double expectedFuelCapacity = 50;

            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
        }

        [Test]
        public void CarMakeShouldWorkCorrectly()
        {
            Car car = new Car("BMW", "3Series", 10, 50);

            string expectedMake = "BMW";

            Assert.AreEqual(expectedMake, car.Make);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarMakeShouldThrowAnExceptionIfMakeIsNullOrEmpty(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, "Caddy", 10, 50),
                "Make cannot be null or empty!");
        }

        [Test]
        public void CarModelShouldWorkCorrectly()
        {
            Car car = new Car("BMW", "3Series", 10, 50);

            string expectedModel = "3Series";

            Assert.AreEqual(expectedModel, car.Model);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarModelShouldThrowAnExceptionIfModelIsNullOrEmpty(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("VW", model, 10, 50),
                "Model cannot be null or empty!");
        }

        [Test]
        public void CarFuelConsumptionShouldWorkCorrectly()
        {
            Car car = new Car("BMW", "3Series", 10.5, 50);

            double expectedFuelConsumption = 10.5;

            Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-20)]
        public void CarFuelConsumptionShouldThrowAnExceptionIfValueIsZeroOrNegative(double fuelConsumption)
        {

            Assert.Throws<ArgumentException>(() => new Car("VW", "Caddy", fuelConsumption, 50),
                "Fuel consumption cannot be zero or negative!");
        }

        [Test]
        public void CarFuelCapacityShouldWorkCorrectly()
        {
            Car car = new Car("BMW", "3Series", 10.5, 50.5);

            double expectedFuelCapacity = 50.5;

            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-20)]
        public void CarFuelCapacityShouldThrowAnExceptionIfValueIsZeroOrNegative(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car("VW", "Caddy", 10, fuelCapacity),
                "Fuel capacity cannot be zero or negative!");
        }

        [Test]
        public void CarRefuelShouldWorkCorrectly()
        {
            Car car = new Car("BMW", "3Series", 10, 50);
            double fuelToRefuel = 50;
            car.Refuel(fuelToRefuel);

            Assert.AreEqual(fuelToRefuel, car.FuelAmount);
        }


        [TestCase(51)]
        [TestCase(60)]
        [TestCase(90)]
        public void CarRefuelShouldSetFuelAmountAndFuelCapacityWithSameValues(double fuelToRefuel)
        {
            Car car = new Car("BMW", "3Series", 10, 50);
            car.Refuel(fuelToRefuel);

            Assert.AreEqual(car.FuelCapacity, car.FuelAmount);
        }


        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-20)]
        public void CarRefuelShouldThrownAnExceptionIfFuelToRefuelIsZeroOrNegative(double fuelToRefuel)
        {
            Car car = new Car("BMW", "3Series", 10, 50);

            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel),
                "Fuel amount cannot be zero or negative!");
        }

        [Test]
        public void CarDriveMethodShouldWorkCorrectly()
        {
            Car car = new Car("BMW", "3Series", 10, 50);
            car.Refuel(50);
            car.Drive(100);

            double expectedFuelAmount = 40;

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void CarDriveMethodShouldThrowAnExceptionWhenFuelIsNotEnough()
        {
            Car car = new Car("BMW", "3Series", 10, 50);
            car.Refuel(1);

            Assert.Throws<InvalidOperationException>(() => car.Drive(100),
                "You don't have enough fuel to drive!");
        }

    }
}