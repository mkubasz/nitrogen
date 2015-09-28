namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _28092015 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rozwiazanie", "Uzytkownik_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Zadanie", "Uzytkownik_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Rozwiazanie", new[] { "Uzytkownik_Id" });
            DropIndex("dbo.Zadanie", new[] { "Uzytkownik_Id" });
            AddColumn("dbo.Rozwiazanie", "Uzytkownik_Id1", c => c.String(maxLength: 128));
            AddColumn("dbo.Zadanie", "Uzytkownik_Id1", c => c.String(maxLength: 128));
            AlterColumn("dbo.Rozwiazanie", "Uzytkownik_Id", c => c.String());
            AlterColumn("dbo.Zadanie", "Uzytkownik_Id", c => c.String());
            CreateIndex("dbo.Rozwiazanie", "Uzytkownik_Id1");
            CreateIndex("dbo.Zadanie", "Uzytkownik_Id1");
            AddForeignKey("dbo.Rozwiazanie", "Uzytkownik_Id1", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Zadanie", "Uzytkownik_Id1", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Rozwiazanie", "UzytkownikId");
            DropColumn("dbo.Zadanie", "UzytkownikId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Zadanie", "UzytkownikId", c => c.Int(nullable: false));
            AddColumn("dbo.Rozwiazanie", "UzytkownikId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Zadanie", "Uzytkownik_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rozwiazanie", "Uzytkownik_Id1", "dbo.AspNetUsers");
            DropIndex("dbo.Zadanie", new[] { "Uzytkownik_Id1" });
            DropIndex("dbo.Rozwiazanie", new[] { "Uzytkownik_Id1" });
            AlterColumn("dbo.Zadanie", "Uzytkownik_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Rozwiazanie", "Uzytkownik_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Zadanie", "Uzytkownik_Id1");
            DropColumn("dbo.Rozwiazanie", "Uzytkownik_Id1");
            CreateIndex("dbo.Zadanie", "Uzytkownik_Id");
            CreateIndex("dbo.Rozwiazanie", "Uzytkownik_Id");
            AddForeignKey("dbo.Zadanie", "Uzytkownik_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Rozwiazanie", "Uzytkownik_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
