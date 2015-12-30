using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RejestrFaktur.Models;
using RejestrFaktur.utils.HelpersExtensions;

namespace RejestrFaktur.Tests.Utils.HelpersExtensions
{
    [TestClass]
    public class HelperyTest
    {
        [TestMethod]
        public void TestHelpery()
        {
            HtmlHelper helper = new HtmlHelper(new ViewContext(),new ViewPage());
            JednostkaMiary jm = default(JednostkaMiary);
            object htmlAttributes = null;
            MvcHtmlString htmlString = helper.ListaAtrybuty("test",jm);
            string str = htmlString.ToString();
            Assert.AreEqual("",str);
            htmlString = helper.ListaAtrybuty("test", jm,htmlAttributes);
            str = htmlString.ToString();
            Assert.AreEqual("", str);
            StringBuilder sBuilder = new StringBuilder("");
            jm = new JednostkaMiary();
            htmlString = helper.ListaAtrybuty("test", jm);
            sBuilder.AppendFormat("<select name =\"{0}\">{1}</select>", "test", HelpersUtils.WypiszAtrybutyObiektu(jm));
            Assert.AreEqual(sBuilder.ToString(),htmlString.ToString());

        }


    }
}
