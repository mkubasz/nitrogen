using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExceptionTranslator.OpenSys
{
    public class XmlOpenerSys : OpenSystem
    {
        public XmlOpenerSys(string path)
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(path);

            XmlNodeList list = XmlDoc.SelectNodes("/ExceptionList");

            int a = 0;
            foreach (XmlNode obj in list)
            {
                foreach (XmlNode data in obj.ChildNodes)
                {
                    if (data.Name == "Exception")
                    {
                        elements.Add(a++, data.InnerText);
                    }
                }
            }
        }
    }
}