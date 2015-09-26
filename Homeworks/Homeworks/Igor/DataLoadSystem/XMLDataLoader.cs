using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ExceptionTranslator;

namespace Homeworks.Igor.DataLoadSystem
{
    public class XMLDataLoader : ILoadDataSys
    {
        protected HashSet<string> DataSet = new HashSet<string>();

        public XMLDataLoader(string path)
        {
            if (path != "")
            {
                XmlDocument XmlDoc = new XmlDocument();
                XmlDoc.Load(path);

                XmlNodeList list = XmlDoc.SelectNodes("/Cities");

                foreach (XmlNode obj in list)
                {
                    foreach (XmlNode data in obj.ChildNodes)
                    {
                        if (data.Name == "City")
                        {
                            DataSet.Add(data.InnerText);
                        }
                    }
                }
            }
            else throw new ExceptionTran(ExceptionsPack.StringIsEmpty);
        }

        public HashSet<string> GetData()
        {
            return this.DataSet;
        }
    }
}
