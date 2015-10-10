using System.ComponentModel.DataAnnotations;
using System.Web;

namespace SphynxWeb.Models
{
    public class FotoModel
    {    
        public int FotoID { get; set; }
        public int FotoSize { get; set; }
        public string FileName { get; set; }
        public byte[] FotoData { get; set; }
        [Required(ErrorMessage = "Please select file")]
        public HttpPostedFileBase File { get; set; }
        public byte[] FotoMIniatureData { get; set; }

    }
}