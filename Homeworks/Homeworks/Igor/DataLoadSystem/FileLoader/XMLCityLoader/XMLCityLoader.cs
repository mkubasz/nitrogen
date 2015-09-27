using System.Xml;
using ExceptionTranslator;

namespace Homeworks.Igor.DataLoadSystem.FileLoader.XMLCityLoader
{
    public class XMLCityLoader : FileLoader<City>
    {
        public XMLCityLoader(string path)
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
                            DataSet.Add(new City(data.InnerText));
                        }
                    }
                }
            }
            else throw new ExceptionTran(ExceptionsPack.StringIsEmpty);
        }
    }
}
