using System;

namespace CoursesMati.Messages
{
	public class Messages : IMessages
	{
		public string MyMessage { get; set; }
		public string ReadMessage()
		{
			return MyMessage;
		}

		public void WriteMessage(string MyMessage)
		{
			foreach (var item in MyMessage)
			{
				if(Char.IsDigit(item))
					 new ExceptionMessage("Jest liczba");
			}
			this.MyMessage = MyMessage;
		}

		public void CloseMessage()
		{
			MyMessage = null;
		}
	}
}