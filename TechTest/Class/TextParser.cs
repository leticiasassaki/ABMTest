using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TechTest
{
    class TextParser
    {
        public string[] GetMessage(string path)
        {
            try
            {
                return File.ReadAllLines(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<string> GetLOCList(string[] text)
        {
            try
            {
                var loc = (from item in text
                           where item.StartsWith("LOC")
                           select item).ToList();
                return loc;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<string> CleanLocList(List<string> loc)
        {
            try
            {
                var locList =  (from item in loc
                                select item[0..^1]).ToList();
                return locList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public string[] GetLocElements(List<string> loc)
        {
            try
            {
                var values = (from i in loc
                              let part = i.Split('+')
                              let item = part[1] + "," + part[2]
                              select item).ToList();

                return values.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
