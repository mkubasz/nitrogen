using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RejestrFaktur.utils;
using RejestrFaktur.Models;
using RejestrFaktur.DAL;
using System.Collections.Generic;
using System.Linq;
using RejestrFaktur.utils.impl;

namespace RejestrFaktur.Tests.Utils
{
    [TestClass]
    public class OpakowanieTest
    {
        [TestMethod]
        public void TestUtwworzenieObiektu()
        {
            try
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

                OpakowanieJednostkiFactory ojFabryka = new OpakowanieJednostkiFactory();
                IOperacjeOpakowanie<JednostkaMiary> iop = ojFabryka.create();
                Opakowanie<JednostkaMiary> opJM = new Opakowanie<JednostkaMiary>(lista, iop);
                //udało się stworzyć obiekt
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestMetodZnajdzPoIdiUstawDoEdycji()
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

            Opakowanie<JednostkaMiary> opJM = new Opakowanie<JednostkaMiary>(lista, new OpakowanieJednostkiFactory().create());

            JednostkaMiary jmTemp = opJM.ZnajdzPoId(2);
            Assert.AreEqual<JednostkaMiary>(jm2, jmTemp);

            jmTemp = opJM.ZnajdzPoId(5);
            Assert.AreEqual<JednostkaMiary>(default(JednostkaMiary), jmTemp);

            jmTemp = opJM.ZnajdzPoId(-5);
            Assert.AreEqual<JednostkaMiary>(null, jmTemp);

            //poza zasięgiem 
            Assert.IsFalse(opJM.ustawDoEdycji(5));
            Assert.AreEqual<JednostkaMiary>(default(JednostkaMiary), opJM.Edytowany);
            Assert.AreEqual<Stany>(Stany.PRZEGLADANIE, opJM.StanObiektu);

            //zły indeks 
            Assert.IsFalse(opJM.ustawDoEdycji(-1));
            Assert.AreEqual<JednostkaMiary>(default(JednostkaMiary), opJM.Edytowany);
            Assert.AreEqual<Stany>(Stany.PRZEGLADANIE, opJM.StanObiektu);

            //tutaj prawidłowo
            Assert.IsTrue(opJM.ustawDoEdycji(3));
            Assert.AreEqual<JednostkaMiary>(jm3, opJM.Edytowany);
            Assert.AreEqual<Stany>(Stany.DO_EDYCJI, opJM.StanObiektu);


        }

        [TestMethod]
        public void TestCostam()
        {
            //Sprawdzenie co się dzieje jeśli są dwa oiekty o takich samych Id
            List<JednostkaMiary> lista = new List<JednostkaMiary>();
            JednostkaMiary jm1 = new JednostkaMiary { Id = 1, NazwaJednostki = "metr", SymbolJednostki = "m" };
            JednostkaMiary jm2 = new JednostkaMiary { Id = 2, NazwaJednostki = "kilogram", SymbolJednostki = "kg" };
            JednostkaMiary jm3 = new JednostkaMiary { Id = 3, NazwaJednostki = "sztuka", SymbolJednostki = "szt" };
            JednostkaMiary jm4 = new JednostkaMiary { Id = 4, NazwaJednostki = "litr", SymbolJednostki = "l" };
            lista.Add(jm1);
            lista.Add(jm2);
            lista.Add(jm2);
            lista.Add(jm3);
            lista.Add(jm4);
            Opakowanie<JednostkaMiary> opJM = new Opakowanie<JednostkaMiary>(lista, new OpakowanieJednostkiFactory().create());

            try
            {
                JednostkaMiary jmTemp = opJM.ZnajdzPoId(2);
                Assert.AreEqual<JednostkaMiary>(default(JednostkaMiary), jmTemp);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.Fail();
            }

        }

        [TestMethod]
        public void TestPlatnoscTypKlasa()
        {
            //sprawdzenie czy działa dla innego typu
            List<PlatnoscTyp> lista = new List<PlatnoscTyp>();
            PlatnoscTyp p1 =  new PlatnoscTyp {Id = 1, Nazwa = "Przelew", Opis = "przelew" };
            PlatnoscTyp p2 = new PlatnoscTyp { Id = 2, Nazwa = "Zapłata w kasie", Opis = "zapłata w kasie" };
            PlatnoscTyp p3= new PlatnoscTyp { Id = 3, Nazwa = "Karta kredytowa", Opis = "zapłata kartą kredytową" };

            lista.Add(p1);
            lista.Add(p2);
            lista.Add(p3);
            

            Opakowanie<PlatnoscTyp> opJM = new Opakowanie<PlatnoscTyp>(lista, new OpakowaniePlatnoscTypFactory().create());

            PlatnoscTyp jmTemp = opJM.ZnajdzPoId(2);
            Assert.AreEqual<PlatnoscTyp>(p2, jmTemp);

            jmTemp = opJM.ZnajdzPoId(5);
            Assert.AreEqual<PlatnoscTyp>(default(PlatnoscTyp), jmTemp);

            jmTemp = opJM.ZnajdzPoId(-5);
            Assert.AreEqual<PlatnoscTyp>(null, jmTemp);

            Assert.IsFalse(opJM.ustawDoEdycji(5));
            Assert.AreEqual<PlatnoscTyp>(default(PlatnoscTyp), opJM.Edytowany);
            Assert.AreEqual<Stany>(Stany.PRZEGLADANIE, opJM.StanObiektu);


            Assert.IsFalse(opJM.ustawDoEdycji(-1));
            Assert.AreEqual<PlatnoscTyp>(default(PlatnoscTyp), opJM.Edytowany);
            Assert.AreEqual<Stany>(Stany.PRZEGLADANIE, opJM.StanObiektu);

            Assert.IsTrue(opJM.ustawDoEdycji(3));
            Assert.AreEqual<PlatnoscTyp>(p3, opJM.Edytowany);
            Assert.AreEqual<Stany>(Stany.DO_EDYCJI, opJM.StanObiektu);


        }

    }

}
