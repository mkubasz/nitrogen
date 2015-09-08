using System;
using ConverterDll.Excel;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

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

        [TestMethod]
        public void FirstProcessingToDataTableTest()
        {
            string path = @"d:\aaa.xls";
            ExcelProcessing processing = new ExcelProcessing(path);
            DataTable Data;
            Data = processing.GetExcelDataTable();


        }

	}
}
