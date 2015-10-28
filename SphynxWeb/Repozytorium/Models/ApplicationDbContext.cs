using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Repozytorium.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.


    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
   public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<FotoModel> Fotos { get; set; }
        public IDbSet<BlogModel> Posts { get; set; }

        //public System.Data.Entity.DbSet<Repozytorium.Models.BlogModel> BlogModels { get; set; }

       //public System.Data.Entity.DbSet<Repozytorium.Models.FotoModel> FotoModels { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        
        }
    }
}