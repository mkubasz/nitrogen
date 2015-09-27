using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homeworks.Igor;
using Homeworks.Igor.DataLoadSystem;

namespace IgorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //var klient = new ClientOperator(new TxtDataLoader("C:\\Users\\Igor\\Documents\\nitrogen\\Homeworks\\Homeworks\\Igor\\TXTDocuments\\Cities.txt"));
            var klient = new CityClientOperator(new XmlDataLoader("C:\\Users\\Igor\\Documents\\nitrogen\\Homeworks\\Homeworks\\Igor\\XMLDocuments\\Cities.xml"));
            klient.RemoveRepeat();
            var t1 = klient.FindCity("Zielona Góra");
            var t2 = klient.FindOneCityAtLetter('M');
            var t3 = klient.FindCitiesAtLetter('M');
            var t4 = klient.ComputeCitiesAtLetter('L');
            klient.RemoveAllCitiesWithName("Opole");
            klient.AddData("Moje Super Miasto");
        }
    }
}
