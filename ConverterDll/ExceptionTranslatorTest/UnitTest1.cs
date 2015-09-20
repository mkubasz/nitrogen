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
            ExceptionTran tran = new ExceptionTran(ExceptionsPack.FileNotFound); // po poprawie działa również throw new ExceptionTran(ExceptionsPack.FileNotExist);
            Assert.IsTrue(tran.Message.Equals("Nie znaleziono pliku.") ? true : false);
        }
    }
}
