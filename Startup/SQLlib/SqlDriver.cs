using System;
using System.Data;
using Npgsql;

namespace SQLlib.SQL
{
    internal class SqlDriver : ISqlDriver
    {
        private readonly NpgsqlCommand cmd = new NpgsqlCommand();
        private string CreateTableSchema { get; set; }
        private ISqlConnection sqlConnection;
        public SqlDriver(ISqlConnection sqlConnection)
        {
            CreateTableSchema = "Banki";
            this.sqlConnection = new SqlConnection();
            cmd.Connection = this.sqlConnection.GetConnection();
        }

        public DataTable[] SelectAllTables()
        {
            throw new NotImplementedException();
        }

        public DataTable SelectTable(string tableName)
        {
            NpgsqlDataReader reader;
            try
            {
                sqlConnection.OpenConnection();
                cmd.CommandText = "SELECT * FROM " + "\"" + CreateTableSchema + "\".\"" + tableName + "\"";
                reader = cmd.ExecuteReader();
                
            }
            catch (NpgsqlException ex)
            {
                throw new SqlExceptions(ex.Message);
            }
            finally
            {
                sqlConnection.CloseConnection();
            }
            return reader.GetSchemaTable();
        }

        public void Insert(string[] record, string tableName)
        {
            
            try
            {
                sqlConnection.OpenConnection();
                cmd.CommandText = "INSERT INTO "  +"\"" + CreateTableSchema + "\".\"" + tableName + "\"" +
                                  "(ID, NumberOfAccount, NameOfBank, NumberOfBank) VALUES (1," +                    "'36249010440000420057684506', 'Alior',1111)";
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                throw new SqlExceptions(ex.Message);
            }
            finally
            {
                sqlConnection.CloseConnection();
            }
        }

        public void CreateTable(string tableName)
        {
            try
            {
                sqlConnection.OpenConnection();

                cmd.CommandText = "CREATE TABLE " + "\""+CreateTableSchema+"\".\""+tableName+"\"" + " (" +
                                  "ID int ," +
                                  "NumberOfAccount text," +
                                  "NameOfBank text," +
                                  "NumberOfBank int)";
                cmd.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                throw new SqlExceptions(ex.Message);
            }
            finally
            {
                sqlConnection.CloseConnection();
            }
        }

        public DataTable ImportTable()
        {
            throw new NotImplementedException();
        }
    }
}