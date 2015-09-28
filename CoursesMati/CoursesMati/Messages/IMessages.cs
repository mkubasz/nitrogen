namespace CoursesMati.Messages
{
	public interface IMessages
	{
		 string MyMessage { get; set; }
		string ReadMessage();
		void WriteMessage(string myMessage);
		void CloseMessage();
	}
}