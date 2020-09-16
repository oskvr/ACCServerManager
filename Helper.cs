using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCServerManager
{
	class Helper
	{

		/// <summary>
		/// Copies the contents of event.json to startup.json
		/// </summary>
		/// <param name="eventFilePath"></param>
		/// <param name="startupPresetPath"></param>
		public static void InitializeStartupJson(string eventFilePath)
		{
			string startupPresetPath = @"..\debug\Presets\startup.json";
			string eventJsonData = File.ReadAllText(eventFilePath);
			File.WriteAllText(startupPresetPath, eventJsonData);
		}
	}
}
