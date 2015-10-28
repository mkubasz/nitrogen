namespace Repozytorium.Models.ViewModel
{
    public class FotoModelView
    {
        public int FotoId { get; set; }
        public int FotoSize { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }

        public string FotoData { get; set; }
        public string FotoMiniatureData { get; set; }
    }
}