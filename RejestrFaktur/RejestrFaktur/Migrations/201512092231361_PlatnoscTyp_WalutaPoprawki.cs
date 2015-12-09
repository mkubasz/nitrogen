namespace RejestrFaktur.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlatnoscTyp_WalutaPoprawki : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PlatnoscTyp", "Nazwa", c => c.String(nullable: false, maxLength: 55));
            AlterColumn("dbo.PlatnoscTyp", "Opis", c => c.String(maxLength: 128));
            AlterColumn("dbo.Waluta", "Nazwa", c => c.String(nullable: false, maxLength: 65));
            AlterColumn("dbo.Waluta", "Symbol", c => c.String(nullable: false, maxLength: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Waluta", "Symbol", c => c.String(nullable: false));
            AlterColumn("dbo.Waluta", "Nazwa", c => c.String(nullable: false));
            AlterColumn("dbo.PlatnoscTyp", "Opis", c => c.String());
            AlterColumn("dbo.PlatnoscTyp", "Nazwa", c => c.String(nullable: false));
        }
    }
}
