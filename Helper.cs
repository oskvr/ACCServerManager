using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACCServerManager
{
	class Helper
	{
		public static string presetPath = AppDomain.CurrentDomain.BaseDirectory + "Presets";

		/// <summary>
		/// Copies the contents of event.json to startup.json
		/// </summary>
		public static void InitializeStartupJson(string eventFilePath)
		{
			string eventJsonData = File.ReadAllText(eventFilePath);
			File.WriteAllText(presetPath + "startup.json", eventJsonData);
		}

		public static bool SaveToPreset(Event eventObjectToSave)
		{
			string fileName = GetSaveFileDialogFileName();
			if (fileName == null)
			{
				return false;
			}
			File.WriteAllText(fileName, JsonConvert.SerializeObject(eventObjectToSave, Formatting.Indented));
			return true;
		}

		private static string GetSaveFileDialogFileName()
		{
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();
			saveFileDialog1.Filter = "JSON file|*.json";
			saveFileDialog1.Title = "Save a preset";
			saveFileDialog1.InitialDirectory = presetPath;
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				return saveFileDialog1.FileName;
			}
			return null;
		}
	}
}
