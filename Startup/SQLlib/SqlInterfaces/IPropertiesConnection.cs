namespace SQLlib.SqlInterfaces
{
	public interface IPropertiesConnection
	{
		string Host { get; set; }
		string User { get; set; }
		string Password { get; set; }
		string DBname { get; set; }
		string Schema { get; set; }

	}
}