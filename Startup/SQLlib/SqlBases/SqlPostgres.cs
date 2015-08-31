using System.Collections.Generic;
using System.Data;
using Npgsql;
using Org.BouncyCastle.Cms;
using SQLlib.SqlException;
using SQLlib.SqlInterfaces;

namespace SQLlib.SqlBases
{
	public class SqlPostgres //: SqlBase 
		: SqlBase
	{
		private NpgsqlConnection connection;
		private readonly NpgsqlCommand cmd = new NpgsqlCommand();
		protected override string SchemaName { get; set; }


		protected SqlPostgres() : base()
		{
		}

		protected override void SqlConnection(IPropertiesConnection propertiesConnection,
			ISqlConnection<SqlPostgres> sqlConnection)
		{
			//connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=programowanie;Database=Banki");
			this.sqlConnection = sqlConnection;
			SchemaName = propertiesConnection.Schema;
			try
			{
				connection = new NpgsqlConnection(
					"Host=" + propertiesConnection.Host + 
					";Username=" + propertiesConnection.User + 
					";Password=" + propertiesConnection.Password + 
					";Database=" + propertiesConnection.DBname);
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

		protected override DataTable[] SelectAllTables(List<string> tables)
		{
			DataTable[] data = new DataTable[tables.Count];
			for (int i = 0; i < tables.Count; i++)
			{
				data[i] = SelectTable(tables[i]);
			}
			return data;
		}

		public override DataTable SelectTable(string tableName)
		{
			NpgsqlDataReader reader;
			try
			{
				sqlConnection.OpenConnection();
				cmd.CommandText = "SELECT * FROM " + "\"" + SchemaName + "\".\"" + tableName + "\"";
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
		public override void Insert(string[] record, string tableName)
		{
			try
			{
				sqlConnection.OpenConnection();
				cmd.CommandText = "INSERT INTO " + "\"" + SchemaName + "\".\"" + tableName + "\"" +
				                  "(ID, NumberOfAccount, NameOfBank, NumberOfBank) VALUES (1," +
				                  "'36249010440000420057684506', 'Alior',1111)";
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

		public override void CreateTable(string tableName)
		{
			try
			{
				sqlConnection.OpenConnection();

				cmd.CommandText = "CREATE TABLE " + "\"" + SchemaName + "\".\"" + tableName + "\"" + " (" +
					;
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

		public override DataTable ImportTable()
		{
			throw new System.NotImplementedException();
		}

		public override DataRowCollection GetRowsNames(string TableName)
		{

			NpgsqlDataReader npgsqlData = cmd.ExecuteReader();
			return npgsqlData.GetSchemaTable().Rows;
		}  
	}
}