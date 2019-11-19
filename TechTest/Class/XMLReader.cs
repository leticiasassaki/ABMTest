using System;
using System.Xml;
using System.Linq;
using System.Collections.Generic;

namespace TechTest.Class
{
    class XMLReader
    {
        public XmlNodeList GetXmlNodeList(XmlDocument xml)
        {
            try
            {
                string nodePattern = "//Reference";
                return xml.SelectNodes(nodePattern);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public IEnumerable<XmlNode> GetXmlRefCode(XmlNodeList xmlList)
        {
            try
            {
                return (from XmlNode item in xmlList
                        where item.Attributes["RefCode"].Value == "MWB"
                        || item.Attributes["RefCode"].Value == "TRV"
                        || item.Attributes["RefCode"].Value == "CAR"
                        select item);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
