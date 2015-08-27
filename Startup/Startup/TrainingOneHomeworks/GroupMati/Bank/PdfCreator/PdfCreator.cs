using System;
using iTextSharp;
using  iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
namespace Startup.TrainingOneHomeworks.Mati.PdfCreator
{

    public class PdfCreator : IPdfCreator
    {
        private string path = @"M:\{0}.pdf";
        private const string _przelewBlad = "Przelew nie zostal wykonany";
        private const string _przelew = "Przelew zostal wykonany";

        public PdfCreator(string nameBank)
        {
            TryCreatePdf("Alior");

        }

        public bool TryCreatePdf(string nameBank)
        {
            try
            {
                using (FileStream file = new FileStream(String.Format(path,nameBank), FileMode.Create))
                {
                    Document document = new Document(PageSize.A7);
                    PdfWriter writer = PdfWriter.GetInstance(document, file);
                    /// Create metadate pdf file
                    document.AddAuthor("");
                    document.AddLanguage("pl");
                    document.AddSubject("Payment transaction");
                    document.AddTitle("Transaction");
                    /// Create text in pdf file
                    document.Open();
                    document.Add(new Paragraph(_przelew+"\n"));
                    document.Add(new Paragraph(String.Format("Bank {0}: zaprasza\n",nameBank)));
                    document.Add(new Paragraph(DateTime.Now.ToString()));
                    document.Close();
                    writer.Close();
                    file.Close();
                    return true;
                }
            }
            catch (SystemException ex)
            {
                return false;
            }

        }

    }
}