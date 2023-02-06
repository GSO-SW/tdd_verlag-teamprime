using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Verlag;
using isbn;

namespace VerlagTests
{
    [TestClass]
    public class BuchTests
    {
        [TestMethod]
        public void Buch_KannErstelltWerden()
        {
            //Arrange
            string autor = "J.K. Rowling";
            string titel = "Harry Potter und der Gefangene von Askaban";
            int auflage = 1;

            //Act 
            Buch b = new Buch(autor, titel, auflage);

            //Assert
            Assert.AreEqual(autor, b.Autor);
            Assert.AreEqual(titel, b.Titel);
            Assert.AreEqual(auflage, b.Auflage);
        }

        [TestMethod]
        public void Buch_KeineAuflageEntsprichtErsterAuflage()
        {
            //Arrange

            //Act 
            Buch b = new Buch("autor", "titel", "isbn");

            //Assert
            Assert.AreEqual(1, b.Auflage);
        }

        [TestMethod]
        public void Autor_DarfVeraendertWerden()
        {
            //Arrange
            string autor = "Gugu";
            string autorNeu = "Ugur";

            //Act
            Buch b = new Buch(autor, "titel", "isbn");
            b.Autor = autorNeu;

            //Assert
            Assert.AreEqual(autorNeu, b.Autor);

        }

        [TestMethod]
        public void Auflage_DarfVeraendertWerden()
        {
            //Arrange
            int auflage = 15;
            int auflageNeu = 42;

            //Act
            Buch b = new Buch("autor", "titel", auflage);
            b.Auflage = auflageNeu;

            //Assert
            Assert.AreEqual(auflageNeu, b.Auflage);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Buch_AuflageDarfNichtZuKleinSein()
        {
            //Arrange
            int auflage = 0;

            //Act
            Buch b = new Buch("autor", "titel", auflage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Auflage_DarfNichtZuKleinSein()
        {
            //Arrange
            Buch b = new Buch("autor", "titel", "isbn");
            int auflageNeu = 0;

            //Act
            b.Auflage = auflageNeu;
        }

        // DataRow: https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest#add-more-features
        [TestMethod]
        [DataRow("")]
        [DataRow("#")]
        [DataRow(";")]
        [DataRow("§")]
        [DataRow("%")]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentException))]
        public void Autor_NurSinnvolleEingabenErlaubt(string unerlaubtesZeichen)
        {
            //Arrange
            string name = "Ugur";
            name = name + unerlaubtesZeichen;

            //Act
            Buch b = new Buch(name, "titel", "isbn");
        }

        [TestMethod]
        public void Buch_BuchKannISBNNummerErhalten()
        {
            //Arange
            string isbn13 = "978-3770436163";

            Buch test = new Buch("Siu", "CR7", isbn13);

            //Act
            test.ISBN = isbn13;

            //Assert
            Assert.AreEqual(isbn13, test.ISBN.isbn13);
        }

        internal class ISBNTests
        {
            [TestMethod]
            public void ISBN_KannErstelltWerden()
            {
                //Arrange
                string isbn13 = "927-9285748266";

                //Act
                ISBN isbn = new ISBN(isbn13);

                //Assert
                Assert.AreEqual(isbn13, isbn.Isbn13);
            }
            [TestMethod]
            public void ISBN_PruefzifferWirdAutomatischBerechnet()
            {
                //Arrange
                string isbnOhnePruefziffer = "927-928574826";
                string pruefziffer = "6";
                string isbn13 = isbnOhnePruefziffer + pruefziffer;

                //Act
                ISBN isbn = new ISBN(isbnOhnePruefziffer);

                //Assert
                Assert.AreEqual(isbn13, isbn.Isbn13);
            }

            [TestMethod]
            public void ISBN_isbn10KannAusIsbn13BerechnetWerden()
            {
                //Arrange
                string isbn13 = "927-9285748266";
                string isbn10 = "9285748266";

                //Act
                ISBN isbn = new ISBN(isbn13);

                //Assert
                Assert.AreEqual(isbn10, isbn.isbn10);
            }
        }
    }
}

