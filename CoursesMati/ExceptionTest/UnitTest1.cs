using System;
using System.Diagnostics;
using CoursesMati;
using CoursesMati.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExceptionTest
{
	[TestClass]
	public class UnitTest
	{
		[TestMethod]
		public void TestExceptionsMechanic()
		{
			DriverClass driver = new DriverClass();
			IMessages messages = new Messages();
			driver.CheckWhenIsValid(messages);
			Assert.AreEqual(1,driver.wynik);

		}
	}
}
