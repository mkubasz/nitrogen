using SQLlib.SqlInterfaces;

namespace SQLlib
{
    public class SqlMenager : ISqlMenager
    {
        private SqlConnection Connection;
        private SqlDriver Driver;

        public SqlMenager()
        {
            
            Driver = new SqlDriver(Connection);
            Driver.CreateTable("banki_t");
            Driver.Insert(new string[] { "a"},"banki_t");
            Driver.SelectTable("banki_t");
        }


    }
}
