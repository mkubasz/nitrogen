using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RejestrFaktur.Models;
using RejestrFaktur.utils.atrybuty;

namespace RejestrFaktur.Tests.Utils.Atrybuty
{
    [TestClass]
    public class TestAtrybutyKlas
    {
        [TestMethod]
        public void TestJednostkiMiary()
        {
            JednostkaMiary jm1 = new JednostkaMiary { Id = 1, NazwaJednostki = "metr", SymbolJednostki = "m" };
            List<string> listaStr = CzytaczAnotacji.WypiszWszystkieAtrybutyNazwa(StanAtr.WLICZAC, jm1);
            Assert.AreEqual(listaStr.Count, 1);
            Assert.AreEqual(listaStr[0], "Nazwa jednostki miary");

            List<DodatkoweAtrybuty> listaDA = CzytaczAnotacji.WypiszWszystkieAtrybuty(StanAtr.WLICZAC, jm1);
            Assert.AreEqual(listaDA.Count, 1);
            Assert.AreEqual(listaDA[0].Dodatkowy, "nazwa");

            JednostkaMiary jm2 = null;
            listaDA = CzytaczAnotacji.WypiszWszystkieAtrybuty(StanAtr.WLICZAC, jm2);
            Assert.IsNull(listaDA);

        }

    }
}
