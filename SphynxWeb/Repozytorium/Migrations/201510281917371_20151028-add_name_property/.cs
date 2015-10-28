namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20151028add_name_property : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogModel", "Name", c => c.String());
            DropColumn("dbo.BlogModel", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlogModel", "Category", c => c.String());
            DropColumn("dbo.BlogModel", "Name");
        }
    }
}
