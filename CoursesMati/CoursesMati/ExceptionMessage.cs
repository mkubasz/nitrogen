using System;

namespace CoursesMati
{
	public class ExceptionMessage : Exception
	{
		//public string MessageException;
		public ExceptionMessage(string message) : base(message)
		{
			//MessageException = message;
		}
		 
	}
}