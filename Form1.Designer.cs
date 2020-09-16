namespace ACCServerManager
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.comboBoxTrack = new System.Windows.Forms.ComboBox();
			this.lblTrack = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnStartServer = new System.Windows.Forms.Button();
			this.checkBoxQualifying = new System.Windows.Forms.CheckBox();
			this.checkBoxPractice = new System.Windows.Forms.CheckBox();
			this.txtBoxPreRaceWaitingTime = new System.Windows.Forms.TextBox();
			this.lblPreRaceWaitingTime = new System.Windows.Forms.Label();
			this.lblSessionOverTime = new System.Windows.Forms.Label();
			this.txtBoxSessionOverTime = new System.Windows.Forms.TextBox();
			this.txtBoxAmbientTemp = new System.Windows.Forms.TextBox();
			this.lblAmbientTemp = new System.Windows.Forms.Label();
			this.txtBoxCloudLevel = new System.Windows.Forms.TextBox();
			this.lblCloudLevel = new System.Windows.Forms.Label();
			this.txtBoxRain = new System.Windows.Forms.TextBox();
			this.lblRain = new System.Windows.Forms.Label();
			this.txtBoxWeatherRandomness = new System.Windows.Forms.TextBox();
			this.lblWeatherRandomness = new System.Windows.Forms.Label();
			this.comboBoxDayPractice = new System.Windows.Forms.ComboBox();
			this.comboBoxDayQualifying = new System.Windows.Forms.ComboBox();
			this.comboBoxDayRace = new System.Windows.Forms.ComboBox();
			this.lblDayOfWeekend = new System.Windows.Forms.Label();
			this.txtBoxHourPractice = new System.Windows.Forms.TextBox();
			this.lblHourOfDay = new System.Windows.Forms.Label();
			this.txtBoxHourQualifying = new System.Windows.Forms.TextBox();
			this.txtBoxHourRace = new System.Windows.Forms.TextBox();
			this.txtBoxMultiplierPractice = new System.Windows.Forms.TextBox();
			this.txtBoxMultiplierQualifying = new System.Windows.Forms.TextBox();
			this.txtBoxMultiplierRace = new System.Windows.Forms.TextBox();
			this.lblTimeMultiplier = new System.Windows.Forms.Label();
			this.txtBoxDurationPractice = new System.Windows.Forms.TextBox();
			this.txtBoxDurationQualifying = new System.Windows.Forms.TextBox();
			this.txtBoxDurationRace = new System.Windows.Forms.TextBox();
			this.lblSessionDuration = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.lblRace = new System.Windows.Forms.Label();
			this.listBoxPresets = new System.Windows.Forms.ListBox();
			this.btnDeletePreset = new System.Windows.Forms.Button();
			this.btnLoadPreset = new System.Windows.Forms.Button();
			this.btnSavePreset = new System.Windows.Forms.Button();
			this.lblPresets = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// comboBoxTrack
			// 
			this.comboBoxTrack.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.comboBoxTrack.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.comboBoxTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxTrack.ForeColor = System.Drawing.SystemColors.MenuText;
			this.comboBoxTrack.FormattingEnabled = true;
			this.comboBoxTrack.Items.AddRange(new object[] {
            "brands_hatch_2019",
            "kyalami_2019",
            "laguna_seca_2019",
            "hungaroring_2019",
            "misano_2019",
            "monza_2019",
            "mount_panorama_2019",
            "nurburgring_2019",
            "paul_ricard_2019",
            "silverstone_2019",
            "spa_2019",
            "suzuka_2019",
            "zolder_2019",
            "zandvoort_2019"});
			this.comboBoxTrack.Location = new System.Drawing.Point(44, 66);
			this.comboBoxTrack.Name = "comboBoxTrack";
			this.comboBoxTrack.Size = new System.Drawing.Size(128, 24);
			this.comboBoxTrack.TabIndex = 0;
			this.comboBoxTrack.SelectedIndexChanged += new System.EventHandler(this.comboBoxTrack_SelectedIndexChanged);
			this.comboBoxTrack.Leave += new System.EventHandler(this.comboBoxTrack_Leave);
			// 
			// lblTrack
			// 
			this.lblTrack.AutoSize = true;
			this.lblTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTrack.Location = new System.Drawing.Point(41, 47);
			this.lblTrack.Name = "lblTrack";
			this.lblTrack.Size = new System.Drawing.Size(43, 16);
			this.lblTrack.TabIndex = 1;
			this.lblTrack.Text = "Track";
			// 
			// btnSave
			// 
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnSave.Location = new System.Drawing.Point(565, 709);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnStartServer
			// 
			this.btnStartServer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnStartServer.Location = new System.Drawing.Point(410, 709);
			this.btnStartServer.Name = "btnStartServer";
			this.btnStartServer.Size = new System.Drawing.Size(75, 23);
			this.btnStartServer.TabIndex = 3;
			this.btnStartServer.Text = "Start server";
			this.btnStartServer.UseVisualStyleBackColor = true;
			this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
			// 
			// checkBoxQualifying
			// 
			this.checkBoxQualifying.AutoSize = true;
			this.checkBoxQualifying.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxQualifying.Location = new System.Drawing.Point(437, 462);
			this.checkBoxQualifying.Name = "checkBoxQualifying";
			this.checkBoxQualifying.Size = new System.Drawing.Size(91, 22);
			this.checkBoxQualifying.TabIndex = 4;
			this.checkBoxQualifying.Text = "Qualifying";
			this.checkBoxQualifying.UseVisualStyleBackColor = true;
			this.checkBoxQualifying.CheckedChanged += new System.EventHandler(this.checkBoxQualifying_CheckedChanged);
			// 
			// checkBoxPractice
			// 
			this.checkBoxPractice.AutoSize = true;
			this.checkBoxPractice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxPractice.Location = new System.Drawing.Point(275, 462);
			this.checkBoxPractice.Name = "checkBoxPractice";
			this.checkBoxPractice.Size = new System.Drawing.Size(81, 22);
			this.checkBoxPractice.TabIndex = 5;
			this.checkBoxPractice.Text = "Practice";
			this.checkBoxPractice.UseVisualStyleBackColor = true;
			this.checkBoxPractice.CheckedChanged += new System.EventHandler(this.checkBoxPractice_CheckedChanged);
			// 
			// txtBoxPreRaceWaitingTime
			// 
			this.txtBoxPreRaceWaitingTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBoxPreRaceWaitingTime.Location = new System.Drawing.Point(44, 125);
			this.txtBoxPreRaceWaitingTime.Name = "txtBoxPreRaceWaitingTime";
			this.txtBoxPreRaceWaitingTime.Size = new System.Drawing.Size(128, 22);
			this.txtBoxPreRaceWaitingTime.TabIndex = 6;
			this.txtBoxPreRaceWaitingTime.Leave += new System.EventHandler(this.txtBoxPreRaceWaitingTime_Leave);
			// 
			// lblPreRaceWaitingTime
			// 
			this.lblPreRaceWaitingTime.AutoSize = true;
			this.lblPreRaceWaitingTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPreRaceWaitingTime.Location = new System.Drawing.Point(41, 106);
			this.lblPreRaceWaitingTime.Name = "lblPreRaceWaitingTime";
			this.lblPreRaceWaitingTime.Size = new System.Drawing.Size(131, 16);
			this.lblPreRaceWaitingTime.TabIndex = 7;
			this.lblPreRaceWaitingTime.Text = "Pre race waiting time";
			this.toolTip1.SetToolTip(this.lblPreRaceWaitingTime, "Preparation time before a race. Cannot be less than 30s");
			// 
			// lblSessionOverTime
			// 
			this.lblSessionOverTime.AutoSize = true;
			this.lblSessionOverTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSessionOverTime.Location = new System.Drawing.Point(41, 165);
			this.lblSessionOverTime.Name = "lblSessionOverTime";
			this.lblSessionOverTime.Size = new System.Drawing.Size(115, 16);
			this.lblSessionOverTime.TabIndex = 8;
			this.lblSessionOverTime.Text = "Session over time";
			this.toolTip1.SetToolTip(this.lblSessionOverTime, resources.GetString("lblSessionOverTime.ToolTip"));
			// 
			// txtBoxSessionOverTime
			// 
			this.txtBoxSessionOverTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBoxSessionOverTime.Location = new System.Drawing.Point(44, 184);
			this.txtBoxSessionOverTime.Name = "txtBoxSessionOverTime";
			this.txtBoxSessionOverTime.Size = new System.Drawing.Size(128, 22);
			this.txtBoxSessionOverTime.TabIndex = 9;
			// 
			// txtBoxAmbientTemp
			// 
			this.txtBoxAmbientTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBoxAmbientTemp.Location = new System.Drawing.Point(44, 240);
			this.txtBoxAmbientTemp.Name = "txtBoxAmbientTemp";
			this.txtBoxAmbientTemp.Size = new System.Drawing.Size(128, 22);
			this.txtBoxAmbientTemp.TabIndex = 10;
			// 
			// lblAmbientTemp
			// 
			this.lblAmbientTemp.AutoSize = true;
			this.lblAmbientTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAmbientTemp.Location = new System.Drawing.Point(41, 221);
			this.lblAmbientTemp.Name = "lblAmbientTemp";
			this.lblAmbientTemp.Size = new System.Drawing.Size(90, 16);
			this.lblAmbientTemp.TabIndex = 11;
			this.lblAmbientTemp.Text = "Ambient temp";
			this.toolTip1.SetToolTip(this.lblAmbientTemp, "Sets the baseline ambient temperature in °C.");
			// 
			// txtBoxCloudLevel
			// 
			this.txtBoxCloudLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBoxCloudLevel.Location = new System.Drawing.Point(44, 299);
			this.txtBoxCloudLevel.Name = "txtBoxCloudLevel";
			this.txtBoxCloudLevel.Size = new System.Drawing.Size(128, 22);
			this.txtBoxCloudLevel.TabIndex = 12;
			// 
			// lblCloudLevel
			// 
			this.lblCloudLevel.AutoSize = true;
			this.lblCloudLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCloudLevel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblCloudLevel.Location = new System.Drawing.Point(41, 280);
			this.lblCloudLevel.Name = "lblCloudLevel";
			this.lblCloudLevel.Size = new System.Drawing.Size(75, 16);
			this.lblCloudLevel.TabIndex = 13;
			this.lblCloudLevel.Text = "Cloud level";
			this.toolTip1.SetToolTip(this.lblCloudLevel, "Sets the baseline cloud level (Values 0.0, 0.1, .... 1.0)");
			// 
			// txtBoxRain
			// 
			this.txtBoxRain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBoxRain.Location = new System.Drawing.Point(44, 354);
			this.txtBoxRain.Name = "txtBoxRain";
			this.txtBoxRain.Size = new System.Drawing.Size(128, 22);
			this.txtBoxRain.TabIndex = 0;
			// 
			// lblRain
			// 
			this.lblRain.AutoSize = true;
			this.lblRain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblRain.Location = new System.Drawing.Point(41, 335);
			this.lblRain.Name = "lblRain";
			this.lblRain.Size = new System.Drawing.Size(36, 16);
			this.lblRain.TabIndex = 14;
			this.lblRain.Text = "Rain";
			this.toolTip1.SetToolTip(this.lblRain, resources.GetString("lblRain.ToolTip"));
			// 
			// txtBoxWeatherRandomness
			// 
			this.txtBoxWeatherRandomness.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBoxWeatherRandomness.Location = new System.Drawing.Point(44, 411);
			this.txtBoxWeatherRandomness.Name = "txtBoxWeatherRandomness";
			this.txtBoxWeatherRandomness.Size = new System.Drawing.Size(128, 22);
			this.txtBoxWeatherRandomness.TabIndex = 15;
			// 
			// lblWeatherRandomness
			// 
			this.lblWeatherRandomness.AutoSize = true;
			this.lblWeatherRandomness.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblWeatherRandomness.Location = new System.Drawing.Point(41, 392);
			this.lblWeatherRandomness.Name = "lblWeatherRandomness";
			this.lblWeatherRandomness.Size = new System.Drawing.Size(137, 16);
			this.lblWeatherRandomness.TabIndex = 16;
			this.lblWeatherRandomness.Text = "Weather randomness";
			this.toolTip1.SetToolTip(this.lblWeatherRandomness, "Sets the dynamic weather level:\r\n\r\n    0 = static weather\r\n    1 - 4 = fairly rea" +
        "listic weather\r\n    5 - 7 = more sensational");
			// 
			// comboBoxDayPractice
			// 
			this.comboBoxDayPractice.FormattingEnabled = true;
			this.comboBoxDayPractice.Items.AddRange(new object[] {
            "Friday",
            "Saturday",
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday"});
			this.comboBoxDayPractice.Location = new System.Drawing.Point(275, 546);
			this.comboBoxDayPractice.Name = "comboBoxDayPractice";
			this.comboBoxDayPractice.Size = new System.Drawing.Size(121, 21);
			this.comboBoxDayPractice.TabIndex = 18;
			// 
			// comboBoxDayQualifying
			// 
			this.comboBoxDayQualifying.FormattingEnabled = true;
			this.comboBoxDayQualifying.Items.AddRange(new object[] {
            "Friday",
            "Saturday",
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday"});
			this.comboBoxDayQualifying.Location = new System.Drawing.Point(437, 546);
			this.comboBoxDayQualifying.Name = "comboBoxDayQualifying";
			this.comboBoxDayQualifying.Size = new System.Drawing.Size(121, 21);
			this.comboBoxDayQualifying.TabIndex = 18;
			// 
			// comboBoxDayRace
			// 
			this.comboBoxDayRace.FormattingEnabled = true;
			this.comboBoxDayRace.Items.AddRange(new object[] {
            "Friday",
            "Saturday",
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday"});
			this.comboBoxDayRace.Location = new System.Drawing.Point(600, 546);
			this.comboBoxDayRace.Name = "comboBoxDayRace";
			this.comboBoxDayRace.Size = new System.Drawing.Size(121, 21);
			this.comboBoxDayRace.TabIndex = 18;
			// 
			// lblDayOfWeekend
			// 
			this.lblDayOfWeekend.AutoSize = true;
			this.lblDayOfWeekend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDayOfWeekend.Location = new System.Drawing.Point(158, 547);
			this.lblDayOfWeekend.Name = "lblDayOfWeekend";
			this.lblDayOfWeekend.Size = new System.Drawing.Size(105, 16);
			this.lblDayOfWeekend.TabIndex = 19;
			this.lblDayOfWeekend.Text = "Day of weekend";
			// 
			// txtBoxHourPractice
			// 
			this.txtBoxHourPractice.Location = new System.Drawing.Point(275, 503);
			this.txtBoxHourPractice.Name = "txtBoxHourPractice";
			this.txtBoxHourPractice.Size = new System.Drawing.Size(100, 20);
			this.txtBoxHourPractice.TabIndex = 20;
			// 
			// lblHourOfDay
			// 
			this.lblHourOfDay.AutoSize = true;
			this.lblHourOfDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblHourOfDay.Location = new System.Drawing.Point(158, 504);
			this.lblHourOfDay.Name = "lblHourOfDay";
			this.lblHourOfDay.Size = new System.Drawing.Size(77, 16);
			this.lblHourOfDay.TabIndex = 21;
			this.lblHourOfDay.Text = "Hour of day";
			// 
			// txtBoxHourQualifying
			// 
			this.txtBoxHourQualifying.Location = new System.Drawing.Point(437, 503);
			this.txtBoxHourQualifying.Name = "txtBoxHourQualifying";
			this.txtBoxHourQualifying.Size = new System.Drawing.Size(100, 20);
			this.txtBoxHourQualifying.TabIndex = 20;
			// 
			// txtBoxHourRace
			// 
			this.txtBoxHourRace.Location = new System.Drawing.Point(600, 503);
			this.txtBoxHourRace.Name = "txtBoxHourRace";
			this.txtBoxHourRace.Size = new System.Drawing.Size(100, 20);
			this.txtBoxHourRace.TabIndex = 20;
			// 
			// txtBoxMultiplierPractice
			// 
			this.txtBoxMultiplierPractice.Location = new System.Drawing.Point(275, 592);
			this.txtBoxMultiplierPractice.Name = "txtBoxMultiplierPractice";
			this.txtBoxMultiplierPractice.Size = new System.Drawing.Size(100, 20);
			this.txtBoxMultiplierPractice.TabIndex = 22;
			// 
			// txtBoxMultiplierQualifying
			// 
			this.txtBoxMultiplierQualifying.Location = new System.Drawing.Point(437, 592);
			this.txtBoxMultiplierQualifying.Name = "txtBoxMultiplierQualifying";
			this.txtBoxMultiplierQualifying.Size = new System.Drawing.Size(100, 20);
			this.txtBoxMultiplierQualifying.TabIndex = 22;
			// 
			// txtBoxMultiplierRace
			// 
			this.txtBoxMultiplierRace.Location = new System.Drawing.Point(600, 592);
			this.txtBoxMultiplierRace.Name = "txtBoxMultiplierRace";
			this.txtBoxMultiplierRace.Size = new System.Drawing.Size(100, 20);
			this.txtBoxMultiplierRace.TabIndex = 22;
			// 
			// lblTimeMultiplier
			// 
			this.lblTimeMultiplier.AutoSize = true;
			this.lblTimeMultiplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTimeMultiplier.Location = new System.Drawing.Point(158, 593);
			this.lblTimeMultiplier.Name = "lblTimeMultiplier";
			this.lblTimeMultiplier.Size = new System.Drawing.Size(95, 16);
			this.lblTimeMultiplier.TabIndex = 23;
			this.lblTimeMultiplier.Text = "Time multiplier";
			// 
			// txtBoxDurationPractice
			// 
			this.txtBoxDurationPractice.Location = new System.Drawing.Point(275, 641);
			this.txtBoxDurationPractice.Name = "txtBoxDurationPractice";
			this.txtBoxDurationPractice.Size = new System.Drawing.Size(100, 20);
			this.txtBoxDurationPractice.TabIndex = 24;
			// 
			// txtBoxDurationQualifying
			// 
			this.txtBoxDurationQualifying.Location = new System.Drawing.Point(437, 641);
			this.txtBoxDurationQualifying.Name = "txtBoxDurationQualifying";
			this.txtBoxDurationQualifying.Size = new System.Drawing.Size(100, 20);
			this.txtBoxDurationQualifying.TabIndex = 24;
			// 
			// txtBoxDurationRace
			// 
			this.txtBoxDurationRace.Location = new System.Drawing.Point(600, 641);
			this.txtBoxDurationRace.Name = "txtBoxDurationRace";
			this.txtBoxDurationRace.Size = new System.Drawing.Size(100, 20);
			this.txtBoxDurationRace.TabIndex = 24;
			// 
			// lblSessionDuration
			// 
			this.lblSessionDuration.AutoSize = true;
			this.lblSessionDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSessionDuration.Location = new System.Drawing.Point(158, 642);
			this.lblSessionDuration.Name = "lblSessionDuration";
			this.lblSessionDuration.Size = new System.Drawing.Size(108, 16);
			this.lblSessionDuration.TabIndex = 25;
			this.lblSessionDuration.Text = "Session duration";
			// 
			// toolTip1
			// 
			this.toolTip1.AutoPopDelay = 30000;
			this.toolTip1.InitialDelay = 500;
			this.toolTip1.ReshowDelay = 100;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(275, 50);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(398, 381);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 27;
			this.pictureBox1.TabStop = false;
			// 
			// btnCancel
			// 
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCancel.Location = new System.Drawing.Point(731, 709);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 29;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(3, 658);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(149, 84);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 30;
			this.pictureBox2.TabStop = false;
			// 
			// lblRace
			// 
			this.lblRace.AutoSize = true;
			this.lblRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblRace.Location = new System.Drawing.Point(597, 466);
			this.lblRace.Name = "lblRace";
			this.lblRace.Size = new System.Drawing.Size(43, 18);
			this.lblRace.TabIndex = 31;
			this.lblRace.Text = "Race";
			// 
			// listBoxPresets
			// 
			this.listBoxPresets.FormattingEnabled = true;
			this.listBoxPresets.Location = new System.Drawing.Point(756, 52);
			this.listBoxPresets.Name = "listBoxPresets";
			this.listBoxPresets.Size = new System.Drawing.Size(214, 381);
			this.listBoxPresets.TabIndex = 32;
			// 
			// btnDeletePreset
			// 
			this.btnDeletePreset.Location = new System.Drawing.Point(895, 439);
			this.btnDeletePreset.Name = "btnDeletePreset";
			this.btnDeletePreset.Size = new System.Drawing.Size(75, 23);
			this.btnDeletePreset.TabIndex = 33;
			this.btnDeletePreset.Text = "Delete";
			this.btnDeletePreset.UseVisualStyleBackColor = true;
			// 
			// btnLoadPreset
			// 
			this.btnLoadPreset.Location = new System.Drawing.Point(802, 439);
			this.btnLoadPreset.Name = "btnLoadPreset";
			this.btnLoadPreset.Size = new System.Drawing.Size(75, 23);
			this.btnLoadPreset.TabIndex = 34;
			this.btnLoadPreset.Text = "Load";
			this.btnLoadPreset.UseVisualStyleBackColor = true;
			this.btnLoadPreset.Click += new System.EventHandler(this.btnLoadPreset_Click);
			// 
			// btnSavePreset
			// 
			this.btnSavePreset.Location = new System.Drawing.Point(646, 709);
			this.btnSavePreset.Name = "btnSavePreset";
			this.btnSavePreset.Size = new System.Drawing.Size(75, 23);
			this.btnSavePreset.TabIndex = 35;
			this.btnSavePreset.Text = "Save preset";
			this.btnSavePreset.UseVisualStyleBackColor = true;
			this.btnSavePreset.Click += new System.EventHandler(this.btnSavePreset_Click);
			// 
			// lblPresets
			// 
			this.lblPresets.AutoSize = true;
			this.lblPresets.Location = new System.Drawing.Point(756, 33);
			this.lblPresets.Name = "lblPresets";
			this.lblPresets.Size = new System.Drawing.Size(42, 13);
			this.lblPresets.TabIndex = 36;
			this.lblPresets.Text = "Presets";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(987, 744);
			this.Controls.Add(this.lblPresets);
			this.Controls.Add(this.btnSavePreset);
			this.Controls.Add(this.btnLoadPreset);
			this.Controls.Add(this.btnDeletePreset);
			this.Controls.Add(this.listBoxPresets);
			this.Controls.Add(this.lblRace);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.lblSessionDuration);
			this.Controls.Add(this.txtBoxDurationRace);
			this.Controls.Add(this.txtBoxDurationQualifying);
			this.Controls.Add(this.txtBoxDurationPractice);
			this.Controls.Add(this.lblTimeMultiplier);
			this.Controls.Add(this.txtBoxMultiplierRace);
			this.Controls.Add(this.txtBoxMultiplierQualifying);
			this.Controls.Add(this.txtBoxMultiplierPractice);
			this.Controls.Add(this.lblHourOfDay);
			this.Controls.Add(this.txtBoxHourRace);
			this.Controls.Add(this.txtBoxHourQualifying);
			this.Controls.Add(this.txtBoxHourPractice);
			this.Controls.Add(this.lblDayOfWeekend);
			this.Controls.Add(this.comboBoxDayRace);
			this.Controls.Add(this.comboBoxDayQualifying);
			this.Controls.Add(this.comboBoxDayPractice);
			this.Controls.Add(this.lblWeatherRandomness);
			this.Controls.Add(this.txtBoxWeatherRandomness);
			this.Controls.Add(this.lblRain);
			this.Controls.Add(this.txtBoxRain);
			this.Controls.Add(this.lblCloudLevel);
			this.Controls.Add(this.txtBoxCloudLevel);
			this.Controls.Add(this.lblAmbientTemp);
			this.Controls.Add(this.txtBoxAmbientTemp);
			this.Controls.Add(this.txtBoxSessionOverTime);
			this.Controls.Add(this.lblSessionOverTime);
			this.Controls.Add(this.lblPreRaceWaitingTime);
			this.Controls.Add(this.txtBoxPreRaceWaitingTime);
			this.Controls.Add(this.checkBoxPractice);
			this.Controls.Add(this.checkBoxQualifying);
			this.Controls.Add(this.btnStartServer);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.lblTrack);
			this.Controls.Add(this.comboBoxTrack);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "ACC Server Manager";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBoxTrack;
		private System.Windows.Forms.Label lblTrack;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnStartServer;
		private System.Windows.Forms.CheckBox checkBoxQualifying;
		private System.Windows.Forms.CheckBox checkBoxPractice;
		private System.Windows.Forms.TextBox txtBoxPreRaceWaitingTime;
		private System.Windows.Forms.Label lblPreRaceWaitingTime;
		private System.Windows.Forms.Label lblSessionOverTime;
		private System.Windows.Forms.TextBox txtBoxSessionOverTime;
		private System.Windows.Forms.TextBox txtBoxAmbientTemp;
		private System.Windows.Forms.Label lblAmbientTemp;
		private System.Windows.Forms.TextBox txtBoxCloudLevel;
		private System.Windows.Forms.Label lblCloudLevel;
		private System.Windows.Forms.TextBox txtBoxRain;
		private System.Windows.Forms.Label lblRain;
		private System.Windows.Forms.TextBox txtBoxWeatherRandomness;
		private System.Windows.Forms.Label lblWeatherRandomness;
		private System.Windows.Forms.ComboBox comboBoxDayPractice;
		private System.Windows.Forms.ComboBox comboBoxDayQualifying;
		private System.Windows.Forms.ComboBox comboBoxDayRace;
		private System.Windows.Forms.Label lblDayOfWeekend;
		private System.Windows.Forms.TextBox txtBoxHourPractice;
		private System.Windows.Forms.Label lblHourOfDay;
		private System.Windows.Forms.TextBox txtBoxHourQualifying;
		private System.Windows.Forms.TextBox txtBoxHourRace;
		private System.Windows.Forms.TextBox txtBoxMultiplierPractice;
		private System.Windows.Forms.TextBox txtBoxMultiplierQualifying;
		private System.Windows.Forms.TextBox txtBoxMultiplierRace;
		private System.Windows.Forms.Label lblTimeMultiplier;
		private System.Windows.Forms.TextBox txtBoxDurationPractice;
		private System.Windows.Forms.TextBox txtBoxDurationQualifying;
		private System.Windows.Forms.TextBox txtBoxDurationRace;
		private System.Windows.Forms.Label lblSessionDuration;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label lblRace;
		private System.Windows.Forms.ListBox listBoxPresets;
		private System.Windows.Forms.Button btnDeletePreset;
		private System.Windows.Forms.Button btnLoadPreset;
		private System.Windows.Forms.Button btnSavePreset;
		private System.Windows.Forms.Label lblPresets;
	}
}

