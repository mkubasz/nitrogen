using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileConverterToDataSet
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Dictionary<string, string> _fileCheckDictionary = new Dictionary<string, string>()
        {
            {".xlsx", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\""},
            {"xls", "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"" }
        };
            string path = @"C:\nowy.xlsx";

            ReadExcel excel = new ReadExcel();

            string a = excel.GetConnectionString(path);
            excel.ReadExcelFile(path);
            //     excel.ReadExcelFile(path);
            //   Assert.AreEqual("a", "a");

        }
    }


}
