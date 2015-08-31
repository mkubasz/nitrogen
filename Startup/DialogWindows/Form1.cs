using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using Startup.TrainingOneHomeworks.Mati.PdfCreator;
using Startup.TrainingOneHomeworks.Mati;


namespace DialogWindows
{
    public partial class Form1 : Form
    {
        StreamReader fileBanksLists = new StreamReader(@"../../../../Startup\TrainingOneHomeworks\GroupMati\Bank\GeneratorClass\BanksLists.txt");
        
        // From <ClickButt> -> PdfConnector PdfCreatora <- PdfCreator(naemBank,Bodytext)
        // Form <Image> <- PdfConnector -- tworzyć pdf |
        public Form1() 
        {
            while (!fileBanksLists.EndOfStream)
            {
                    InitializeComponent();
            
                     using (FileStream file = new FileStream(String.Format(path, nameBank), FileMode.Create))
                    {

                        Document document = new Document(PageSize.A7);
                        PdfWriter writer = PdfWriter.GetInstance(document, file);
              
                        /// Create metadate pdf file
                        document.AddAuthor(nameBank);
                        document.AddLanguage("pl");
                        document.AddSubject("Payment transaction");
                        document.AddTitle("Transaction");
                        document.AddKeywords("OutcomingNumber :" + OutcomingNumber);
                        document.AddKeywords("IncomingNumber :" + IncomingNumber);
                        /// Create text in pdf file
                        document.Open();
                        document.Add(new Paragraph(_przelew + "\n"));
                        document.Add(new Paragraph(String.Format("Bank {0}: zaprasza\n", nameBank)));
                        document.Add(new Paragraph(DateTime.Now.ToString()));
                        document.Close();
                        writer.Close();
                        file.Close();
                    }
            }
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            //SaveFileDialog dialog = new SaveFileDialog();
            //dialog.Filter = "pdf|*.pdf";
            //dialog.ShowDialog();
            //if (dialog.FileName != "")
            //    PDF.(dialog.FileName);
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = nameBank;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
}
