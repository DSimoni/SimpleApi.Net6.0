using System.Xml;
using System.Xml.Linq;

namespace PhoneBook
{
    public class BookService
    {
        private BookRepository bookRepository = new BookRepository();
        private XmlDocument phonesDocument = new XmlDocument();
        private XmlNodeList? listBook = null;


        public BookService()
        {
            phonesDocument = bookRepository.getBookXmlData();
            listBook = phonesDocument.SelectNodes("//PhoneNumbers/PhoneNumber");
        }

        public List<Book> Get()
        {
            List<Book> resultBook = new List<Book>();

                if (listBook != null)
                {
                    foreach (XmlNode node in listBook)
                    {

                        resultBook.Add(new Book() { Name = node["Name"].InnerText,
                        Type = node["Type"].InnerText,
                        Number = node["Number"].InnerText
                        });
                    }
                }

            return resultBook.OrderBy(name => name.Name).ToList();
        }


        public Book Get(string name)
        {
            Book book = new Book();

            if (listBook != null)
            {
                foreach (XmlNode node in listBook)
                {
                    if (node["Name"].InnerText.Contains(name))
                    {
                        book = new Book
                        {
                            Name = node["Name"].InnerText,
                            Type = node["Type"].InnerText,
                            Number = node["Number"].InnerText
                        };
                    }
                }
            }

            return book;
        }

        public void Create(Book book)
        {
                XmlNode rootNode = phonesDocument.CreateElement("PhoneNumber");
                phonesDocument.DocumentElement.AppendChild(rootNode);

                XmlNode nameNode = phonesDocument.CreateElement("Name");
                XmlNode typeNode = phonesDocument.CreateElement("Type");
                XmlNode numnberNode = phonesDocument.CreateElement("Number");

                nameNode.InnerText = book.Name;
                typeNode.InnerText = book.Type;
                numnberNode.InnerText = book.Number;


                rootNode.AppendChild(nameNode);
                rootNode.AppendChild(typeNode);
                rootNode.AppendChild(numnberNode);

            bookRepository.Save(phonesDocument);
        }


        public void Update(string name, Book book)
        {
            if (listBook != null)
            {
                foreach (XmlNode node in listBook)
                {
                    if (node["Name"].InnerText.Equals(name))
                    {
                        node["Number"].InnerText = book.Number;
                        node["Type"].InnerText = book.Type;
                    }
                }
            }
            bookRepository.Save(phonesDocument);

        }

        public void Delete(string name)
        {
            if (listBook != null)
            {
                foreach (XmlNode node in listBook)
                {
                    if (node["Name"].InnerText.Equals(name))
                    {
                        node.ParentNode.RemoveChild(node); //Remove Child from Name
                    }
                }
            }

            bookRepository.Save(phonesDocument);
        }



    }
}
