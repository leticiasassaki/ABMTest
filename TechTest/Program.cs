using System;
using System.IO;

namespace TechTest
{
    class Program
    {

        static void Main(string[] args)
        {
            Exercise1();


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
    }
}
