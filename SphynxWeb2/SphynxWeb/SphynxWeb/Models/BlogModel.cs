using System;
using System.ComponentModel.DataAnnotations;

namespace SphynxWeb.Models
{
    public class BlogModel
    {
        [Key]
        public int PostId { get; set; }
        [MaxLength(4000, ErrorMessage = "Your pust must be max {0} character long"), MinLength(5)] 
        [DataType(DataType.MultilineText)]
        public string Post { get; set; }
        [MaxLength(4000, ErrorMessage = "Your pust must be max {0} character long"), MinLength(5)]
        public string Name { get; set; }
        public bool ShowOnStartPage { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AddDate { get; set; }
    }
}
