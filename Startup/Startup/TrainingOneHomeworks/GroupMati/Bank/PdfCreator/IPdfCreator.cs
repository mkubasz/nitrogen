namespace Startup.TrainingOneHomeworks.Mati.PdfCreator
{
    public interface IPdfCreator
    {
        bool TryCreatePdf(string nameBank);
    }
}