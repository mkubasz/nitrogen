using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RejestrFaktur.utils;
using RejestrFaktur.DAL;
using RejestrFaktur.Models;
using System.Collections.Generic;
using System.Linq;

namespace RejestrFaktur.Tests.Utils
{
    [TestClass]
    public class JednostkiMiaryOperacjeTest
    {
        [TestMethod]
        public void TestZaincjalizuj()
        {
            try
            {
                JednostkiMiaryOperacje jmo = new JednostkiMiaryOperacje();
                RejestrFakturContext dbcontext = new RejestrFakturContext();

                IEnumerable<JednostkaMiary> lista = dbcontext.JednostkiMiar.ToList();

                ObiektDoWidoku<JednostkaMiary> odw = new ObiektDoWidoku<JednostkaMiary>();
                jmo.UstawPoczatkowe(odw, dbcontext);

                for (int i = 0; i < lista.Count(); i++)
                {
                    Assert.AreEqual(lista.ElementAt(i), odw.Lista.ElementAt(i));
                }

                Assert.AreEqual(odw.StanObiektu, Stany.PRZEGLADANIE);

                Assert.AreEqual(default(JednostkaMiary), odw.Edytowany);
            }
            catch
            {
                Assert.Fail();
            }
        }
        [TestMethod]
        public void TestWyszukiwanie()
        {
            List<JednostkaMiary> lista = new List<JednostkaMiary>();

            JednostkaMiary jm1 = new JednostkaMiary { Id = 1, NazwaJednostki = "metr", SymbolJednostki = "m" };
            JednostkaMiary jm2 = new JednostkaMiary { Id = 2, NazwaJednostki = "kilogram", SymbolJednostki = "kg" };
            JednostkaMiary jm3 = new JednostkaMiary { Id = 3, NazwaJednostki = "sztuka", SymbolJednostki = "szt" };
            JednostkaMiary jm4 = new JednostkaMiary { Id = 4, NazwaJednostki = "litr", SymbolJednostki = "l" };

            lista.Add(jm1);
            lista.Add(jm2);
            lista.Add(jm3);
            lista.Add(jm4);

            JednostkiMiaryOperacje jmo = new JednostkiMiaryOperacje();
            RejestrFakturContext dbcontext = new RejestrFakturContext();
            ObiektDoWidoku<JednostkaMiary> odw = new ObiektDoWidoku<JednostkaMiary>();

            JednostkaMiary jedZnalezione = jmo.ZnajdzPoId(lista, 1);
            Assert.AreEqual(jedZnalezione, jm1);

            jedZnalezione = jmo.ZnajdzPoId(lista, 4);
            Assert.AreEqual(jedZnalezione, jm4);

            //przypadki z poza zakresu
            jedZnalezione = jmo.ZnajdzPoId(lista, 0);
            Assert.AreEqual(jedZnalezione, default(JednostkaMiary));
            jedZnalezione = jmo.ZnajdzPoId(lista, -1);
            Assert.AreEqual(jedZnalezione, default(JednostkaMiary));
            jedZnalezione = jmo.ZnajdzPoId(lista, 5);
            Assert.AreEqual(jedZnalezione, default(JednostkaMiary));

        }

        [TestMethod]
        public void testUstaw()
        {
            List<JednostkaMiary> lista = new List<JednostkaMiary>();

            JednostkaMiary jm1 = new JednostkaMiary { Id = 1, NazwaJednostki = "metr", SymbolJednostki = "m" };
            JednostkaMiary jm2 = new JednostkaMiary { Id = 2, NazwaJednostki = "kilogram", SymbolJednostki = "kg" };
            JednostkaMiary jm3 = new JednostkaMiary { Id = 3, NazwaJednostki = "sztuka", SymbolJednostki = "szt" };
            JednostkaMiary jm4 = new JednostkaMiary { Id = 4, NazwaJednostki = "litr", SymbolJednostki = "l" };

            lista.Add(jm1);
            lista.Add(jm2);
            lista.Add(jm3);
            lista.Add(jm4);

            ObiektDoWidoku<JednostkaMiary> odw = new ObiektDoWidoku<JednostkaMiary>();
            odw.Lista = lista;

            JednostkiMiaryOperacje jmo = new JednostkiMiaryOperacje();

            Assert.IsTrue(jmo.Ustaw(odw, Stany.DO_EDYCJI, 1));

            Assert.AreEqual(odw.Edytowany, jm1);
            Assert.AreEqual(odw.StanObiektu, Stany.DO_EDYCJI);


            Assert.IsFalse(jmo.Ustaw(odw, Stany.DO_EDYCJI, 5));
            Assert.AreEqual(odw.Edytowany, default(JednostkaMiary));
            Assert.AreEqual(odw.StanObiektu, Stany.PRZEGLADANIE);

        }

        [TestMethod]
        public void testDodajEdytujUsun()
        {
            RejestrFakturContext dbcontext = new RejestrFakturContext();
            JednostkiMiaryOperacje jmo = new JednostkiMiaryOperacje();
            List<JednostkaMiary> lista = dbcontext.JednostkiMiar.ToList();


            //Id jest ignorowane
            JednostkaMiary jm1 = new JednostkaMiary { NazwaJednostki = "jakas jednostka", SymbolJednostki = "jj" };
            int k = jmo.Dodaj(jm1, dbcontext);
            Assert.IsTrue(k > 0);


            lista = dbcontext.JednostkiMiar.ToList();
            JednostkaMiary jmTemp = jmo.ZnajdzPoId(lista, k);

            Assert.AreEqual(jm1.NazwaJednostki, jmTemp.NazwaJednostki);
            Assert.AreEqual(jm1.SymbolJednostki, jmTemp.SymbolJednostki);

            jmTemp.NazwaJednostki = "kilowat";
            jmTemp.SymbolJednostki = "kW";

            jmo.Edytuj(jmTemp, dbcontext);


            JednostkaMiary jmTemp2 = jmo.ZnajdzPoId(lista, k);
            Assert.AreEqual(jmTemp, jmTemp2);


            Assert.IsTrue(jmo.Usun(jmTemp2, dbcontext));
            lista = dbcontext.JednostkiMiar.ToList();
            JednostkaMiary jmTemp3 = jmo.ZnajdzPoId(lista, k);

            Assert.IsNull(jmTemp3);

        }

    }
}
