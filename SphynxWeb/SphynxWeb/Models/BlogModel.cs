using System;
using System.ComponentModel.DataAnnotations;

namespace SphynxWeb.Models
{
    public class BlogModel
    {
        public int PostID { get; set; }
        public string Post { get; set; }
        System.DateTime DataDodania { get; set; }
    }
}