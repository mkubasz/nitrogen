using System.Linq;
using System.Data.OleDb;
using System.Data;
using FileConverterToDataSet.Interfaces;


namespace FileConverterToDataSet
{
    class ReadExcel : ReadFile, IReadExcelFile
    {
        public DataSet ReadExcelFile(string pathToFile)
        {
            //DataSet dataSet = new DataSet();
            using (OleDbConnection connection = new OleDbConnection(GetConnectionString(pathToFile)))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                //sheets names ascending orders
                DataTable dataTableSheet = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (dataTableSheet != null)
                    foreach (string sheetName in dataTableSheet.Rows.Cast<DataRow>().Select(dataRow => dataRow["TABLE_NAME"].ToString()).Where(sheetName => sheetName.EndsWith("$")))
                    {
                        command.CommandText = "SELECT * FROM [" + sheetName + "]";
                        DataTable dataTable = new DataTable { TableName = sheetName };
                        OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
                        dataAdapter.Fill(dataTable);
                        DataSet.Tables.Add(dataTable);
                    }
                connection.Close();
            }
            return DataSet;
        }
    }
}
