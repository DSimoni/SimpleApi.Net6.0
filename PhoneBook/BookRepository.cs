using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PhoneBook
{
    public class BookRepository
    {
        private string path = Environment.CurrentDirectory + "/Phones.xml";
        private XmlDocument phonesDocument = new XmlDocument();



        public XmlDocument getBookXmlData()
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                string streamBook = streamReader.ReadToEnd();
                phonesDocument.LoadXml(streamBook);
            }

            return phonesDocument;
        }

        public void Save(XmlDocument phonesDoc)
        {
            phonesDoc.Save("Phones.xml");
        }

    }
}
