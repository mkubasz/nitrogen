namespace RejestrFaktur.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Poprawki : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JednostkaMiary", "NazwaJednostki", c => c.String(nullable: false));
            AlterColumn("dbo.JednostkaMiary", "SymbolJednostki", c => c.String(nullable: false));
            AlterColumn("dbo.PlatnoscTyp", "Nazwa", c => c.String(nullable: false));
            AlterColumn("dbo.StawkaPodatku", "NazwaStawki", c => c.String(nullable: false));
            AlterColumn("dbo.Waluta", "Nazwa", c => c.String(nullable: false));
            AlterColumn("dbo.Waluta", "Symbol", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Waluta", "Symbol", c => c.String());
            AlterColumn("dbo.Waluta", "Nazwa", c => c.String());
            AlterColumn("dbo.StawkaPodatku", "NazwaStawki", c => c.String());
            AlterColumn("dbo.PlatnoscTyp", "Nazwa", c => c.String());
            AlterColumn("dbo.JednostkaMiary", "SymbolJednostki", c => c.String());
            AlterColumn("dbo.JednostkaMiary", "NazwaJednostki", c => c.String());
        }
    }
}
