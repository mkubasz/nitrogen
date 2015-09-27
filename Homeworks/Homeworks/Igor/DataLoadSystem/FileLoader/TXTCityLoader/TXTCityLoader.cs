using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExceptionTranslator;

namespace Homeworks.Igor.DataLoadSystem.FileLoader.TXTCityLoader
{
    public class TXTCityLoader : FileLoader<City>
    {
        public TXTCityLoader(string path)
        {
            DataSet = new List<City>();
            if (path != "")
            {
                DataSet = (List<City>) File.ReadAllLines(path).ToList().Select(obj => new City(obj));
            }
            else throw new ExceptionTran(ExceptionsPack.StringIsEmpty);
        }
    }
}
