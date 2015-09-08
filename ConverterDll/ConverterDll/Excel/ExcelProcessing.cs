using System.Data;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace ConverterDll.Excel
{
    public class ExcelProcessing
    {
        private ExcelConnector _connection = new ExcelConnector();
        private Workbook _workbook;
        private readonly string _filePath;


        public ExcelProcessing(string path)
        {
            _filePath = path;
            _workbook = _connection.OpenFile(path);
        }


        public DataTable GetExcelDataTable()
        {
            var excelData = new DataTable();

            try
            {
                Worksheet worksheet = _workbook.Sheets.get_Item(1);
                Range excelRange = worksheet.UsedRange; //Used cells
                object[,] valueArray = (object[,]) excelRange.Value[XlRangeValueDataType.xlRangeValueDefault];

                excelData = ProcessObjects(valueArray);



            }
            catch (ConverterException ex)
            {
                throw new ConverterException("Error #2 Processing");
            }
            finally
            {
                if (_workbook != null)
                {
                    _workbook.Close(false, _filePath, null);
                }
                _workbook = null;
            }
            return excelData;
        }


        private DataTable ProcessObjects(object[,] valueArray)
        {
            DataTable dataTable = new DataTable();

           
            // Title Columns
            for (int k = 1; k <= valueArray.GetLength(1); k++)
            {
                dataTable.Columns.Add((string) valueArray[1, k]); //add columns to the data table.
            }
           
            // Load Rows and Columns to DataTable
            object[] singleDataValue = new object[valueArray.GetLength(1)];

            for (int i = 2; i <= valueArray.GetLength(0); i++)
            {
                for (int j = 0; j < valueArray.GetLength(1); j++)
                {
                    if (valueArray[i, j + 1] != null)
                    {
                        singleDataValue[j] = valueArray[i, j + 1].ToString();
                    }
                    else
                    {
                        singleDataValue[j] = valueArray[i, j + 1];
                    }
                }
                dataTable.LoadDataRow(singleDataValue, LoadOption.PreserveChanges);
            }
           

            return (dataTable);
        }

    }
}