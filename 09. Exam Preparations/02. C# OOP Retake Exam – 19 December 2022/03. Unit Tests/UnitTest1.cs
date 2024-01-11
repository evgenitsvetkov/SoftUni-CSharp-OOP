namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System;

    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }
               
        //Tests
        [Test]
        public void AddTextBookToLibraryMethodShouldWorkCorrectly()
        {
            TextBook textBook = new TextBook("The Open Boat", "Stephen Crane", "Classic");

            UniversityLibrary library = new UniversityLibrary();

            var expectedResult = library.AddTextBookToLibrary(textBook);

            Assert.AreEqual(library.Catalogue.Count, 1);
            Assert.AreEqual(textBook.InventoryNumber, 1);
            Assert.AreEqual(expectedResult, $"Book: {textBook.Title} - {textBook.InventoryNumber}" + Environment.NewLine
                + $"Category: {textBook.Category}" + Environment.NewLine
                + $"Author: {textBook.Author}");
        }

        [Test]
        public void LoanTextBookToLibraryMethodShouldWorkCorrectly()
        {
            TextBook textBook = new TextBook("The Open Boat", "Stephen Crane", "Classic");
            TextBook textBook2 = new TextBook("The Higgler", "A. E. Coppard", "Romance");

            UniversityLibrary library = new UniversityLibrary();

            library.AddTextBookToLibrary(textBook);
            library.AddTextBookToLibrary(textBook2);

            var expectedResultTextBook = $"{textBook.Title} loaned to Evgeni Tsvetkov.";
            var expectedResultTextBook2 = $"Evgeni Tsvetkov still hasn't returned {textBook2.Title}!";

            library.LoanTextBook(2, "Evgeni Tsvetkov");
            var actualResultTextBook = library.LoanTextBook(1, "Evgeni Tsvetkov");
            var actualResultTextBook2 = library.LoanTextBook(2, "Evgeni Tsvetkov");

            Assert.AreEqual(expectedResultTextBook, actualResultTextBook);
            Assert.AreEqual(expectedResultTextBook2, actualResultTextBook2);
            Assert.That(textBook2.Holder == "Evgeni Tsvetkov");
        }

        [Test]
        public void ReturnTextBookMethodShouldWorkCorrectly()
        {
            TextBook textBook = new TextBook("The Open Boat", "Stephen Crane", "Classic");

            UniversityLibrary library = new UniversityLibrary();

            library.AddTextBookToLibrary(textBook);

            library.LoanTextBook(1, "Evgeni Tsvetkov");
            
            var expectedResult = $"{textBook.Title} is returned to the library.";
            var actualResult = library.ReturnTextBook(1);

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(textBook.Holder, string.Empty);
        }
    }
}