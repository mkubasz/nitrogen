namespace TOCI_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerLastName = c.String(),
                        CustomerFirstName = c.String(),
                        CustomerLoginName = c.String(),
                        CustomerGender = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderStatusCode = c.String(),
                        DateOrderPlaced = c.DateTime(nullable: false),
                        OrderDetails = c.String(),
                        Customer_CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customer", t => t.Customer_CustomerId)
                .Index(t => t.Customer_CustomerId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ArtistId = c.Int(nullable: false),
                        ProductPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "Customer_CustomerId", "dbo.Customer");
            DropIndex("dbo.Order", new[] { "Customer_CustomerId" });
            DropTable("dbo.Product");
            DropTable("dbo.Order");
            DropTable("dbo.Customer");
        }
    }
}
