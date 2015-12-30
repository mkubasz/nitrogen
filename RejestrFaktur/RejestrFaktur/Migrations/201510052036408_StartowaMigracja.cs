namespace RejestrFaktur.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class StartowaMigracja : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Fakturas", newName: "Faktura");
            RenameTable(name: "dbo.Firmas", newName: "Firma");
            RenameTable(name: "dbo.Klients", newName: "Klient");
            RenameTable(name: "dbo.FakturaSzczegolies", newName: "FakturaSzczegoly");
            RenameTable(name: "dbo.Produkts", newName: "Produkt");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Produkt", newName: "Produkts");
            RenameTable(name: "dbo.FakturaSzczegoly", newName: "FakturaSzczegolies");
            RenameTable(name: "dbo.Klient", newName: "Klients");
            RenameTable(name: "dbo.Firma", newName: "Firmas");
            RenameTable(name: "dbo.Faktura", newName: "Fakturas");
        }
    }
}
