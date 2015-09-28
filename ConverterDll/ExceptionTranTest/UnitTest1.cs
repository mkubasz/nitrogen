using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExceptionTranslator;

namespace ExceptionTranTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var test = new ExceptionTran(ExceptionsPack.FileNotExist);
            Assert.AreEqual(test.Message, "Plik nie istnieje.");
        }
    }
}
