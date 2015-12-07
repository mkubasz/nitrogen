using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using RejestrFaktur.utils;
using RejestrFaktur.Models;
using System.Collections.Generic;
using System.Reflection;

namespace RejestrFaktur.Tests.Models
{
    [TestClass]
    public class TestAtrybutyKlas
    {
        [TestMethod]
        public void TestJednostkiMiary()
        {
            JednostkaMiary jm1 = new JednostkaMiary { Id = 1, NazwaJednostki = "metr", SymbolJednostki = "m" };
            List<string> listaStr = CzytaczAnotacji.WypiszWszystkieAtrubutyNazwa(StanAtr.WLICZAC, jm1);
            Assert.AreEqual(listaStr.Count, 1);
            Assert.AreEqual(listaStr[0], "Nazwa jednostki miary");

            List<DodatkoweAtrybuty> listaDA = CzytaczAnotacji.WypiszWszystkieAtrybuty(StanAtr.WLICZAC, jm1);
            Assert.AreEqual(listaDA.Count, 1);
            Assert.AreEqual(listaDA[0].Dodatkowy, "nazwa");

        }
    }
}
