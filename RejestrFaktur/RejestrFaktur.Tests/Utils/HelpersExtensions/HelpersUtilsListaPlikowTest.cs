using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RejestrFaktur.utils.HelpersExtensions;

namespace RejestrFaktur.Tests.Utils.HelpersExtensions
{
    [TestClass]
    public class HelpersUtilsListaPlikowTest
    {
        [TestMethod]
        //[DeploymentItem(@"DaneDoTestow", "DaneDoTestow")]
        public void TestJedenPlik()
        {
            string kat = "DaneDoTestow";
            string sciezkaDoPlikow = "TestowyFolder";
            sciezkaDoPlikow = Path.Combine(kat, sciezkaDoPlikow);
            try
            {
                IEnumerable<string> listaPliki = HelpersUtils.WypiszWszystkiePliki(sciezkaDoPlikow);
                Assert.AreEqual(listaPliki.Count(), 1);
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        //[DeploymentItem(@"DaneDoTestow", "DaneDoTestow")]
        public void TestPustyFolder()
        {
            string kat = "DaneDoTestow";
            string sciezkaDoPlikow = "TestowyFolderPusty";
            sciezkaDoPlikow = Path.Combine(kat, sciezkaDoPlikow);
            try
            {
                IEnumerable<string> listaPliki = HelpersUtils.WypiszWszystkiePliki(sciezkaDoPlikow);
                Assert.AreEqual(listaPliki.Count(), 0);
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        //[DeploymentItem(@"DaneDoTestow", "DaneDoTestow")]
        public void TestFolderZGrafikami()
        {
            string kat = "DaneDoTestow";
            string s1 = "costam/plik.jpg";
            Assert.IsTrue(s1.IsPathToImgFile());
            string s2 = "costam/plik.jpg1";
            Assert.IsFalse(s2.IsPathToImgFile());


            string sciezkaDoPlikow = "TestowyRozne";
            sciezkaDoPlikow = Path.Combine(kat, sciezkaDoPlikow);


            try
            {
                IEnumerable<string> listaPliki = HelpersUtils.WypiszPlikiGrafika(sciezkaDoPlikow);
                Assert.AreEqual(listaPliki.Count(), 4);
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

    }
}
