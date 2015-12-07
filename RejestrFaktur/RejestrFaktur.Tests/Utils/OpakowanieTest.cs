using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RejestrFaktur.DAL;
using RejestrFaktur.utils;
using RejestrFaktur.Models;

namespace RejestrFaktur.Tests.Utils
{
    [TestClass]
    public class OpakowanieTest
    {
        [TestMethod]
        public void TestUtworzenieObiektu()
        {
            //testuje tworzenie obiektu opakowujacego 
            try
            {
                RejestrFakturContext dbcontext = new RejestrFakturContext();
                Assert.IsTrue(true);

                JednostkiMiaryOperacje jedOper = new JednostkiMiaryOperacje();
                Assert.IsTrue(true);

                Opakowanie<JednostkaMiary> opakow = new Opakowanie<JednostkaMiary>(jedOper, dbcontext);
                Assert.IsTrue(true);
                Opakowanie<JednostkaMiary> opakow2 = new Opakowanie<JednostkaMiary>(new JednostkiMiaryOperacje(), new RejestrFakturContext());
                Assert.IsTrue(true);
            }

            catch
            {
                Assert.Fail();
            }

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
