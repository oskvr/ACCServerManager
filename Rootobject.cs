﻿namespace ACCServerManager
{
	public class Rootobject
	{
		public string track { get; set; }
		public int preRaceWaitingTimeSeconds { get; set; }
		public int sessionOverTimeSeconds { get; set; }
		public int ambientTemp { get; set; }
		public float cloudLevel { get; set; }
		public float rain { get; set; }
		public int weatherRandomness { get; set; }
		public Session[] sessions { get; set; }
		public int configVersion { get; set; }

		public Rootobject()
		{

		}
	}
}