using Npgsql;

namespace SQLlib.SqlInterfaces
{
    public interface ISqlConnection<T>
    {
        void SetConnection(string host,string user,string password,string dBname);

        T GetConnection() ;

        bool CheckConnection();
        void CloseConnection();
        void OpenConnection();
    }
}