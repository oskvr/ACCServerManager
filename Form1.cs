using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using Newtonsoft.Json;

namespace ACCServerManager
{
	public partial class Form1 : Form
	{
		Rootobject newEvent;
		string rootPath = Properties.Settings.Default.rootFolderPath;
		string eventFilePath = "";
		string exePath = "";
		bool practiceEnabled;
		bool qualifyingEnabled;
		int currentTrackIndex;
		bool darkMode;
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

			newEvent = new Rootobject();
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
			newEvent = JsonConvert.DeserializeObject<Rootobject>(eventJson);
			InitializeFormElements(newEvent);
			practiceEnabled = checkBoxPractice.Checked;
			qualifyingEnabled = checkBoxQualifying.Checked;

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

		private void InitializeFormElements(Rootobject eventObject)
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
			if (!darkMode)
			{
				string imagePath = @"C:\Users\oskar\source\repos\ACCServerManager\Pics\Tracks_" + comboBoxTrack.SelectedItem.ToString().Substring(0, comboBoxTrack.SelectedItem.ToString().IndexOf("_2019")) + ".png";
				pictureBox1.Image = Image.FromFile(imagePath);
			}
			else
			{
				string imagePath = @"C:\Users\oskar\source\repos\ACCServerManager\Pics\invTracks_" + comboBoxTrack.SelectedItem.ToString().Substring(0, comboBoxTrack.SelectedItem.ToString().IndexOf("_2019")) + ".png";
				pictureBox1.Image = Image.FromFile(imagePath);
			}
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

		private void Form1_Leave(object sender, EventArgs e)
		{
			Properties.Settings.Default.Save();
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
			int preRaceWaitingTime;
			if (txtBoxPreRaceWaitingTime.Text == "")
			{
				errorProvider.SetError(txtBoxPreRaceWaitingTime, "Field can't be empty");
			}
			else if (!int.TryParse(txtBoxPreRaceWaitingTime.Text, out preRaceWaitingTime))
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

		private void SetDarkMode()
		{
			var darkModeBgColor = Color.FromArgb(50, 50, 60);
			var labelDarkMode = Color.LightGray;
			var textBoxDarkMode = Color.FromArgb(60, 60, 75);
			BackColor = darkModeBgColor;
			pictureBox1.Image = Image.FromFile(@"C:\Users\oskar\source\repos\ACCServerManager\Pics\invTracks_" + comboBoxTrack.SelectedItem.ToString().Substring(0, comboBoxTrack.SelectedItem.ToString().IndexOf("_2019")) + ".png");
			foreach (var label in Controls.OfType<Label>())
			{
				label.ForeColor = labelDarkMode;
				label.BackColor = darkModeBgColor;
			}
			foreach (var textBox in Controls.OfType<TextBox>())
			{
				textBox.BackColor = textBoxDarkMode;
				textBox.ForeColor = labelDarkMode;
			}
			foreach (var comboBox in Controls.OfType<ComboBox>())
			{
				comboBox.BackColor = textBoxDarkMode;
				comboBox.ForeColor = labelDarkMode;
			}
			foreach (var button in Controls.OfType<Button>())
			{
				button.BackColor = textBoxDarkMode;
				button.ForeColor = labelDarkMode;
			}
			foreach (var checkBox in Controls.OfType<CheckBox>())
			{
				checkBox.BackColor = darkModeBgColor;
				checkBox.ForeColor = labelDarkMode;
			}

		}
		private void SetLightMode()
		{
			BackColor = Color.FromName("Control");
			pictureBox1.Image = Image.FromFile(@"C:\Users\oskar\source\repos\ACCServerManager\Pics\Tracks_" + comboBoxTrack.SelectedItem.ToString().Substring(0, comboBoxTrack.SelectedItem.ToString().IndexOf("_2019")) + ".png");
			foreach (var label in Controls.OfType<Label>())
			{
				label.ForeColor = Color.FromName("ControlText");
				label.BackColor = Color.FromName("Control");
			}
			foreach (var textBox in Controls.OfType<TextBox>())
			{
				textBox.ForeColor = Color.FromName("WindowText");
				textBox.BackColor = Color.FromName("Window");
			}
			foreach (var comboBox in Controls.OfType<ComboBox>())
			{
				comboBox.BackColor = Color.FromName("Window");
				comboBox.ForeColor = Color.FromName("MenuText");
			}
			foreach (var button in Controls.OfType<Button>())
			{
				button.BackColor = Color.FromName("Control");
				button.ForeColor = Color.FromName("ControlText");
			}
			foreach (var checkBox in Controls.OfType<CheckBox>())
			{
				checkBox.ForeColor = Color.FromName("ControlText");
				checkBox.BackColor = Color.FromName("Control");
			}

		}

		private void checkBoxDarkMode_CheckedChanged(object sender, EventArgs e)
		{

			if (!darkMode)
			{
				SetDarkMode();
				darkMode = true;
			}
			else
			{
				SetLightMode();
				darkMode = false;
			}
		}
	}


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

		public Rootobject(string track, int preRaceWaitingTimeSeconds, int sessionOverTimeSeconds, int ambientTemp, float cloudLevel, float rain, int weatherRandomness, Session[] sessions, int configVersion)
		{
			this.track = track;
			this.preRaceWaitingTimeSeconds = preRaceWaitingTimeSeconds;
			this.sessionOverTimeSeconds = sessionOverTimeSeconds;
			this.ambientTemp = ambientTemp;
			this.cloudLevel = cloudLevel;
			this.rain = rain;
			this.weatherRandomness = weatherRandomness;
			this.sessions = sessions;
			this.configVersion = configVersion;
		}

		public Rootobject()
		{

		}
	}

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

		public Session(int hourOfDay, int dayOfWeekend, int timeMultiplier, string sessionType, int sessionDurationMinutes)
		{
			this.hourOfDay = hourOfDay;
			this.dayOfWeekend = dayOfWeekend;
			this.timeMultiplier = timeMultiplier;
			this.sessionType = sessionType;
			this.sessionDurationMinutes = sessionDurationMinutes;
		}
	}
}

