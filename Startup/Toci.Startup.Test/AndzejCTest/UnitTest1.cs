using Microsoft.VisualStudio.TestTools.UnitTesting;
using Startup.TrainingOneHomeworks.AndzejC.Pesel;

namespace Toci.Startup.Test.AndzejCTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var newPesel = new PeselValidator();
            Assert.IsTrue(newPesel.IsValidatePesel("94120807274"));
            Assert.IsTrue(newPesel.IsValidatePesel("93122305155"));
            Assert.IsFalse(newPesel.IsValidatePesel("94120807275"));

        }
    }
}
