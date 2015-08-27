using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Startup.TrainingOneHomeworks.IwonaM.Pesel;

namespace Toci.Startup.Test.IwonaM
{
    [TestClass]
    public class UnitTestPesel
    {
        [TestMethod]
        public void PeselValidator()
        {
            Assert.IsFalse(Pesel.PeselValidator("1234"));
            Assert.IsFalse(Pesel.PeselValidator("123fdsfcd333"));
            Assert.IsFalse(Pesel.PeselValidator("1234567898765435677"));
            Assert.IsFalse(Pesel.PeselValidator("12982912345"));
            Assert.IsFalse(Pesel.PeselValidator("12333467865"));
            Assert.IsFalse(Pesel.PeselValidator("1234"));

            Assert.IsTrue(Pesel.PeselValidator("87052514228"));
        }
    }
}
