using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SphynxWeb.Models
{
    public class FotoModel
    {    
        [Key]
        public int FotoId { get; set; }
        public int FotoSize { get; set; }
        [DisplayName("Opis")]
        public string Description { get; set; }
         [DisplayName("Nazwa")]
        public string FileName { get; set; }
        public byte[] FotoData { get; set; }

        public byte[] FotoMiniatureData { get; set; }

    }
}