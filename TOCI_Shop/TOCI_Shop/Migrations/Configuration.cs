using System.Collections.Generic;
using TOCI_Shop.DAL;
using TOCI_Shop.Models;

namespace TOCI_Shop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TOCI_Shop.DAL.ShopContext context)
        {
            var orders = new List<Order>
            {
                new Order
                {
                    DateOrderPlaced = DateTime.Parse("2013-07-07"),
                    OrderDetails = "some Order details here",
                    OrderStatusCode = "delivering"

                },
                new Order
                {
                    DateOrderPlaced = DateTime.Parse("2014-08-09"),
                    OrderDetails = "some Order details here",
                    OrderStatusCode = "delivering"

                },
                new Order
                {
                    DateOrderPlaced = DateTime.Parse("2015-01-02"),
                    OrderDetails = "some Order details here",
                    OrderStatusCode = "delivering"

                }
            };
            orders.ForEach(s => context.Orders.Add(s));
            
            var products = new List<Product>
            {
                new Product
                {
                    ProductPrice = 12.90,
                    ProductName = "Paint of window",
                },
                new Product
                {
                    ProductPrice = 17.99,
                    ProductName = "Paint of tiger",
                },
                new Product
                {
                    ProductPrice = 99.10,
                    ProductName = "paint of cat",
                },
            };
            products.ForEach(s => context.Products.Add(s));
            context.SaveChanges();


            var customers = new List<Customer>
            {
                new Customer
                {
                    CustomerFirstName = "Max",
                    CustomerLastName = "Payne"
                },
                new Customer
                {
                    CustomerFirstName = "Robin",
                    CustomerLastName = "Hood"
                },
                new Customer
                {
                    CustomerFirstName = "James",
                    CustomerLastName = "Bond"
                },
                new Customer
                {
                    CustomerFirstName = "Lara",
                    CustomerLastName = "Croft"
                },
//                new Customer
//                {
//                    CustomerFirstName = "Bill",
//                    CustomerLastName = "Clinton"
//                },
            };
            customers.ForEach(s => context.Customers.Add(s));
            context.SaveChanges();
        }
    }
}