using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Startup.TrainingOneHomeworks.GroupMati.Pesel;

namespace Toci.Startup.Test.MatiUnitTest.Pesel
{
    [TestClass]
    public class PeselUnitTest
    {
        [TestMethod]
        public void setGoodPesel()
        {
            PeselValidator pesel = new PeselValidator();
            pesel.PeselNumber = "92092609898";
            Assert.AreEqual("92092609898", pesel.PeselNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPeselExeptions))]
        public void setFloatPeselExeption()
        {
            PeselValidator pesel = new PeselValidator();
            pesel.PeselNumber = "123456789.1";
            Assert.AreNotEqual("123456789.1", pesel.PeselNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPeselExeptions))]
        public void setCharInPeselExeption()
        {
            PeselValidator pesel = new PeselValidator();
            pesel.PeselNumber = "1a345678901";
            Assert.IsNull(pesel.PeselNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPeselExeptions))]
        public void setToManyNumbersInPesel()
        {
            System.Exception exeption;
            PeselValidator pesel = new PeselValidator();

            pesel.PeselNumber = "123456789012";
        }

        [TestMethod]
        public void isFieldNull()
        {
            PeselValidator pesel = new PeselValidator();

            Assert.IsNull(pesel.PeselNumber);
        }

        [TestMethod]
        public void propertyIsNotNull()
        {
            PeselValidator pesel = new PeselValidator();

            pesel.PeselNumber = "92092609898";

            Assert.IsNotNull(pesel.GetPesel());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPeselExeptions))]
        public void setLessNumbersInPesel()
        {
            PeselValidator pesel = new PeselValidator();
            pesel.PeselNumber = "1234567890";
        }



        [TestMethod]
        public void setStringPesel()
        {
            Assert.IsTrue(PeselValidator.CheckPesel("92092609898"));
        }



        [TestMethod]
        [ExpectedException(typeof(InvalidPeselExeptions))]
        public void setWrongString()
        {
            Assert.IsFalse(PeselValidator.CheckPesel("1234567890a"));
        }
    }
}
