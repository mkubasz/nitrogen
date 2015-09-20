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
            var test = new ExceptionFactory();
            Assert.IsTrue(test.getElement(0) != null ? true : false);
        }
    }
}
