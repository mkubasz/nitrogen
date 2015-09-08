using System;
using Microsoft.Office.Interop.Excel;
namespace ConverterDll.Excel
{
    public class ExcelConnector
    {
        private Application _excelApp;

        public ExcelConnector()
        {
            _excelApp = new Application();
        }

       public Workbook OpenFile(string pathFile)
        {
            try
            {
                var excelFile = _excelApp.Workbooks.Open(pathFile, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                ExcelScanInternal(excelFile);

                return excelFile;
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