using SQLlib.SqlBases;

namespace SQLlib
{
	public interface ISqlReaction
	{
		SqlCassandra Cassandra { get; set; }
		SqlPostgres Postgres { get; set; }
		
	}
}