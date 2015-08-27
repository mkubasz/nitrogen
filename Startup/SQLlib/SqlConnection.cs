using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using SQLlib.SQL;

namespace SQLlib
{
    public class SqlConnection : ISqlConnection
    {
        private NpgsqlConnection connection;
        public SqlConnection()
        {
            connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=programowanie;Database=Banki");
        }

        public void SetConnection(string host, string user, string password, string dBname)
        {

            connection =
                new NpgsqlConnection("Host=" + host + ";Username=" + user + ";Password=" + password + ";Database=" + dBname);
        }

        public NpgsqlConnection GetConnection()
        {
          
            return this.connection;
        }

        public void CloseConnection()
        {
            try
            {
                connection.Close();
            }
            catch (SqlExceptions ex)
            {
                throw ex = new SqlExceptions("Error while disconnectiong");
            }
        }

        public void OpenConnection()
        {
            try
            {
                connection.Open();
            }
            catch (SqlExceptions ex)
            {
                throw ex = new SqlExceptions("Error while connectiong");
            }
        }

        public bool CheckConnection()
        {
            if(connection.ConnectionTimeout > 5 || connection == null)
            return false;

            return true;
        }
    }
}
