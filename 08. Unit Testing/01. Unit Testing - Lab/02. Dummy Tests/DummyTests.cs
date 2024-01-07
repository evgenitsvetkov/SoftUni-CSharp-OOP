using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyShouldInitializeWithCorrectValues()
        {
            //Arrange and act
            Dummy dummy = new Dummy(100, 100);

            //Assert
            Assert.AreEqual(100, dummy.Health);
        }

        [Test]
        public void TakeAttackShouldDecreaseHealth()
        {
            //Arrange
            Dummy dummy = new Dummy(10, 10);

            //Act
            dummy.TakeAttack(5);

            //Arrange
            Assert.AreEqual(5, dummy.Health);
        }

        [Test]
        public void TakeAttackShouldThrowsAnExceptionIfDummyIsDead()
        {
            //Arrange
            Dummy dummy = new Dummy(10, 10);

            //Act
            dummy.TakeAttack(5);
            dummy.TakeAttack(5);

            //Arrange
            Assert.Throws<InvalidOperationException>(
                () => dummy.TakeAttack(5),
                "Dummy is dead.");
        }

        [Test]
        public void DeadDummyCanGiveExperience()
        {
            //Arrange
            Dummy dummy = new Dummy(100, 100);

            //Act
            dummy.TakeAttack(50);
            dummy.TakeAttack(50);

            //Assert
            Assert.AreEqual(100, dummy.GiveExperience());
        }

        [Test]
        public void GiveXPShouldThrowsAnExceptionIfDummyIsNotDead()
        {
            //Arrange
            Dummy dummy = new Dummy(10, 10);

            //Act
            dummy.TakeAttack(5);

            //Assert
            Assert.Throws<InvalidOperationException>(
                () => dummy.GiveExperience(),
                "Target is not dead.");
        }

        [Test]
        public void IsDeadShouldCheckIfHealthIsBelowOrEqualToZero()
        {
            //Arrange
            Dummy dummy = new Dummy(50, 100);

            //Act
            dummy.TakeAttack(50);

            //Assert
            Assert.IsTrue(dummy.IsDead());
        }
    }
}