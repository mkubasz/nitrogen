using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polimorfizm;
using Property;

namespace TestUnit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BaseClass baseClass = new BaseClass();
            BaseClass childClass = new ChildClass();
            int place = 10;
            baseClass.done(place);
            Assert.AreEqual(10,childClass.Ania(place));
         }

        [TestMethod]
        public void TestProperty()
        {
            PropertyClass propertyClass = new PropertyClass();
            propertyClass.Property = 5;
            propertyClass.TestPropertyPrivate =7;
            propertyClass.TestPropertyOld = 9;

        }
    }
}
