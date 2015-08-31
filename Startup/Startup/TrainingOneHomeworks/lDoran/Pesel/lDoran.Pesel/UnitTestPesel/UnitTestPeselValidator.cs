using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using lDoran.Pesel;

namespace UnitTestPesel
{
    [TestClass]
    public class UnitTestPeselValidator
    {
        [TestMethod]
        public void Validate()
        {
            Assert.IsFalse(PeselValidator.Validate("1234567890"));
            // Here you should put correctly pesel number
            // Assert.IsTrue(PeselValidator.Validate(""));
        }
    }
}
