namespace RejestrFaktur.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faktura",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numer = c.String(),
                        DataWystawienia = c.DateTime(nullable: false),
                        DataSprzedazy = c.DateTime(nullable: false),
                        walutaKurs = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataZaplaty = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FakturaSzczegoly",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ilosc = c.Int(nullable: false),
                        wartoscNetto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        wartoscBrutto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        wartoscVat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        stawkaVat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PKWIU = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Firma",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Ulica = c.String(),
                        NumerDomuLokalu = c.String(),
                        Kod = c.String(),
                        Miejscowosc = c.String(),
                        Telefon = c.String(),
                        Nip = c.String(),
                        NumerKonta = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Klient",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Ulica = c.String(),
                        NumerDomuLokalu = c.String(),
                        Kod = c.String(),
                        Miejscowosc = c.String(),
                        Telefon = c.String(),
                        Nip = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlatnoscTyp",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nazwa = c.String(),
                        opis = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Produkt",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Cena = c.String(),
                        Vat = c.Int(nullable: false),
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
            DropTable("dbo.Produkt");
            DropTable("dbo.PlatnoscTyp");
            DropTable("dbo.Klient");
            DropTable("dbo.JednostkaMiary");
            DropTable("dbo.Firma");
            DropTable("dbo.FakturaSzczegoly");
            DropTable("dbo.Faktura");
        }
    }
}
