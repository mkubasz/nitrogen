using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RejestrFaktur.Models;
using RejestrFaktur.utils.HelpersExtensions;
using RejestrFaktur.utils.pozostale;

namespace RejestrFaktur.Tests.Utils.HelpersExtensions
{
    [TestClass]
    public class HelpersUtilsTest
    {
        [TestMethod]
        public void TestWyliczHtmlAttributes()
        {
            object htmlAttributes = null;
            Assert.AreEqual("", HelpersUtils.WyliczHtmlAttributes(htmlAttributes));

            htmlAttributes = new {};
            Assert.AreEqual(" ",HelpersUtils.WyliczHtmlAttributes(htmlAttributes));

            htmlAttributes = new {
                @class = "btn" };
            Assert.IsTrue(HelpersUtils.WyliczHtmlAttributes(htmlAttributes).Contains("class=\"btn\""));

            htmlAttributes = new
            {
                @class = "btn-Xx"
            };
            Assert.IsTrue(HelpersUtils.WyliczHtmlAttributes(htmlAttributes).Contains("class=\"btn-Xx\""));

            htmlAttributes = new
            {
                @class = "btn-Xx",
                target ="_blank"
            };
            Assert.AreEqual(HelpersUtils.WyliczHtmlAttributes(htmlAttributes)," class=\"btn-Xx\" target=\"_blank\" ");
        }

        [TestMethod]
        public void TestWypiszAtrybutyObiektu()
        {
            JednostkaMiary jm = null;
            Assert.AreEqual("",HelpersUtils.WypiszAtrybutyObiektu(jm));
            jm = new JednostkaMiary();
            StringBuilder sBuilder = new StringBuilder("");
            //[DodatkoweAtrybuty("Nazwa jednostki miary", StanAtr.WLICZAC, Dodatkowy = "nazwa")]
            sBuilder.AppendFormat("<option value =\"{0}\">{1}</option>", "nazwa", "Nazwa jednostki miary");
            Assert.AreEqual(sBuilder.ToString(), HelpersUtils.WypiszAtrybutyObiektu(jm));

            sBuilder = new StringBuilder("");
            sBuilder.AppendFormat("<option value =\"{0}\">{1}</option>", Stale.WSZYSTKIE, Stale.WSZYSTKIE);
            sBuilder.AppendFormat("<option value =\"{0}\">{1}</option>", "nazwa", "Nazwa jednostki miary");
            Assert.AreEqual(sBuilder.ToString(), HelpersUtils.WypiszAtrybutyObiektu(jm,true));

        }

    }
}
