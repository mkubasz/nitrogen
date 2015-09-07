using System;
using ConverterDll.Excel;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConnectionTest
{
    [TestClass]
    public class ReadFileTests
    {
        [TestMethod]
        public void ReadFileTest()
        {
			ExcelConnector connector = new ExcelConnector();
			connector.OpenFile(@"d:\aaa.xls");
		}

	}
}
