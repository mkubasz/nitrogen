using Cassandra;

namespace SQLlib.SqlBases
{
	public class SqlCassandra : SqlBase
	{

		protected SqlCassandra() : base()
		{
			
		}

		public string Host { get; set; }
		public string NameDataBase { get; set; }
		protected override void SqlConnection()
		{
			Cluster cluster = Cluster.Builder().AddContactPoint(Host).Build();
			ISession session = cluster.Connect(NameDataBase);
		}
	}
}