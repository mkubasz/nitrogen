using System.Data;

namespace FileConverterToDataSet.Interfaces
{
    public interface IReadExcelFile
    {
        DataSet ReadExcelFile(string pathToFile);
       //string GetConnectionString(Dictionary<string, string> dictionary, string path );
    }
}