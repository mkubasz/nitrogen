using System.ComponentModel;

namespace SphynxWeb.Models.ViewModel
{
    public class FotoModelView
    {
        public int FotoId { get; set; }
        public int FotoSize { get; set; }
         [DisplayName("Opis")]
        public string Description { get; set; }
          [DisplayName("Nazwa")]
        public string FileName { get; set; }

        public string FotoData { get; set; }
        public string FotoMiniatureData { get; set; }
    }
}