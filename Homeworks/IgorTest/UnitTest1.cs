using System;
using System.Net;
using ExceptionTranslator;
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
            try
            {
                var klient = new ClientOperator(new XmlDataLoader("C:\\Users\\Igor\\Documents\\nitrogen\\Homeworks\\Homeworks\\Igor\\XMLDocuments\\Cities.xml"));
                var a = klient.GetList();
                klient.AddData("Test4");
                klient.AddData("");
                klient.GetSetResult(new RemoveRepeat());
                a.Add("SIEM");
            }
            catch (ExceptionTran e)
            {
                string m = e.Message;
            }
        }
    }
}
