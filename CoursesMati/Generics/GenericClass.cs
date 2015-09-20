using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class GenericClass<TF,TS>
    {
		private Array array;
		private ArrayList arrayList;
		private Hashtable hashtable;


		private List<TF> list;
		private Dictionary<TF,TS> dictionary; // Map
		private HashSet<TF> hash;
		private LinkedList<TF> linkedList;

		private Queue<TF> queue;
		private Stack<TF> stack;
		private object obj;
	    public GenericClass(TF type)
	    {
		    obj = type;
			stack = new Stack<TF>();
			stack.
	    }

	    void SendToDataBase(TF type)
	    {
		    SqlConnection conn = new SqlConnection();
			/// ... conn.Send(type);

		    if (type.GetType() == typeof (string))
		    {
			    
		    }
	    }
		void ResendToDataBase(TS type)
		{
			SqlConnection conn = new SqlConnection();
			/// ... conn.Send(type);

			if (type.GetType() == typeof(string))
			{

			}
		}
	}
}
