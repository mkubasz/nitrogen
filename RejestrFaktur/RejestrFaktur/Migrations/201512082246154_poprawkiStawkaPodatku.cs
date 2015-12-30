namespace RejestrFaktur.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class poprawkiStawkaPodatku : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StawkaPodatku", "NazwaStawki", c => c.String(nullable: false, maxLength: 120));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StawkaPodatku", "NazwaStawki", c => c.String(nullable: false));
        }
    }
}
