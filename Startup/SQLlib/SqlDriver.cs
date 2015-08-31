using System;
using System.Data;
using Npgsql;
using SQLlib.SqlException;
using SQLlib.SqlInterfaces;

namespace SQLlib
{
    internal class SqlDriver<T> : ISqlDriver<T>
    {

        private string CreateTableSchema { get; set; }
        private ISqlConnection<T> sqlConnection;
        public SqlDriver(ISqlConnection<T> sqlConnection, SqlBase sqlBase)
        {
           
        }

       
    }
}