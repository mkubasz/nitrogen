using System;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RejestrFaktur.DAL;


namespace RejestrFaktur.Tests.Utils
{
    /// <summary>
    /// Summary description for DodatkoweTesty
    /// </summary>
    [TestClass]
    public class DodatkoweTesty
    {
        [TestMethod]
        public void TestXElement()
        {
            String s = "<span ></span>";
            XElement elem = XElement.Parse(s);
            Assert.IsFalse(elem.HasElements);
            Assert.IsFalse(elem.HasAttributes);
        }

        [TestMethod]
        public void TestCzyDzialaPolaczeniezDB()
        {
            //sprawdza czy polaczenie jest w ogole realizowane
            try
            {
                RejestrFakturContext dbcontext = new RejestrFakturContext();
                foreach (var jednostkaMiary in dbcontext.JednostkiMiar)
                {
                    Console.WriteLine("ID:{0}, Nazwa: {1}", jednostkaMiary.Id, jednostkaMiary.NazwaJednostki);
                }

            }

            catch (Exception e)
            {
                e.ToString();
                Assert.Fail();
            }

        }
    }


}
