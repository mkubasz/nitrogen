using System.ComponentModel.DataAnnotations;
using System.Web.UI.HtmlControls;

namespace TeamOfCode.Models
{
    public class EmailFormModel
    {
        [Required, Display(Name = "Your name")]
        public string FromName { get; set; }
        [Required, Display(Name = "Your email"), EmailAddress]
        public string FromEmail { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; } 
    }
}