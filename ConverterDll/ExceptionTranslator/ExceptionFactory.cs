using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace ExceptionTranslator
{
    public class ExceptionFactory : AbstractFactory<int, string>
    {
        public ExceptionFactory()
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load("C:\\Users\\Igor\\Documents\\nitrogen\\ConverterDll\\ExceptionTranslator\\XML_List\\ExceptionList.txt");

            XmlNodeList list = XmlDoc.SelectNodes("/ExceptionList");

            int a=0;
            foreach(XmlNode obj in list)
            {
                foreach(XmlNode data in obj.ChildNodes)
                {
                    if(data.Name=="Exception")
                    {
                        elements.Add(a++, data.InnerText);
                    }
                }
            }
        }
    }
}
