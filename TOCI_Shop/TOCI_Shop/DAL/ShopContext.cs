using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TOCI_Shop.Models;

namespace TOCI_Shop.DAL
{
    public class ShopContext : DbContext
    {
        public ShopContext() : base("ShopContext")
        {
            Database.SetInitializer<ShopContext>(new ShopInitializer());
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}