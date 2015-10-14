﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Repository.Models;

namespace Repository.DAL
{
    public class ShopContext : DbContext
    {
        public ShopContext() : base("ShopContext")
        {
            
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