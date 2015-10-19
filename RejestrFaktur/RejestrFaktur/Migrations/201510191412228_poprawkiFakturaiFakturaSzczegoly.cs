namespace RejestrFaktur.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class poprawkiFakturaiFakturaSzczegoly : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.FakturaSzczegoly");
            DropTable("dbo.Faktura");

            CreateTable("dbo.Faktura", c => new
           {
           Id = c.Int(nullable: false, identity: true),
           Numer = c.String(),
           DataWystawienia = c.DateTime(nullable: false),
           DataSprzedazy = c.DateTime(nullable: false),
           WalutaKurs = c.Decimal(nullable: false, precision: 18, scale: 2),
           DataZaplaty = c.DateTime(nullable: false),
           })
           .PrimaryKey(t => t.Id);

           CreateTable("dbo.FakturaSzczegoly",c => new
            {
                   Id = c.Int(nullable: false, identity: true),
                   Ilosc = c.Int(nullable: false),
                   WartoscNetto = c.Decimal(nullable: false, precision: 18, scale: 2),
                   WartoscBrutto = c.Decimal(nullable: false, precision: 18, scale: 2),
                   WartoscVat = c.Decimal(nullable: false, precision: 18, scale: 2),
                   StawkaVat = c.Decimal(nullable: false, precision: 18, scale: 2),
                   PKWIU = c.String(),
             })
             .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.FakturaSzczegoly");
            DropTable("dbo.Faktura");

            CreateTable("dbo.Faktura", c => new
            {
                Id = c.Int(nullable: false, identity: true),
                Numer = c.String(),
                DataWystawienia = c.DateTime(nullable: false),
                DataSprzedazy = c.DateTime(nullable: false),
                WalutaKurs = c.Decimal(nullable: false, precision: 18, scale: 2),
                DataZaplaty = c.DateTime(nullable: false),
            })
           .PrimaryKey(t => t.Id);

            CreateTable("dbo.FakturaSzczegoly", c => new
            {
                Id = c.Int(nullable: false, identity: true),
                Ilosc = c.Int(nullable: false),
                WartoscNetto = c.Decimal(nullable: false, precision: 18, scale: 2),
                WartoscBrutto = c.Decimal(nullable: false, precision: 18, scale: 2),
                WartoscVat = c.Decimal(nullable: false, precision: 18, scale: 2),
                StawkaVat = c.Decimal(nullable: false, precision: 18, scale: 2),
                PKWIU = c.String(),
            })
             .PrimaryKey(t => t.Id);

            AddColumn("dbo.FakturaSzczegoly", "Produkt_Id", c => c.Int());
            AddColumn("dbo.FakturaSzczegoly", "Faktura_Id", c => c.Int());
            AddColumn("dbo.Faktura", "Klient_Id", c => c.Int());
            AddColumn("dbo.Faktura", "Firma_Id", c => c.Int());
            AddColumn("dbo.Faktura", "Stan", c => c.Boolean(nullable: false));
            AddColumn("dbo.Faktura", "Wystawiajacy", c => c.String());
            AlterColumn("dbo.FakturaSzczegoly", "ilosc", c => c.Double(nullable: false));
            DropColumn("dbo.FakturaSzczegoly", "PKWIU");
            DropColumn("dbo.FakturaSzczegoly", "StawkaVat");
            DropColumn("dbo.FakturaSzczegoly", "WartoscVat");
            DropColumn("dbo.FakturaSzczegoly", "WartoscBrutto");
            DropColumn("dbo.FakturaSzczegoly", "WartoscNetto");
            DropColumn("dbo.Faktura", "DataZaplaty");
            DropColumn("dbo.Faktura", "WalutaKurs");
            DropColumn("dbo.Faktura", "DataSprzedazy");
            CreateIndex("dbo.FakturaSzczegoly", "Produkt_Id");
            CreateIndex("dbo.FakturaSzczegoly", "Faktura_Id");
            CreateIndex("dbo.Faktura", "Klient_Id");
            CreateIndex("dbo.Faktura", "Firma_Id");
            AddForeignKey("dbo.FakturaSzczegoly", "Produkt_Id", "dbo.Produkt", "Id");
            AddForeignKey("dbo.FakturaSzczegoly", "Faktura_Id", "dbo.Faktura", "Id");
            AddForeignKey("dbo.Faktura", "Klient_Id", "dbo.Klient", "Id");
            AddForeignKey("dbo.Faktura", "Firma_Id", "dbo.Firma", "Id");
        }
    }
}
