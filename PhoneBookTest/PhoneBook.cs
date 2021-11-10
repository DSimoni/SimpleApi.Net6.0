using NUnit.Framework;
using PhoneBook;
using System;
using System.Collections.Generic;

namespace PhoneBookTest
{

    public class PhoneBookTest
    {
        private Book book = new Book() { Name = "Adam", Type = "Mobile", Number = "345344" };
        private int index;
        private int numberofXmlNode;

        [SetUp]
        public void Setup()
        {
            index = 0;
            numberofXmlNode = new BookService().Get().Count;
        }

        [Test, Order(1)]
        public void TestAGetName()
        {
            Book book = new BookService().Get("John Adams");
            Assert.AreEqual(book.Type, "Cellphone");
        }

        [Test, Order(2)]
        public void TestAGetAll()
        { 
           List<Book> bookNumbers = new BookService().Get();

           Assert.AreEqual(bookNumbers.Count, numberofXmlNode);
        }


        [Test, Order(3)]
        public void TestCreate()
        {
            new BookService().Create(book);
            index++;

            Book findNewBook = new BookService().Get("Adam");


            Assert.AreEqual(findNewBook.Type, "Mobile");
            Assert.AreEqual(findNewBook.Number, "345344");

        }

        [Test, Order(4)]
        public void TestUpdate()
        {
            new BookService().Update("Chris Brown", book);

            Book findNewBook = new BookService().Get("Adam");

            Assert.AreEqual(findNewBook.Type, "Mobile");
            Assert.AreEqual(findNewBook.Number, "345344");

        }

        [Test, Order(5)]
        public void TestDelete()
        {
            new BookService().Delete("Edit Smith");
            index--;


            Book findNewBook = new BookService().Get("Edit Smith");


            Assert.AreEqual(findNewBook.Type, null);
        }
    }
}