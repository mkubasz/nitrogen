using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Startup.TrainingOneHomeworks.AndzejC.Banki;

namespace Toci.Startup.Test.AndzejC
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var bank = new BankIdList();           
            Assert.AreEqual(bank.GetElement("1010"),"Narodowy Bank Polski");
        }
    }
}
