using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homeworks.Igor;
using Homeworks.Igor.DataLoadSystem;
using Homeworks.Igor.OperationSystem;

namespace IgorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //var klient = new ClientOperator(new TxtDataLoader("C:\\Users\\Igor\\Documents\\nitrogen\\Homeworks\\Homeworks\\Igor\\TXTDocuments\\Cities.txt"));
            var klient = new ClientOperator(new XmlDataLoader("C:\\Users\\Igor\\Documents\\nitrogen\\Homeworks\\Homeworks\\Igor\\XMLDocuments\\Cities.xml"));
            var a = klient.GetSetResult(new RemoveRepeat());
            var a2 = klient.GetResult(new FindCity("Zielona Góra"));
            var a3 = klient.GetResult(new FindCityAtMLetter('M'));
            var a4 = klient.GetResult(new FindAllCitiesAtLetter('M'));
            var a5 = klient.GetResult(new ComputeCitiesAtLetter('L'));
            var a6 = klient.GetResult(new RemoveAllCitiesAtName("Opole"));
            klient.AddData("Moje Super Miasto");
        }
    }
}
