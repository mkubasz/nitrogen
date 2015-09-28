using System;
using CoursesMati.Messages;

namespace CoursesMati
{
	public class DriverClass
	{
		public int wynik = 0;
		// SOLID 
		public void CheckWhenIsValid(IMessages messages)
		{
			try
			{
				messages.WriteMessage("Jestem1 w domu ;)");
				messages.ReadMessage();
			}
			catch (ExceptionMessage exception)
			{

				throw new Exception(exception.Message);
			}
			finally
			{
				messages.CloseMessage();
				wynik = 1;
			}
		}
	}
}