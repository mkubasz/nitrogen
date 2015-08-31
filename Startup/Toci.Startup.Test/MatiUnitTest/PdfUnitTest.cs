using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Startup.TrainingOneHomeworks.GroupMati.Bank.PdfCreator;

namespace Toci.Startup.Test.MatiUnitTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void IsPdfDocumentCreated()
        {
            PdfCreator pdf = new PdfCreator("fdf");
            FileStream file = new FileStream(@"M:\Alior.pdf", FileMode.Open);
            Assert.IsNotNull(file);
        }
    }
}
