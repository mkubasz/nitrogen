using Microsoft.VisualStudio.TestTools.UnitTesting;
using RejestrFaktur.DAL;
using RejestrFaktur.Models;
using RejestrFaktur.utils.AbstrKlasyInterfejsyGenerics;
using RejestrFaktur.utils.impl.JednostkiMiary;

namespace RejestrFaktur.Tests.Utils.AbstrKlasyInterfejsyGenerics
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

    }
}
