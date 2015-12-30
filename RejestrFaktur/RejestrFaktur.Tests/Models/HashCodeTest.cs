using Microsoft.VisualStudio.TestTools.UnitTesting;
using RejestrFaktur.Models;

namespace RejestrFaktur.Tests.Models
{
    [TestClass]
    public class HashCodeTest
    {
        [TestMethod]
        public void TestHashValue()
        {
            JednostkaMiary jm = new JednostkaMiary();
            int i = jm.GetHashCode();
            Assert.AreEqual(0, i);

            JednostkaMiary jm1 = new JednostkaMiary { Id = 1, NazwaJednostki = "Jakaś nazwa", SymbolJednostki = "Symbol" };
            JednostkaMiary jm2 = new JednostkaMiary { Id = 1, NazwaJednostki = "Jakaś nazwa", SymbolJednostki = "Symbol" };

            Assert.AreEqual(jm1.GetHashCode(), jm2.GetHashCode());
        }
    }
}
