using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ACCServerManager
{
	public partial class Form1 : Form
	{
		Event newEvent;
		string rootPath;
		string eventFilePath = "";
		string exePath = "";
		bool practiceEnabled;
		bool qualifyingEnabled;
		int currentTrackIndex;
		ErrorProvider errorProvider = new ErrorProvider();
		public Form1()
		{
			InitializeComponent();
			errorProvider.BlinkRate = 0;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			newEvent = SaveFormElementsToObject();
			string output = JsonConvert.SerializeObject(newEvent, Formatting.Indented);
			File.WriteAllText(eventFilePath, output);
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			rootPath = Properties.Settings.Default.rootFolderPath;
			while (rootPath == "" || !ValidateServerFolder(rootPath))
			{
				MessageBox.Show("You need to add your Assetto Corsa Competizione root folder");
				var folderBrowserDialog1 = new FolderBrowserDialog();

				// Show the FolderBrowserDialog.
				DialogResult result = folderBrowserDialog1.ShowDialog();
				if (result == DialogResult.OK)
				{
					rootPath = folderBrowserDialog1.SelectedPath;
					Properties.Settings.Default.rootFolderPath = rootPath;
				}
			}
			eventFilePath = rootPath + @"\server\cfg\event.json";
			exePath = rootPath + @"\server\accServer.exe";
			Helper.InitializeStartupJson(eventFilePath);
			string startupJSON = File.ReadAllText(Helper.presetPath + "startup.json");
			newEvent = JsonConvert.DeserializeObject<Event>(startupJSON);
			InitializeFormElements(newEvent);
		}

		private void btnStartServer_Click(object sender, EventArgs e)
		{
			Process.Start(exePath);
		}

		private void checkBoxPractice_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxPractice.Checked)
			{
				practiceEnabled = true;
				txtBoxHourPractice.ReadOnly = false;
				txtBoxMultiplierPractice.ReadOnly = false;
				txtBoxDurationPractice.ReadOnly = false;
				comboBoxDayPractice.DropDownStyle = ComboBoxStyle.DropDown;
			}
			else
			{
				practiceEnabled = false;
				txtBoxHourPractice.ReadOnly = true;
				txtBoxMultiplierPractice.ReadOnly = true;
				txtBoxDurationPractice.ReadOnly = true;
				comboBoxDayPractice.DropDownStyle = ComboBoxStyle.DropDownList;
			}
		}

		private void checkBoxQualifying_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxQualifying.Checked)
			{
				qualifyingEnabled = true;
				txtBoxHourQualifying.ReadOnly = false;
				txtBoxMultiplierQualifying.ReadOnly = false;
				txtBoxDurationQualifying.ReadOnly = false;
				comboBoxDayQualifying.DropDownStyle = ComboBoxStyle.DropDown;
			}
			else
			{
				qualifyingEnabled = false;
				txtBoxHourQualifying.ReadOnly = true;
				txtBoxMultiplierQualifying.ReadOnly = true;
				txtBoxDurationQualifying.ReadOnly = true;
				comboBoxDayQualifying.DropDownStyle = ComboBoxStyle.DropDownList;
			}
		}

		private void InitializeFormElements(Event eventObject)
		{
			Session practice = new Session();
			Session qualifying = new Session();
			Session race = new Session();
			checkBoxPractice.Checked = false;
			checkBoxQualifying.Checked = false;
			foreach (var session in eventObject.sessions)
			{
				if (session.sessionType == "P")
				{
					practice = session;
					practiceEnabled = true;
					checkBoxPractice.Checked = true;
				}
				if (session.sessionType == "Q")
				{
					qualifying = session;
					checkBoxQualifying.Checked = true;
					qualifyingEnabled = true;
				}
				if (session.sessionType == "R")
				{
					race = session;
				}
			}

			// EVENT
			comboBoxTrack.Text = eventObject.track;
			txtBoxPreRaceWaitingTime.Text = eventObject.preRaceWaitingTimeSeconds.ToString();
			txtBoxSessionOverTime.Text = eventObject.sessionOverTimeSeconds.ToString();
			txtBoxAmbientTemp.Text = eventObject.ambientTemp.ToString();
			txtBoxCloudLevel.Text = eventObject.cloudLevel.ToString();
			txtBoxRain.Text = eventObject.rain.ToString();
			txtBoxWeatherRandomness.Text = eventObject.weatherRandomness.ToString();

			// SESSIONS
			if (practiceEnabled)
			{
				txtBoxHourPractice.Text = practice.hourOfDay.ToString();
				comboBoxDayPractice.SelectedIndex = practice.dayOfWeekend - 1;
				txtBoxMultiplierPractice.Text = practice.timeMultiplier.ToString();
				txtBoxDurationPractice.Text = practice.sessionDurationMinutes.ToString();
				comboBoxDayPractice.DropDownStyle = ComboBoxStyle.DropDown;
			}
			else
			{
				txtBoxHourPractice.ReadOnly = true;
				txtBoxMultiplierPractice.ReadOnly = true;
				txtBoxDurationPractice.ReadOnly = true;
				comboBoxDayPractice.DropDownStyle = ComboBoxStyle.DropDownList;
			}
			if (qualifyingEnabled)
			{
				txtBoxHourQualifying.Text = qualifying.hourOfDay.ToString();
				comboBoxDayQualifying.SelectedIndex = qualifying.dayOfWeekend - 1;
				txtBoxMultiplierQualifying.Text = qualifying.timeMultiplier.ToString();
				txtBoxDurationQualifying.Text = qualifying.sessionDurationMinutes.ToString();
			}
			else
			{
				txtBoxHourQualifying.ReadOnly = true;
				txtBoxMultiplierQualifying.ReadOnly = true;
				txtBoxDurationQualifying.ReadOnly = true;
			}
			txtBoxHourRace.Text = race.hourOfDay.ToString();
			comboBoxDayRace.SelectedIndex = race.dayOfWeekend - 1;
			txtBoxMultiplierRace.Text = race.timeMultiplier.ToString();
			txtBoxDurationRace.Text = race.sessionDurationMinutes.ToString();

		}


		/// <summary>
		/// Saves each form element to respective event object property
		/// </summary>
		/// <param name="eventObject"></param>
		private Event SaveFormElementsToObject()
		{
			Event eventObject = new Event();
			Session practice = new Session();
			Session qualifying = new Session();
			if (practiceEnabled)
			{
				practice.hourOfDay = int.Parse(txtBoxHourPractice.Text);
				practice.dayOfWeekend = comboBoxDayPractice.SelectedIndex + 1;
				practice.timeMultiplier = int.Parse(txtBoxMultiplierPractice.Text);
				practice.sessionType = "P";
				practice.sessionDurationMinutes = int.Parse(txtBoxDurationPractice.Text);
			}
			if (qualifyingEnabled)
			{
				qualifying.hourOfDay = int.Parse(txtBoxHourQualifying.Text);
				qualifying.dayOfWeekend = comboBoxDayQualifying.SelectedIndex + 1;
				qualifying.timeMultiplier = int.Parse(txtBoxMultiplierQualifying.Text);
				qualifying.sessionType = "Q";
				qualifying.sessionDurationMinutes = int.Parse(txtBoxDurationQualifying.Text);
			}


			Session race = new Session();
			race.hourOfDay = int.Parse(txtBoxHourRace.Text);
			race.dayOfWeekend = comboBoxDayRace.SelectedIndex + 1;
			race.timeMultiplier = int.Parse(txtBoxMultiplierRace.Text);
			race.sessionType = "R";
			race.sessionDurationMinutes = int.Parse(txtBoxDurationRace.Text);

			eventObject.track = comboBoxTrack.SelectedItem.ToString();
			eventObject.preRaceWaitingTimeSeconds = int.Parse(txtBoxPreRaceWaitingTime.Text);
			eventObject.sessionOverTimeSeconds = int.Parse(txtBoxSessionOverTime.Text);
			eventObject.ambientTemp = int.Parse(txtBoxAmbientTemp.Text);
			eventObject.cloudLevel = float.Parse(txtBoxCloudLevel.Text);
			eventObject.rain = float.Parse(txtBoxRain.Text);
			eventObject.weatherRandomness = int.Parse(txtBoxWeatherRandomness.Text);
			if (!practiceEnabled && !qualifyingEnabled)
			{
				MessageBox.Show("At least one non-race session must be set up");
			}
			else if (!practiceEnabled)
			{
				eventObject.sessions = new Session[] { qualifying, race };
			}
			else if (!qualifyingEnabled)
			{
				eventObject.sessions = new Session[] { practice, race };
			}
			else
			{
				eventObject.sessions = new Session[] { practice, qualifying, race };
			}
			eventObject.configVersion = 1;

			return eventObject;
		}

		private void comboBoxTrack_Leave(object sender, EventArgs e)
		{
			// Track resettas automatiskt till senast valda om värdet är ogiltigt
			bool inList = false;
			foreach (var s in comboBoxTrack.Items)
			{
				if (comboBoxTrack.SelectedItem == s)
				{
					inList = true;
					break;
				}
			}

			if (!inList)
			{
				comboBoxTrack.SelectedIndex = currentTrackIndex;
			}
		}

		private void comboBoxTrack_SelectedIndexChanged(object sender, EventArgs e)
		{
			currentTrackIndex = comboBoxTrack.SelectedIndex;
			string imagePath = @"C:\Users\oskar\source\repos\ACCServerManager\Pics\Tracks_" + comboBoxTrack.SelectedItem.ToString().Substring(0, comboBoxTrack.SelectedItem.ToString().IndexOf("_2019")) + ".png";
			pictureBox1.Image = Image.FromFile(imagePath);
		}
		private bool ValidateServerFolder(string path)
		{
			if (path == "")
			{
				return false;
			}
			bool exeFound = false;
			bool eventFileFound = false;
			string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
			foreach (var file in files)
			{
				if (file.EndsWith("event.json"))
				{
					eventFileFound = true;
				}
				if (file.EndsWith("accServer.exe"))
				{
					exeFound = true;
				}
			}

			return eventFileFound && exeFound;
		}

		private void LoadFromPreset()
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			openFileDialog1.InitialDirectory = Helper.presetPath;
			DialogResult result = openFileDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				string presetJSON = File.ReadAllText(openFileDialog1.FileName);
				newEvent = JsonConvert.DeserializeObject<Event>(presetJSON);
				InitializeFormElements(newEvent);
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Properties.Settings.Default.Save();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void txtBoxPreRaceWaitingTime_Leave(object sender, EventArgs e)
		{
			if (txtBoxPreRaceWaitingTime.Text == "")
			{
				errorProvider.SetError(txtBoxPreRaceWaitingTime, "Field can't be empty");
			}
			else if (!int.TryParse(txtBoxPreRaceWaitingTime.Text, out var preRaceWaitingTime))
			{
				errorProvider.SetError(txtBoxPreRaceWaitingTime, "Only Integers are allowed");

			}
			else if (preRaceWaitingTime < 30)
			{
				errorProvider.SetError(txtBoxPreRaceWaitingTime, "Pre race waiting time must be at least 30");
			}
			else
			{
				errorProvider.SetError(txtBoxPreRaceWaitingTime, string.Empty);
			}
		}

		private void btnSavePreset_Click(object sender, EventArgs e)
		{
			Event tempEvent = SaveFormElementsToObject();
			Helper.SaveToPreset(tempEvent);
			UpdatePresetListBox();
		}

		private void UpdatePresetListBox()
		{
			// TODO: update the shown presets in the listbox
		}

		private void btnLoadPreset_Click(object sender, EventArgs e)
		{
			LoadFromPreset();
		}
	}
}

