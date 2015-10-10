using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Repozytorium.Models
{
    public class FotoModel
    {    
        [Key]
        public int FotoId { get; set; }
        public int FotoSize { get; set; }
  
        public string FileName { get; set; }
        public byte[] FotoData { get; set; }

        public byte[] FotoMiniatureData { get; set; }

    }
}