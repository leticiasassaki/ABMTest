using System;
using System.IO;
using System.Xml;
using TechTest.Class;

namespace TechTest
{
    class Program
    {

        static void Main(string[] args)
        {
            Exercise1();
            Exercise2();
        }

        static void Exercise1()
        {
            string path = Path.GetFullPath("Documents/EDIFACT.txt");

            TextParser textparser = new TextParser();

            var text = textparser.GetMessage(path);
            var locList = textparser.GetLOCList(text);
            var cleanLocList = textparser.CleanLocList(locList);
            var locElements = textparser.GetLocElements(cleanLocList);

            if (locElements == null)
            {
                Console.WriteLine("Your list is null");
            }
            else
            {
                for (int i = 0; i < locElements.Length; i++)
                    Console.WriteLine($"LOC elements [{locElements[i]}]");
            }
        }

        static void Exercise2()
        {
            string xmlPath = Path.GetFullPath("Documents/XML.xml");

            XmlDocument xmlDocument = new XmlDocument();
            XMLReader xmlReader = new XMLReader();

            xmlDocument.Load(xmlPath);
            XmlNodeList xmlNodeList = xmlReader.GetXmlNodeList(xmlDocument);
            var xmlList = xmlReader.GetXmlRefCode(xmlNodeList);

            foreach (var item in xmlList)
            {
                Console.WriteLine(item.InnerText);
            }
        }
    }
}
