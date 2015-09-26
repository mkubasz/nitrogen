using System.Collections.Generic;
using System.Xml;
using ExceptionTranslator;

namespace Homeworks.Igor.DataLoadSystem
{
    public class XmlDataLoader : ILoadDataSys
    {
        protected List<string> DataSet = new List<string>();

        public XmlDataLoader(string path)
        {
            if (path != "")
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(path);

                var list = xmlDoc.SelectNodes("/Cities");

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

        public List<string> GetData()
        {
            return this.DataSet;
        }
    }
}
