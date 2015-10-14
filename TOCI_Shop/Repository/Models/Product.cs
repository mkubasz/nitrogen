using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int ArtistId { get; set; }
        public double ProductPrice { get; set; }
    }
}