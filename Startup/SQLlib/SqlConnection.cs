using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using SQLlib.SqlException;
using SQLlib.SqlInterfaces;

namespace SQLlib
{
    public class SqlConnection<T> where T:class , ISqlConnection<T>
    {
        
        public SqlConnection()
        {
            
        }

        public void SetConnection(List<IPropertiesConnection> property)
        {

           
        }

	    public T GetConnection()
	    {

		    return null;
	    }

        public void CloseConnection()
        {
           
        }

        public void OpenConnection()
        {
         
        }

        public bool CheckConnection()
        {
	        return false;
        }
    }
}
