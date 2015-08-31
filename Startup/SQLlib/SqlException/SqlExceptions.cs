using System;

namespace SQLlib.SqlException
{
    public class SqlExceptions : ArgumentException
    {
        public string ExceptionMsg {get; protected set; }

        public SqlExceptions(string ex)
        {
            
        }
    }
}
