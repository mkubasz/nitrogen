using System.Collections.Generic;
using ExceptionTranslator;
using System.IO;
using System.Linq;

namespace Homeworks.Igor.DataLoadSystem
{
    public class TxtDataLoader : ILoadDataSys<City>
    {
        protected List<City> DataSet;

        public TxtDataLoader(string path)
        {
            DataSet = new List<City>();
            if (path != "")
            {
                DataSet = (List<City>) File.ReadAllLines(path).ToList().Select(obj => new City(obj));
            }
            else throw new ExceptionTran(ExceptionsPack.StringIsEmpty);
        }

        public List<City> GetData()
        {
            return DataSet;
        }
    }
}
