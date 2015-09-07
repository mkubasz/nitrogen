using System;
using Microsoft.Office.Interop.Excel;
namespace ConverterDll.Excel
{
    public class ExcelConnector
    {
        private Application _excelApp;
        protected Workbook ExcelFile;

        public ExcelConnector()
        {
            _excelApp = new Application();
        }

        public void OpenFile(string pathFile)
        {
            try
            {
                ExcelFile = _excelApp.Workbooks.Open(pathFile, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                ExcelScanInternal(ExcelFile);

                
            }
            catch (ConverterException ex)
            {
                throw new ConverterException("Error #1 Connecting");
            }
        }

        private void ExcelScanInternal(Workbook workFile)
        {
            int numSheet = workFile.Sheets.Count;
            for (int i = 1; i < numSheet+1; i++)
            {
                Worksheet sheet = (Worksheet) workFile.Sheets[i];
                Range range = sheet.UsedRange;

                object[,] valueArray = (object[,]) range.get_Value(XlRangeValueDataType.xlRangeValueDefault);
            }

        }

    }
}