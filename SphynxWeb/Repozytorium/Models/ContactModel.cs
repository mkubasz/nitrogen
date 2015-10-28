using System.ComponentModel.DataAnnotations;

namespace Repozytorium.Models
{
    public class ContactModel
    {
        [Required, Display(Name = "Your name")]
        public string FromName { get; set; }
        [Required, Display(Name = "Your email"), EmailAddress]
        public string FromEmail { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }  
    }
}