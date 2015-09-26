using System;
using System.Collections.Generic;
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
            ClientOperator klient = new ClientOperator(new XMLDataLoader("C:\\Users\\Igor\\Documents\\nitrogen\\Homeworks\\Homeworks\\Igor\\XMLDocuments\\Cities.xml"));
            HashSet<string> a = klient.GetResult(new RemoveRepeat());
        }
    }
}
