namespace RejestrFaktur.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PoprawkiJednostkiMiar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JednostkaMiary", "NazwaJednostki", c => c.String(nullable: false, maxLength: 65));
            AlterColumn("dbo.JednostkaMiary", "SymbolJednostki", c => c.String(nullable: false, maxLength: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JednostkaMiary", "SymbolJednostki", c => c.String(nullable: false));
            AlterColumn("dbo.JednostkaMiary", "NazwaJednostki", c => c.String(nullable: false));
        }
    }
}
