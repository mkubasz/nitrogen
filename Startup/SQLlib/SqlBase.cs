using System.Collections.Generic;
using System.Data;
using SQLlib.SqlInterfaces;

namespace SQLlib.SqlBases
{
	public abstract class SqlBase
	{
		protected ISqlConnection<SqlPostgres> sqlConnection;

		protected SqlBase() : base()
		{
		}

		protected abstract string SchemaName { get; set; }

		protected abstract void SqlConnection(IPropertiesConnection propertiesConnection,
			ISqlConnection<SqlPostgres> sqlConnection);

		protected abstract DataTable[] SelectAllTables(List<string> tables);
		public abstract DataTable SelectTable(string tableName);
		public abstract void Insert(string[] record, string tableName);
		public abstract void CreateTable(string tableName);
		public abstract DataTable ImportTable();
		public abstract DataRowCollection GetRowsNames(string TableName);
	}
}