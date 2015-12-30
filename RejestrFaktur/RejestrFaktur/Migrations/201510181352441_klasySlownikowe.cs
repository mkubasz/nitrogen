namespace RejestrFaktur.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class klasySlownikowe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JednostkaMiary",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NazwaJednostki = c.String(),
                        SymbolJednostki = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlatnoscTyp",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StawkaPodatku",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NazwaStawki = c.String(),
                        WysokoscStawki = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Waluta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Symbol = c.String(),
                        SciezkaDoIkony = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Waluta");
            DropTable("dbo.StawkaPodatku");
            DropTable("dbo.PlatnoscTyp");
            DropTable("dbo.JednostkaMiary");
        }
    }
}
