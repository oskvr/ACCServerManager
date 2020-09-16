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
		string rootPath = Properties.Settings.Default.rootFolderPath;
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

			newEvent = new Event();
			newEvent.track = comboBoxTrack.SelectedItem.ToString();
			newEvent.preRaceWaitingTimeSeconds = int.Parse(txtBoxPreRaceWaitingTime.Text);
			newEvent.sessionOverTimeSeconds = int.Parse(txtBoxSessionOverTime.Text);
			newEvent.ambientTemp = int.Parse(txtBoxAmbientTemp.Text);
			newEvent.cloudLevel = float.Parse(txtBoxCloudLevel.Text);
			newEvent.rain = float.Parse(txtBoxRain.Text);
			newEvent.weatherRandomness = int.Parse(txtBoxWeatherRandomness.Text);
			if (!practiceEnabled && !qualifyingEnabled)
			{
				MessageBox.Show("At least one non-race session must be set up");
			}
			else if (!practiceEnabled)
			{
				newEvent.sessions = new Session[] { qualifying, race };
			}
			else if (!qualifyingEnabled)
			{
				newEvent.sessions = new Session[] { practice, race };
			}
			else
			{
				newEvent.sessions = new Session[] { practice, qualifying, race };
			}
			newEvent.configVersion = 1;

			string output = JsonConvert.SerializeObject(newEvent, Formatting.Indented);
			File.WriteAllText(eventFilePath, output);


		}

		private void Form1_Load(object sender, EventArgs e)
		{
			while (rootPath == "" || !ValidateServerFolder(rootPath))
			{
				MessageBox.Show("You need to add your game's root folder");
				var folderBrowserDialog1 = new FolderBrowserDialog();

				// Show the FolderBrowserDialog.
				DialogResult result = folderBrowserDialog1.ShowDialog();
				if (result == DialogResult.OK)
				{
					rootPath = folderBrowserDialog1.SelectedPath;
					Properties.Settings.Default.rootFolderPath = rootPath;
				}
			}
			eventFilePath = $@"{rootPath}\server\cfg\event.json";
			exePath = $@"{rootPath}\server\accServer.exe";
			string eventJson = File.ReadAllText(eventFilePath);
			newEvent = JsonConvert.DeserializeObject<Event>(eventJson);
			InitializeFormElements(newEvent);
			practiceEnabled = checkBoxPractice.Checked;
			qualifyingEnabled = checkBoxQualifying.Checked;

			Helper.InitializeStartupJson(eventFilePath);
		}

		private void btnStartServer_Click(object sender, EventArgs e)
		{
			Thread.Sleep(100);
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

			if (eventFileFound && exeFound)
			{
				return true;
			}

			return false;
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Properties.Settings.Default.Save();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void txtBoxSessionOverTime_Leave(object sender, EventArgs e)
		{
			if (txtBoxPreRaceWaitingTime.Text == "")
			{
				errorProvider.SetError(txtBoxSessionOverTime, "Field can't be empty");
			}
			else if (!int.TryParse(txtBoxSessionOverTime.Text, out _))
			{
				errorProvider.SetError(txtBoxSessionOverTime, "Only Integers are allowed");
			}
			else
			{
				errorProvider.SetError(txtBoxSessionOverTime, string.Empty);
			}
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
	}
}

