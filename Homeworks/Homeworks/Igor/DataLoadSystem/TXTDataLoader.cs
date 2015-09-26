using System.Collections.Generic;
using ExceptionTranslator;
using System.IO;
using System.Linq;

namespace Homeworks.Igor.DataLoadSystem
{
    public class TxtDataLoader : ILoadDataSys
    {
        protected List<string> DataSet;

        public TxtDataLoader(string path)
        {
            DataSet = new List<string>();
            if (path != "")
            {
                DataSet = File.ReadAllLines(path).ToList();
            }
            else throw new ExceptionTran(ExceptionsPack.StringIsEmpty);
        }

        public List<string> GetData()
        {
            return DataSet;
        }
    }
}
