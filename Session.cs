namespace ACCServerManager
{
	public class Session
	{

		public int hourOfDay { get; set; }
		public int dayOfWeekend { get; set; }
		public int timeMultiplier { get; set; }
		public string sessionType { get; set; }
		public int sessionDurationMinutes { get; set; }

		public Session()
		{

		}
	}
}