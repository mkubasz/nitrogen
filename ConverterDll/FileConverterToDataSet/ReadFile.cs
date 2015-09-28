using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FileConverterToDataSet
{
    public class ReadFile
    {
        private readonly Dictionary<string, string> _fileCheckDictionary = new Dictionary<string, string>()
        {
            {".xlsx", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\""},
            {".xls", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"" }
        };
        protected DataSet DataSet = new DataSet();
        /// <summary>
        /// Take path to file and checks if file is supported
        /// </summary>
        public string GetConnectionString(string path)
        {
            foreach (var item in _fileCheckDictionary.Where(item => path.EndsWith(item.Key)))
            {
                return string.Format(item.Value, path);
            }
            return "WrongPath";
        }

    }
}
