using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLlib.SQL
{
    public class SqlExceptions : ArgumentException
    {
        public string ExceptionMsg {get; protected set; }

        public SqlExceptions(string ex)
        {
            
        }
    }
}
