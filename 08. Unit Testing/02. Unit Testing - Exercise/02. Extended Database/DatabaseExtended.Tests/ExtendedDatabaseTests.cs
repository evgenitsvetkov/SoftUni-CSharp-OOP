namespace DatabaseExtended.Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;
        private Person personOne = new Person(12121212, "Pesho");
        private Person personTwo = new Person(42424242, "Jonny");
        private Person personThree = new Person(78787878, "Anabel");

        [SetUp]
        public void Setup()
        {
            database = new Database();
        }

        //Tests//

        [TestCase(12121212, "Pesho")]
        [TestCase(42424242, "Jonny")]
        [TestCase(78787878, "Anabel")]
        public void PersonShouldBeInitializedCorrectrly(long id, string userName)
        {
            //Arrange
            long expextedId = id;
            string expectedUserName = userName;

            //Act
            Person person = new Person(id, userName);

            //Assert
            Assert.AreEqual(expextedId, person.Id);
            Assert.AreEqual(expectedUserName, person.UserName);
        }

        [Test]
        public void DatabaseConstructorShouldWorkProperly()
        {
            //Arrange
            Person[] people = new Person[] { personOne, personTwo, personThree};

            //Act
            Database database = new Database(people);

            //Assert
            Assert.AreEqual(people.Length, database.Count);
        }

        [Test]
        public void AddRangeShouldReturnExceptionIfLengthIsMoreThan16()
        {
            //Arrange
            Person[] people = new Person[] { personOne, personTwo, personThree, personOne, personTwo, personThree, personOne, personTwo, personThree, personOne, personTwo, personThree, personOne, personTwo, personThree, personOne, personTwo, personThree };

            //Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(
                () => new Database(people));

            Assert.AreEqual(exception.Message, "Provided data length should be in range [0..16]!");
        }

        [Test]
        public void AddMethodShouldWorkProperly()
        {
            //Arrange
            Person[] people = new Person[] { personOne, personTwo };
            database = new Database(people);

            //Act
            database.Add(personThree);

            //Assert
            Assert.AreEqual(database.Count, 3);
        }
        
        [Test]
        public void AddMethodShouldThrowAnExceptionIfThereAreAlready16Users()
        {
            //Arrange
            Person[] people = new Person[]
            {
                personOne, personTwo, personThree,
                new Person(2323, "Evgeni"),
                new Person(2424, "Maq"),
                new Person(2525, "Dimitar"),
                new Person(1313, "Miroslav"),
                new Person(5656, "Stoyan"),
                new Person(4343, "Emil"),
                new Person(2121, "Georgi"),
                new Person(9898, "Elena"),
                new Person(8989, "Asen"),
                new Person(6767, "Daniela"),
                new Person(7777, "Iliyan"),
                new Person(4646, "Simeon"),
                new Person(1212, "Gergana"),
            };

            //Act
            database = new Database(people);

            //Assert

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => database.Add(new Person(3232, "Misho")));

            Assert.AreEqual(exception.Message, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void AddMethodShouldThrowAnExceptionIfThereAreAlreadyUsersWithThisUsername()
        {
            //Arrange
            Person[] people = new Person[] { personOne, personTwo };
            Person person = new Person(131313, "Jonny");
            database = new Database(people);

            //Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => database.Add(person));

            Assert.AreEqual(exception.Message, "There is already user with this username!");
        }

        [Test]
        public void AddMethodShouldThrowAnExceptionIfThereAreAlreadyUsersWithThisId()
        {
            //Arrange
            Person[] people = new Person[] { personOne, personTwo };
            Person person = new Person(42424242, "Martin");
            database = new Database(people);

            //Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => database.Add(person));

            Assert.AreEqual(exception.Message, "There is already user with this Id!");
        }

        [Test]
        public void RemoveMethodShouldWorkProperly()
        {
            //Arrange
            database = new Database(personOne, personTwo, personThree);

            //Act
            database.Remove();

            //Assert
            Assert.AreEqual(database.Count, 2);
        }

        [Test]
        public void RemoveMethodShouldThrowAnExceptionIfPeopleAreZero()
        {
            //Arrange
            Person[] people = { };
            database = new Database(people);

            //Assert
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
                () => database.Remove());
        }

        //Finding By Username Tests
        [Test]
        public void FindByUsernameWorksCorrectly()
        {
            //Arrange
            database = new Database(personOne, personTwo, personThree);

            //Act
            Person person = database.FindByUsername(personThree.UserName);

            //Assert
            Assert.AreEqual(person, personThree);
        }

        [TestCase("")]
        [TestCase(null)]
        public void DatabaseFindByUsernameMethodShouldThrowAnExceptionIfUsernameIsNull(string username)
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(()
                => database.FindByUsername(username), "Username parameter is null!");
        }

        [TestCase("Liliya")]
        [TestCase("Misho")]
        [TestCase("Gosho")]
        public void DatabaseFindByUsernameMethodShouldThrowAnExceptionIfUsernameIsNotFound(string username)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => database.FindByUsername(username), "No user is present by this username!");
        }

        //Finding By Id Tests
        [Test]
        public void FindByIdWorksCorrectly()
        {
            //Arrange
            database = new Database(personOne, personTwo, personThree);

            //Act
            Person person = database.FindById(personThree.Id);

            //Assert
            Assert.AreEqual(person, personThree);
        }

        [TestCase(333333333333)]
        [TestCase(444444444444)]
        [TestCase(555555555555)]
        public void DatabaseFindByUsernameMethodShouldThrowAnExceptionIfIdIsNotFound(long id)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => database.FindById(id), "No user is present by this ID!");
        }

        [TestCase(-189456789456)]
        [TestCase(-1)]
        public void DatabaseFindByIdMethodShouldThrowAnExceptionIfIdIsNegativeNumber(long id)
        {
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(()
                => database.FindById(id), "Id should be a positive number!");
        }
    }
}