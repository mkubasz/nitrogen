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
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            XmlNodeList list = xmlDoc.SelectNodes("/ExceptionList");

            int a = 0;
            if (list != null)
                foreach (XmlNode obj in list)
                {
                    foreach (XmlNode data in obj.ChildNodes)
                    {
                        if (data.Name == "Exception")
                        {
                            Elements.Add(a++, data.InnerText);
                        }
                    }
                }
        }
    }
}