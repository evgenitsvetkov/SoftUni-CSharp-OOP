namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp] 
        public void SetUp() 
        {
            arena = new Arena();
        }

        [Test] 
        public void ArenaConstructorShouldWorkCorrectly() 
        {
            Assert.IsNotNull(arena);
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void ArenaCountShouldWorkCorrectly()
        {
            int expectedResult = 1;

            Warrior warrior = new Warrior("Pesho", 100, 100);

            arena.Enroll(warrior);

            Assert.IsNotEmpty(arena.Warriors);
            Assert.AreEqual(expectedResult, arena.Count);
        }

        [Test]
        public void ArenaEnrollShouldWorkCorrectly()
        {
            Warrior warrior = new Warrior("Gosho", 5, 100);

            arena.Enroll(warrior);

            Assert.IsNotEmpty(arena.Warriors);
            Assert.AreEqual(warrior, arena.Warriors.Single());
        }

        [Test]
        public void ArenaEnrollShouldThrowAnExceptionIfWarriorIsAlreadyEnrolled()
        {
            Warrior warrior = new Warrior("Gosho", 5, 100);
              
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(
                () => arena.Enroll(warrior),
                "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void ArenaFightShouldWorkCorrectly()
        {
            Warrior attacker = new Warrior("Gosho", 15, 100);
            Warrior defender = new Warrior("Pesho", 5, 50);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            int expectedAttackerHP = 95;
            int expectedDefenderHP = 35;

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }

        [Test]
        public void ArenaFightMethodShouldThrowAnExceptionIfAttackerNotFound()
        {
            Warrior attacker = new Warrior("Gosho", 15, 100);
            Warrior defender = new Warrior("Pesho", 5, 50);

            arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker.Name, defender.Name),
                $"There is no fighter with name {attacker.Name} enrolled for the fights!");
        }

        [Test]
        public void ArenaFightMethodShouldThrowAnExceptionIfDefenderNotFound()
        {
            Warrior attacker = new Warrior("Gosho", 15, 100);
            Warrior defender = new Warrior("Pesho", 5, 50);

            arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker.Name, defender.Name),
                $"There is no fighter with name {defender.Name} enrolled for the fights!");
        }



    }
}
