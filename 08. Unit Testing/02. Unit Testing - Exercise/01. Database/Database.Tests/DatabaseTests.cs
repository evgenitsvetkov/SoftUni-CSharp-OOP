namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Runtime.Serialization;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database(1, 2);
        }


        [Test]
        public void CreatingDataBaseCountShouldBeCorrect()
        {

            //Arrange
            int expectedResult = 2;

            //Act
            Database database = new Database(1, 2);
            int actualResult = database.Count;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void CreatingDataBaseShouldAddElementCorrectly(int[] data)
        {
            //Arrange
            database = new(data);

            //Act
            int[] actualResult = database.Fetch();

            //Assert
            Assert.AreEqual(data, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        public void CreatingDataBaseShouldThrowAnExceptionWhenCountIsMoreThan16(int[] data)
        {
            Assert.Throws<InvalidOperationException>(
                () => database = new Database(data),
                "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void DataBaseCountShouldWorkCorrectly()
        {
            //Arrange
            int expectedResult = 2;
            int actualResult = database.Count;

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(-10)]
        [TestCase(3)]
        public void AddMethodShouldIncreaseCount(int number)
        {
            //Arrange
            int expectedResult = 3;

            //Act
            database.Add(number);

            //Assert
            Assert.AreEqual(expectedResult, database.Count);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5})]
        public void DataBaseAddMethodShouldAddElementsCorrectly(int[] data)
        {
            //Arrange
            database = new Database();

            //Act
            foreach (var number in data)
            {
                database.Add(number);
            }

            int[] actualResult = database.Fetch();

            //Assert
            Assert.AreEqual(data, actualResult);

        }

        [Test]
        public void DataBaseAddMethodShouldThrowAnExceptionWhenCountIsMoreThan16()
        {
            //Act
            for (int i = 0; i < 14; i++)
            {
                database.Add(i);
            }

            //Assert
            Assert.Throws<InvalidOperationException>(
                () => database.Add(3),
                "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void RemoveMethodShouldDecreaseCount()
        {
            //Arrange
            int expectedResult = 1;

            //Act
            database.Remove();

            //Assert
            Assert.AreEqual(expectedResult, database.Count);
        }

        [Test]
        public void RemoveMethodShouldRemoveLastElement()
        {
            //Arrange
            int[] expectedResult = Array.Empty<int>();

            //Act
            database.Remove();
            database.Remove();

            int[] actualResult = database.Fetch();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RemoveMethodShouldThrowAnExceptionWhenCollectionIsEmpty()
        {
            //Act
            database.Remove();
            database.Remove();

            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Remove(),
                "The collection is empty!");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void FetchMethodShouldReturnCorrectData(int[] data)
        {
            //Arrange
            database = new Database(data);

            //Act
            int[] actualResult = database.Fetch();

            //Assert
            Assert.AreEqual(data, actualResult);
        }
    }
}
