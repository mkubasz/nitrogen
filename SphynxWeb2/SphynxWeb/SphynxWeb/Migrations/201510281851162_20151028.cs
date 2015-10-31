using System.Data.Entity.Migrations;

namespace SphynxWeb.Migrations
{
    public partial class _20151028 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogModel", "Category", c => c.String());
            AddColumn("dbo.BlogModel", "ShowOnStartPage", c => c.Boolean(nullable: false));
            AddColumn("dbo.BlogModel", "AddDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlogModel", "AddDate");
            DropColumn("dbo.BlogModel", "ShowOnStartPage");
            DropColumn("dbo.BlogModel", "Category");
        }
    }
}
