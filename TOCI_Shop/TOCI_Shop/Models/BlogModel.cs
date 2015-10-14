
using System.Data.Entity; 

 
namespace TOCI_Shop.Models
{ 
    public class BlogContext : DbContext 
    { 
        public DbSet<Blog> Blogs { get; set; } 
    } 
 
    public class Blog 
    { 
        public int BlogId { get; set; } 
        public string Name { get; set; } 
    } 
}

