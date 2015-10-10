using System.ComponentModel.DataAnnotations;

namespace Repozytorium.Models
{
    public class BlogModel
    {
        [Key]
        public int PostId { get; set; }
        [MaxLength(450, ErrorMessage = "Your pust must be max {0} character long"), MinLength(5)] 
        public string Post { get; set; }
        System.DateTime DataDodania { get; set; }
    }
}