namespace FightingArena.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Internal;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]

        public void WarriorConstructorShouldWorkCorrectly()
        {
            string expectedName = "Pesho";
            int expectedDamage = 15;
            int expectedHP = 100;

            Warrior warrior = new(expectedName, expectedDamage, expectedHP);

            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDamage, warrior.Damage);
            Assert.AreEqual(expectedHP, warrior.HP);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("     ")]
        public void WarriorConstructorShouldThrowAnExceptionIfNameIsNullOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 25, 30),
                "Name should not be empty or whitespace!");
        }


        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-20)]
        public void WarriorConstructorShouldThrowAnExceptionIfDamageIsNotPositive(int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior ("Pesho", damage, 100),
                "Damage value should be positive!");
        }

        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(-20)]
        public void WarriorConstructorShouldThrowAnExceptionIfHPIsNegative(int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Pesho", 100, hp),
                "HP should not be negative!");
        }

        [Test]
        public void AttackMethodShouldWorkCorrectly()
        {
            int expectedAttackerHp = 95;
            int expectedDefenderHp = 80;

            Warrior attacker = new("Pesho", 10, 100);
            Warrior defender = new("Gosho", 5, 90);

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }

        [TestCase(29)]
        [TestCase(30)]
        [TestCase(10)]
        public void AttackMethodShouldThrowAnExceptionIfWarriorHPIsBelow30(int hp)
        {
            Warrior attacker = new("Pesho", 50, hp);
            Warrior defender = new("Gosho", 50, 90);

            Assert.Throws<InvalidOperationException>(
                () => attacker.Attack(defender),
                "Your HP is too low in order to attack other warriors!");
        }

        [TestCase(29)]
        [TestCase(30)]
        [TestCase(10)]
        public void AttackMethodShouldThrowAnExceptionIfEnemyWarriorHPIsLowerThan30InOrderToAttackHim(int hp)
        {
            Warrior attacker = new("Pesho", 50, 100);
            Warrior defender = new("Gosho", 50, hp);

            Assert.Throws<InvalidOperationException>(
                () => attacker.Attack(defender),
                "Enemy HP must be greater than 30 in order to attack him!");
        }

        [Test]
        public void AttackMethodShouldThrowAnExceptionIfEnemyWarriorDamageIsHigherThanOurHP()
        {
            
            Warrior attacker = new("Pesho", 10, 90);
            Warrior defender = new("Gosho", 100, 90);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender),
                "You are trying to attack too strong enemy");
        }

        [Test]
        public void EnemyHPShouldBeSetToZeroIfWarriorDamageIsGreaterThanHisHP()
        {

            Warrior attacker = new("Pesho", 50, 100);
            Warrior defender = new("Gosho", 45, 40);

            attacker.Attack(defender);

            int expectedAttackerHP = 55;
            int expectedDefenderHP = 0;

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }

    }
}