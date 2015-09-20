using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExceptionTranslator;

namespace ExceptionTranslatorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ExceptionTran tran = new ExceptionTran(ExceptionsPack.FileNotExist);
            Assert.IsTrue(tran.Message=="Plik nie istnieje." ? true : false);
        }
    }
}
