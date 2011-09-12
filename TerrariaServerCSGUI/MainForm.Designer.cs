namespace TerrariaServerGUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openFileDialog_Main = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog_Main = new System.Windows.Forms.FolderBrowserDialog();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tabPage_Startup = new System.Windows.Forms.TabPage();
            this.label_Password = new System.Windows.Forms.Label();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.textBox_BanList = new System.Windows.Forms.TextBox();
            this.button_BanList = new System.Windows.Forms.Button();
            this.checkBox_Secure = new System.Windows.Forms.CheckBox();
            this.label_Port = new System.Windows.Forms.Label();
            this.numericUpDown_Port = new System.Windows.Forms.NumericUpDown();
            this.textBox_MODT = new System.Windows.Forms.TextBox();
            this.label_MODT = new System.Windows.Forms.Label();
            this.label_Players = new System.Windows.Forms.Label();
            this.textBox_World = new System.Windows.Forms.TextBox();
            this.button_World = new System.Windows.Forms.Button();
            this.button_ServerPath = new System.Windows.Forms.Button();
            this.textBox_ServerPath = new System.Windows.Forms.TextBox();
            this.label_ServerType = new System.Windows.Forms.Label();
            this.numericUpDown_Players = new System.Windows.Forms.NumericUpDown();
            this.comboBox_ServerType = new System.Windows.Forms.ComboBox();
            this.tabPage_AutoCreation = new System.Windows.Forms.TabPage();
            this.label_AutoCreateSize = new System.Windows.Forms.Label();
            this.comboBox_AutoCreateSize = new System.Windows.Forms.ComboBox();
            this.textBox_WorldPath = new System.Windows.Forms.TextBox();
            this.button_WorldPath = new System.Windows.Forms.Button();
            this.textBox_WorldName = new System.Windows.Forms.TextBox();
            this.label_WorldName = new System.Windows.Forms.Label();
            this.tabPage_Backup = new System.Windows.Forms.TabPage();
            this.label_AutosaveTimeRemaining = new System.Windows.Forms.Label();
            this.label_AutosaveTimeRemainingData = new System.Windows.Forms.Label();
            this.comboBox_AutosaveDelayFactor = new System.Windows.Forms.ComboBox();
            this.label_AutoSaveDelay = new System.Windows.Forms.Label();
            this.numericUpDown_AutosaveDelay = new System.Windows.Forms.NumericUpDown();
            this.checkBox_AutoSave = new System.Windows.Forms.CheckBox();
            this.tabPage_Logging = new System.Windows.Forms.TabPage();
            this.label_LogFilenamePrefix = new System.Windows.Forms.Label();
            this.textBox_LogFilenamePrefix = new System.Windows.Forms.TextBox();
            this.button_LoggingFolder = new System.Windows.Forms.Button();
            this.textBox_LogFolder = new System.Windows.Forms.TextBox();
            this.checkBox_Logging = new System.Windows.Forms.CheckBox();
            this.splitContainer_Console = new System.Windows.Forms.SplitContainer();
            this.richTextBox_Console = new System.Windows.Forms.RichTextBox();
            this.textBox_Execute = new System.Windows.Forms.TextBox();
            this.button_Execute = new System.Windows.Forms.Button();
            this.toolStrip_Header = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton_File = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton_StartServer = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer_Main = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip_Footer = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_StatusIcon = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_StatusText = new System.Windows.Forms.ToolStripLabel();
            this.toolStripProgressBar_Main = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip_Config = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_ConfigFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem_ConfigFileRename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox_ConfigFile = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton_ConfigFileSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ConfigFileSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ConfigFileDelete = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog_Config = new System.Windows.Forms.SaveFileDialog();
            this.timer_Autosave = new System.Windows.Forms.Timer(this.components);
            this.timer_Main = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label_LogFileSizeLimitUnit = new System.Windows.Forms.Label();
            this.label_LogProcedureWhenFull = new System.Windows.Forms.Label();
            this.comboBox_LogProcedureWhenFull = new System.Windows.Forms.ComboBox();
            this.label_LogFileSizeLimitInfo = new System.Windows.Forms.Label();
            this.numericUpDown_LogFileSizeLimit = new System.Windows.Forms.NumericUpDown();
            this.label_LogError = new System.Windows.Forms.Label();
            this.toolStripMenuItem_ConfigFileOpenDirectory = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).BeginInit();
            this.splitContainer_Main.Panel1.SuspendLayout();
            this.splitContainer_Main.Panel2.SuspendLayout();
            this.splitContainer_Main.SuspendLayout();
            this.tabControl_Main.SuspendLayout();
            this.tabPage_Startup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Port)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Players)).BeginInit();
            this.tabPage_AutoCreation.SuspendLayout();
            this.tabPage_Backup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AutosaveDelay)).BeginInit();
            this.tabPage_Logging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Console)).BeginInit();
            this.splitContainer_Console.Panel1.SuspendLayout();
            this.splitContainer_Console.Panel2.SuspendLayout();
            this.splitContainer_Console.SuspendLayout();
            this.toolStrip_Header.SuspendLayout();
            this.toolStripContainer_Main.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer_Main.ContentPanel.SuspendLayout();
            this.toolStripContainer_Main.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer_Main.SuspendLayout();
            this.toolStrip_Footer.SuspendLayout();
            this.toolStrip_Config.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_LogFileSizeLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.AutoScroll = true;
            this.ContentPanel.Size = new System.Drawing.Size(502, 362);
            // 
            // splitContainer_Main
            // 
            this.splitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_Main.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Main.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer_Main.Name = "splitContainer_Main";
            this.splitContainer_Main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_Main.Panel1
            // 
            this.splitContainer_Main.Panel1.Controls.Add(this.tabControl_Main);
            // 
            // splitContainer_Main.Panel2
            // 
            this.splitContainer_Main.Panel2.Controls.Add(this.splitContainer_Console);
            this.splitContainer_Main.Size = new System.Drawing.Size(502, 312);
            this.splitContainer_Main.SplitterDistance = 189;
            this.splitContainer_Main.SplitterWidth = 1;
            this.splitContainer_Main.TabIndex = 2;
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Controls.Add(this.tabPage_Startup);
            this.tabControl_Main.Controls.Add(this.tabPage_AutoCreation);
            this.tabControl_Main.Controls.Add(this.tabPage_Backup);
            this.tabControl_Main.Controls.Add(this.tabPage_Logging);
            this.tabControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(502, 189);
            this.tabControl_Main.TabIndex = 5;
            // 
            // tabPage_Startup
            // 
            this.tabPage_Startup.Controls.Add(this.label_Password);
            this.tabPage_Startup.Controls.Add(this.textBox_Password);
            this.tabPage_Startup.Controls.Add(this.textBox_BanList);
            this.tabPage_Startup.Controls.Add(this.button_BanList);
            this.tabPage_Startup.Controls.Add(this.checkBox_Secure);
            this.tabPage_Startup.Controls.Add(this.label_Port);
            this.tabPage_Startup.Controls.Add(this.numericUpDown_Port);
            this.tabPage_Startup.Controls.Add(this.textBox_MODT);
            this.tabPage_Startup.Controls.Add(this.label_MODT);
            this.tabPage_Startup.Controls.Add(this.label_Players);
            this.tabPage_Startup.Controls.Add(this.textBox_World);
            this.tabPage_Startup.Controls.Add(this.button_World);
            this.tabPage_Startup.Controls.Add(this.button_ServerPath);
            this.tabPage_Startup.Controls.Add(this.textBox_ServerPath);
            this.tabPage_Startup.Controls.Add(this.label_ServerType);
            this.tabPage_Startup.Controls.Add(this.numericUpDown_Players);
            this.tabPage_Startup.Controls.Add(this.comboBox_ServerType);
            this.tabPage_Startup.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Startup.Name = "tabPage_Startup";
            this.tabPage_Startup.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Startup.Size = new System.Drawing.Size(494, 163);
            this.tabPage_Startup.TabIndex = 0;
            this.tabPage_Startup.Text = "Startup";
            this.tabPage_Startup.UseVisualStyleBackColor = true;
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(323, 36);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(56, 13);
            this.label_Password.TabIndex = 21;
            this.label_Password.Text = "Password:";
            this.label_Password.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(408, 33);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.PasswordChar = '*';
            this.textBox_Password.Size = new System.Drawing.Size(80, 20);
            this.textBox_Password.TabIndex = 20;
            // 
            // textBox_BanList
            // 
            this.textBox_BanList.Location = new System.Drawing.Point(83, 137);
            this.textBox_BanList.Name = "textBox_BanList";
            this.textBox_BanList.Size = new System.Drawing.Size(234, 20);
            this.textBox_BanList.TabIndex = 18;
            // 
            // button_BanList
            // 
            this.button_BanList.Location = new System.Drawing.Point(11, 134);
            this.button_BanList.Name = "button_BanList";
            this.button_BanList.Size = new System.Drawing.Size(66, 24);
            this.button_BanList.TabIndex = 19;
            this.button_BanList.Text = "Ban List:";
            this.button_BanList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_BanList.UseVisualStyleBackColor = true;
            this.button_BanList.Click += new System.EventHandler(this.button_BanList_Click);
            // 
            // checkBox_Secure
            // 
            this.checkBox_Secure.AutoSize = true;
            this.checkBox_Secure.Location = new System.Drawing.Point(323, 110);
            this.checkBox_Secure.Name = "checkBox_Secure";
            this.checkBox_Secure.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox_Secure.Size = new System.Drawing.Size(104, 17);
            this.checkBox_Secure.TabIndex = 17;
            this.checkBox_Secure.Text = "Enforce Security";
            this.checkBox_Secure.UseVisualStyleBackColor = true;
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(323, 86);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(29, 13);
            this.label_Port.TabIndex = 16;
            this.label_Port.Text = "Port:";
            this.label_Port.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown_Port
            // 
            this.numericUpDown_Port.Location = new System.Drawing.Point(409, 84);
            this.numericUpDown_Port.Maximum = new decimal(new int[] {
            32000,
            0,
            0,
            0});
            this.numericUpDown_Port.Name = "numericUpDown_Port";
            this.numericUpDown_Port.Size = new System.Drawing.Size(78, 20);
            this.numericUpDown_Port.TabIndex = 15;
            this.numericUpDown_Port.Value = new decimal(new int[] {
            7777,
            0,
            0,
            0});
            // 
            // textBox_MODT
            // 
            this.textBox_MODT.Location = new System.Drawing.Point(83, 58);
            this.textBox_MODT.Multiline = true;
            this.textBox_MODT.Name = "textBox_MODT";
            this.textBox_MODT.Size = new System.Drawing.Size(234, 73);
            this.textBox_MODT.TabIndex = 14;
            // 
            // label_MODT
            // 
            this.label_MODT.AutoSize = true;
            this.label_MODT.Location = new System.Drawing.Point(35, 61);
            this.label_MODT.Name = "label_MODT";
            this.label_MODT.Size = new System.Drawing.Size(42, 13);
            this.label_MODT.TabIndex = 13;
            this.label_MODT.Text = "MODT:";
            this.label_MODT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Players
            // 
            this.label_Players.AutoSize = true;
            this.label_Players.Location = new System.Drawing.Point(323, 61);
            this.label_Players.Name = "label_Players";
            this.label_Players.Size = new System.Drawing.Size(67, 13);
            this.label_Players.TabIndex = 6;
            this.label_Players.Text = "Max Players:";
            this.label_Players.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_World
            // 
            this.textBox_World.Location = new System.Drawing.Point(83, 32);
            this.textBox_World.Name = "textBox_World";
            this.textBox_World.Size = new System.Drawing.Size(234, 20);
            this.textBox_World.TabIndex = 8;
            // 
            // button_World
            // 
            this.button_World.Location = new System.Drawing.Point(29, 29);
            this.button_World.Name = "button_World";
            this.button_World.Size = new System.Drawing.Size(48, 24);
            this.button_World.TabIndex = 11;
            this.button_World.Text = "World:";
            this.button_World.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_World.UseVisualStyleBackColor = true;
            this.button_World.Click += new System.EventHandler(this.button_World_Click);
            // 
            // button_ServerPath
            // 
            this.button_ServerPath.Location = new System.Drawing.Point(3, 3);
            this.button_ServerPath.Name = "button_ServerPath";
            this.button_ServerPath.Size = new System.Drawing.Size(74, 24);
            this.button_ServerPath.TabIndex = 2;
            this.button_ServerPath.Text = "Server Path:";
            this.button_ServerPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_ServerPath.UseVisualStyleBackColor = true;
            this.button_ServerPath.Click += new System.EventHandler(this.button_ServerPath_Click);
            // 
            // textBox_ServerPath
            // 
            this.textBox_ServerPath.Location = new System.Drawing.Point(83, 6);
            this.textBox_ServerPath.Name = "textBox_ServerPath";
            this.textBox_ServerPath.Size = new System.Drawing.Size(234, 20);
            this.textBox_ServerPath.TabIndex = 1;
            // 
            // label_ServerType
            // 
            this.label_ServerType.AutoSize = true;
            this.label_ServerType.Location = new System.Drawing.Point(323, 9);
            this.label_ServerType.Name = "label_ServerType";
            this.label_ServerType.Size = new System.Drawing.Size(68, 13);
            this.label_ServerType.TabIndex = 3;
            this.label_ServerType.Text = "Server Type:";
            this.label_ServerType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown_Players
            // 
            this.numericUpDown_Players.Location = new System.Drawing.Point(409, 58);
            this.numericUpDown_Players.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDown_Players.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Players.Name = "numericUpDown_Players";
            this.numericUpDown_Players.Size = new System.Drawing.Size(78, 20);
            this.numericUpDown_Players.TabIndex = 5;
            this.numericUpDown_Players.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // comboBox_ServerType
            // 
            this.comboBox_ServerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ServerType.FormattingEnabled = true;
            this.comboBox_ServerType.Location = new System.Drawing.Point(409, 6);
            this.comboBox_ServerType.Name = "comboBox_ServerType";
            this.comboBox_ServerType.Size = new System.Drawing.Size(78, 21);
            this.comboBox_ServerType.TabIndex = 4;
            // 
            // tabPage_AutoCreation
            // 
            this.tabPage_AutoCreation.Controls.Add(this.label_AutoCreateSize);
            this.tabPage_AutoCreation.Controls.Add(this.comboBox_AutoCreateSize);
            this.tabPage_AutoCreation.Controls.Add(this.textBox_WorldPath);
            this.tabPage_AutoCreation.Controls.Add(this.button_WorldPath);
            this.tabPage_AutoCreation.Controls.Add(this.textBox_WorldName);
            this.tabPage_AutoCreation.Controls.Add(this.label_WorldName);
            this.tabPage_AutoCreation.Location = new System.Drawing.Point(4, 22);
            this.tabPage_AutoCreation.Name = "tabPage_AutoCreation";
            this.tabPage_AutoCreation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_AutoCreation.Size = new System.Drawing.Size(494, 163);
            this.tabPage_AutoCreation.TabIndex = 1;
            this.tabPage_AutoCreation.Text = "AutoCreation";
            this.tabPage_AutoCreation.UseVisualStyleBackColor = true;
            // 
            // label_AutoCreateSize
            // 
            this.label_AutoCreateSize.AutoSize = true;
            this.label_AutoCreateSize.Location = new System.Drawing.Point(374, 9);
            this.label_AutoCreateSize.Name = "label_AutoCreateSize";
            this.label_AutoCreateSize.Size = new System.Drawing.Size(30, 13);
            this.label_AutoCreateSize.TabIndex = 17;
            this.label_AutoCreateSize.Text = "Size:";
            this.label_AutoCreateSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_AutoCreateSize
            // 
            this.comboBox_AutoCreateSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_AutoCreateSize.FormattingEnabled = true;
            this.comboBox_AutoCreateSize.Location = new System.Drawing.Point(410, 6);
            this.comboBox_AutoCreateSize.Name = "comboBox_AutoCreateSize";
            this.comboBox_AutoCreateSize.Size = new System.Drawing.Size(78, 21);
            this.comboBox_AutoCreateSize.TabIndex = 18;
            // 
            // textBox_WorldPath
            // 
            this.textBox_WorldPath.Location = new System.Drawing.Point(83, 31);
            this.textBox_WorldPath.Name = "textBox_WorldPath";
            this.textBox_WorldPath.Size = new System.Drawing.Size(234, 20);
            this.textBox_WorldPath.TabIndex = 14;
            // 
            // button_WorldPath
            // 
            this.button_WorldPath.Location = new System.Drawing.Point(3, 28);
            this.button_WorldPath.Name = "button_WorldPath";
            this.button_WorldPath.Size = new System.Drawing.Size(74, 24);
            this.button_WorldPath.TabIndex = 16;
            this.button_WorldPath.Text = "World Path:";
            this.button_WorldPath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_WorldPath.UseVisualStyleBackColor = true;
            this.button_WorldPath.Click += new System.EventHandler(this.button_WorldPath_Click);
            // 
            // textBox_WorldName
            // 
            this.textBox_WorldName.Location = new System.Drawing.Point(83, 6);
            this.textBox_WorldName.Name = "textBox_WorldName";
            this.textBox_WorldName.Size = new System.Drawing.Size(106, 20);
            this.textBox_WorldName.TabIndex = 15;
            // 
            // label_WorldName
            // 
            this.label_WorldName.AutoSize = true;
            this.label_WorldName.Location = new System.Drawing.Point(6, 9);
            this.label_WorldName.Margin = new System.Windows.Forms.Padding(3);
            this.label_WorldName.Name = "label_WorldName";
            this.label_WorldName.Size = new System.Drawing.Size(69, 13);
            this.label_WorldName.TabIndex = 13;
            this.label_WorldName.Text = "World Name:";
            this.label_WorldName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage_Backup
            // 
            this.tabPage_Backup.Controls.Add(this.label_AutosaveTimeRemaining);
            this.tabPage_Backup.Controls.Add(this.label_AutosaveTimeRemainingData);
            this.tabPage_Backup.Controls.Add(this.comboBox_AutosaveDelayFactor);
            this.tabPage_Backup.Controls.Add(this.label_AutoSaveDelay);
            this.tabPage_Backup.Controls.Add(this.numericUpDown_AutosaveDelay);
            this.tabPage_Backup.Controls.Add(this.checkBox_AutoSave);
            this.tabPage_Backup.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Backup.Name = "tabPage_Backup";
            this.tabPage_Backup.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Backup.Size = new System.Drawing.Size(494, 163);
            this.tabPage_Backup.TabIndex = 2;
            this.tabPage_Backup.Text = "Backup";
            this.tabPage_Backup.UseVisualStyleBackColor = true;
            // 
            // label_AutosaveTimeRemaining
            // 
            this.label_AutosaveTimeRemaining.AutoSize = true;
            this.label_AutosaveTimeRemaining.Location = new System.Drawing.Point(182, 30);
            this.label_AutosaveTimeRemaining.Name = "label_AutosaveTimeRemaining";
            this.label_AutosaveTimeRemaining.Size = new System.Drawing.Size(134, 13);
            this.label_AutosaveTimeRemaining.TabIndex = 5;
            this.label_AutosaveTimeRemaining.Text = "Autosave Time Remaining:";
            // 
            // label_AutosaveTimeRemainingData
            // 
            this.label_AutosaveTimeRemainingData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_AutosaveTimeRemainingData.Location = new System.Drawing.Point(322, 30);
            this.label_AutosaveTimeRemainingData.Name = "label_AutosaveTimeRemainingData";
            this.label_AutosaveTimeRemainingData.Size = new System.Drawing.Size(164, 13);
            this.label_AutosaveTimeRemainingData.TabIndex = 4;
            this.label_AutosaveTimeRemainingData.Text = "label_AutosaveTimeRemaining";
            // 
            // comboBox_AutosaveDelayFactor
            // 
            this.comboBox_AutosaveDelayFactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_AutosaveDelayFactor.FormattingEnabled = true;
            this.comboBox_AutosaveDelayFactor.Location = new System.Drawing.Point(399, 6);
            this.comboBox_AutosaveDelayFactor.Name = "comboBox_AutosaveDelayFactor";
            this.comboBox_AutosaveDelayFactor.Size = new System.Drawing.Size(89, 21);
            this.comboBox_AutosaveDelayFactor.TabIndex = 3;
            this.comboBox_AutosaveDelayFactor.SelectedIndexChanged += new System.EventHandler(this.comboBox_AutosaveDelayFactor_SelectedIndexChanged);
            // 
            // label_AutoSaveDelay
            // 
            this.label_AutoSaveDelay.AutoSize = true;
            this.label_AutoSaveDelay.Location = new System.Drawing.Point(182, 9);
            this.label_AutoSaveDelay.Name = "label_AutoSaveDelay";
            this.label_AutoSaveDelay.Size = new System.Drawing.Size(85, 13);
            this.label_AutoSaveDelay.TabIndex = 2;
            this.label_AutoSaveDelay.Text = "Autosave Delay:";
            // 
            // numericUpDown_AutosaveDelay
            // 
            this.numericUpDown_AutosaveDelay.Location = new System.Drawing.Point(273, 7);
            this.numericUpDown_AutosaveDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_AutosaveDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_AutosaveDelay.Name = "numericUpDown_AutosaveDelay";
            this.numericUpDown_AutosaveDelay.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_AutosaveDelay.TabIndex = 1;
            this.numericUpDown_AutosaveDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_AutosaveDelay.ValueChanged += new System.EventHandler(this.numericUpDown_AutosaveDelay_ValueChanged);
            // 
            // checkBox_AutoSave
            // 
            this.checkBox_AutoSave.AutoSize = true;
            this.checkBox_AutoSave.Checked = true;
            this.checkBox_AutoSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_AutoSave.Location = new System.Drawing.Point(8, 8);
            this.checkBox_AutoSave.Name = "checkBox_AutoSave";
            this.checkBox_AutoSave.Size = new System.Drawing.Size(76, 17);
            this.checkBox_AutoSave.TabIndex = 0;
            this.checkBox_AutoSave.Text = "Auto Save";
            this.checkBox_AutoSave.UseVisualStyleBackColor = true;
            this.checkBox_AutoSave.CheckedChanged += new System.EventHandler(this.checkBox_AutoSave_CheckedChanged);
            // 
            // tabPage_Logging
            // 
            this.tabPage_Logging.Controls.Add(this.label_LogError);
            this.tabPage_Logging.Controls.Add(this.numericUpDown_LogFileSizeLimit);
            this.tabPage_Logging.Controls.Add(this.label_LogFileSizeLimitInfo);
            this.tabPage_Logging.Controls.Add(this.comboBox_LogProcedureWhenFull);
            this.tabPage_Logging.Controls.Add(this.label_LogProcedureWhenFull);
            this.tabPage_Logging.Controls.Add(this.label_LogFileSizeLimitUnit);
            this.tabPage_Logging.Controls.Add(this.label1);
            this.tabPage_Logging.Controls.Add(this.label_LogFilenamePrefix);
            this.tabPage_Logging.Controls.Add(this.textBox_LogFilenamePrefix);
            this.tabPage_Logging.Controls.Add(this.button_LoggingFolder);
            this.tabPage_Logging.Controls.Add(this.textBox_LogFolder);
            this.tabPage_Logging.Controls.Add(this.checkBox_Logging);
            this.tabPage_Logging.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Logging.Name = "tabPage_Logging";
            this.tabPage_Logging.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Logging.Size = new System.Drawing.Size(494, 163);
            this.tabPage_Logging.TabIndex = 3;
            this.tabPage_Logging.Text = "Logging";
            this.tabPage_Logging.UseVisualStyleBackColor = true;
            // 
            // label_LogFilenamePrefix
            // 
            this.label_LogFilenamePrefix.AutoSize = true;
            this.label_LogFilenamePrefix.Location = new System.Drawing.Point(76, 32);
            this.label_LogFilenamePrefix.Name = "label_LogFilenamePrefix";
            this.label_LogFilenamePrefix.Size = new System.Drawing.Size(102, 13);
            this.label_LogFilenamePrefix.TabIndex = 4;
            this.label_LogFilenamePrefix.Text = "Log Filename Prefix:";
            // 
            // textBox_LogFilenamePrefix
            // 
            this.textBox_LogFilenamePrefix.Location = new System.Drawing.Point(197, 29);
            this.textBox_LogFilenamePrefix.Name = "textBox_LogFilenamePrefix";
            this.textBox_LogFilenamePrefix.Size = new System.Drawing.Size(289, 20);
            this.textBox_LogFilenamePrefix.TabIndex = 3;
            // 
            // button_LoggingFolder
            // 
            this.button_LoggingFolder.Location = new System.Drawing.Point(79, 3);
            this.button_LoggingFolder.Name = "button_LoggingFolder";
            this.button_LoggingFolder.Size = new System.Drawing.Size(75, 23);
            this.button_LoggingFolder.TabIndex = 2;
            this.button_LoggingFolder.Text = "Log Folder:";
            this.button_LoggingFolder.UseVisualStyleBackColor = true;
            this.button_LoggingFolder.Click += new System.EventHandler(this.button_LoggingFolder_Click);
            // 
            // textBox_LogFolder
            // 
            this.textBox_LogFolder.Location = new System.Drawing.Point(197, 5);
            this.textBox_LogFolder.Name = "textBox_LogFolder";
            this.textBox_LogFolder.Size = new System.Drawing.Size(291, 20);
            this.textBox_LogFolder.TabIndex = 1;
            // 
            // checkBox_Logging
            // 
            this.checkBox_Logging.AutoSize = true;
            this.checkBox_Logging.Checked = true;
            this.checkBox_Logging.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Logging.Location = new System.Drawing.Point(9, 7);
            this.checkBox_Logging.Name = "checkBox_Logging";
            this.checkBox_Logging.Size = new System.Drawing.Size(64, 17);
            this.checkBox_Logging.TabIndex = 0;
            this.checkBox_Logging.Text = "Logging";
            this.checkBox_Logging.UseVisualStyleBackColor = true;
            this.checkBox_Logging.CheckedChanged += new System.EventHandler(this.checkBox_Logging_CheckedChanged);
            // 
            // splitContainer_Console
            // 
            this.splitContainer_Console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Console.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Console.Name = "splitContainer_Console";
            this.splitContainer_Console.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_Console.Panel1
            // 
            this.splitContainer_Console.Panel1.Controls.Add(this.richTextBox_Console);
            // 
            // splitContainer_Console.Panel2
            // 
            this.splitContainer_Console.Panel2.Controls.Add(this.textBox_Execute);
            this.splitContainer_Console.Panel2.Controls.Add(this.button_Execute);
            this.splitContainer_Console.Size = new System.Drawing.Size(502, 122);
            this.splitContainer_Console.SplitterDistance = 85;
            this.splitContainer_Console.SplitterWidth = 1;
            this.splitContainer_Console.TabIndex = 3;
            // 
            // richTextBox_Console
            // 
            this.richTextBox_Console.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox_Console.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_Console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_Console.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_Console.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBox_Console.Name = "richTextBox_Console";
            this.richTextBox_Console.ReadOnly = true;
            this.richTextBox_Console.Size = new System.Drawing.Size(502, 85);
            this.richTextBox_Console.TabIndex = 0;
            this.richTextBox_Console.Text = "";
            // 
            // textBox_Execute
            // 
            this.textBox_Execute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Execute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_Execute.Location = new System.Drawing.Point(0, 2);
            this.textBox_Execute.Margin = new System.Windows.Forms.Padding(0, 2, 0, 4);
            this.textBox_Execute.Multiline = true;
            this.textBox_Execute.Name = "textBox_Execute";
            this.textBox_Execute.Size = new System.Drawing.Size(412, 30);
            this.textBox_Execute.TabIndex = 1;
            this.textBox_Execute.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Execute_KeyDown);
            // 
            // button_Execute
            // 
            this.button_Execute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Execute.Location = new System.Drawing.Point(412, 0);
            this.button_Execute.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.button_Execute.Name = "button_Execute";
            this.button_Execute.Size = new System.Drawing.Size(90, 34);
            this.button_Execute.TabIndex = 2;
            this.button_Execute.Text = "Execute";
            this.button_Execute.UseVisualStyleBackColor = true;
            this.button_Execute.Click += new System.EventHandler(this.button_Execute_Click);
            // 
            // toolStrip_Header
            // 
            this.toolStrip_Header.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip_Header.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_Header.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton_File,
            this.toolStripButton_StartServer});
            this.toolStrip_Header.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Header.Name = "toolStrip_Header";
            this.toolStrip_Header.Size = new System.Drawing.Size(502, 25);
            this.toolStrip_Header.Stretch = true;
            this.toolStrip_Header.TabIndex = 1;
            this.toolStrip_Header.Text = "toolStrip_Header";
            // 
            // toolStripDropDownButton_File
            // 
            this.toolStripDropDownButton_File.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Exit});
            this.toolStripDropDownButton_File.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_File.Image")));
            this.toolStripDropDownButton_File.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_File.Name = "toolStripDropDownButton_File";
            this.toolStripDropDownButton_File.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton_File.Text = "File";
            // 
            // toolStripMenuItem_Exit
            // 
            this.toolStripMenuItem_Exit.Name = "toolStripMenuItem_Exit";
            this.toolStripMenuItem_Exit.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuItem_Exit.Text = "Exit";
            this.toolStripMenuItem_Exit.Click += new System.EventHandler(this.toolStripMenuItem_Exit_Click);
            // 
            // toolStripButton_StartServer
            // 
            this.toolStripButton_StartServer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_StartServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_StartServer.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_StartServer.Image")));
            this.toolStripButton_StartServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_StartServer.Name = "toolStripButton_StartServer";
            this.toolStripButton_StartServer.Size = new System.Drawing.Size(70, 22);
            this.toolStripButton_StartServer.Text = "Start Server";
            this.toolStripButton_StartServer.Click += new System.EventHandler(this.toolStripButton_StartServer_Click);
            // 
            // toolStripContainer_Main
            // 
            // 
            // toolStripContainer_Main.BottomToolStripPanel
            // 
            this.toolStripContainer_Main.BottomToolStripPanel.Controls.Add(this.toolStrip_Footer);
            // 
            // toolStripContainer_Main.ContentPanel
            // 
            this.toolStripContainer_Main.ContentPanel.AutoScroll = true;
            this.toolStripContainer_Main.ContentPanel.Controls.Add(this.splitContainer_Main);
            this.toolStripContainer_Main.ContentPanel.Size = new System.Drawing.Size(502, 312);
            this.toolStripContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer_Main.LeftToolStripPanelVisible = false;
            this.toolStripContainer_Main.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer_Main.Name = "toolStripContainer_Main";
            this.toolStripContainer_Main.RightToolStripPanelVisible = false;
            this.toolStripContainer_Main.Size = new System.Drawing.Size(502, 387);
            this.toolStripContainer_Main.TabIndex = 3;
            this.toolStripContainer_Main.Text = "toolStripContainer1";
            // 
            // toolStripContainer_Main.TopToolStripPanel
            // 
            this.toolStripContainer_Main.TopToolStripPanel.Controls.Add(this.toolStrip_Header);
            this.toolStripContainer_Main.TopToolStripPanel.Controls.Add(this.toolStrip_Config);
            // 
            // toolStrip_Footer
            // 
            this.toolStrip_Footer.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip_Footer.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_Footer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_StatusIcon,
            this.toolStripLabel_StatusText,
            this.toolStripProgressBar_Main});
            this.toolStrip_Footer.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Footer.Name = "toolStrip_Footer";
            this.toolStrip_Footer.Size = new System.Drawing.Size(502, 25);
            this.toolStrip_Footer.Stretch = true;
            this.toolStrip_Footer.TabIndex = 1;
            // 
            // toolStripButton_StatusIcon
            // 
            this.toolStripButton_StatusIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_StatusIcon.Image = global::TerrariaServerCS.Properties.Resources.Bunny;
            this.toolStripButton_StatusIcon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_StatusIcon.Name = "toolStripButton_StatusIcon";
            this.toolStripButton_StatusIcon.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_StatusIcon.Text = "toolStripButton1";
            // 
            // toolStripLabel_StatusText
            // 
            this.toolStripLabel_StatusText.Name = "toolStripLabel_StatusText";
            this.toolStripLabel_StatusText.Size = new System.Drawing.Size(139, 22);
            this.toolStripLabel_StatusText.Text = "toolStripLabel_StatusText";
            // 
            // toolStripProgressBar_Main
            // 
            this.toolStripProgressBar_Main.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar_Main.Name = "toolStripProgressBar_Main";
            this.toolStripProgressBar_Main.Size = new System.Drawing.Size(100, 22);
            // 
            // toolStrip_Config
            // 
            this.toolStrip_Config.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip_Config.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_ConfigFile,
            this.toolStripComboBox_ConfigFile,
            this.toolStripButton_ConfigFileSave,
            this.toolStripButton_ConfigFileSaveAs,
            this.toolStripButton_ConfigFileDelete});
            this.toolStrip_Config.Location = new System.Drawing.Point(0, 25);
            this.toolStrip_Config.Name = "toolStrip_Config";
            this.toolStrip_Config.Size = new System.Drawing.Size(502, 25);
            this.toolStrip_Config.Stretch = true;
            this.toolStrip_Config.TabIndex = 2;
            // 
            // toolStripButton_ConfigFile
            // 
            this.toolStripButton_ConfigFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_ConfigFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ConfigFileOpenDirectory,
            this.toolStripMenuItem_ConfigFileRename});
            this.toolStripButton_ConfigFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_ConfigFile.Image")));
            this.toolStripButton_ConfigFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ConfigFile.Name = "toolStripButton_ConfigFile";
            this.toolStripButton_ConfigFile.Size = new System.Drawing.Size(77, 22);
            this.toolStripButton_ConfigFile.Text = "Config File";
            // 
            // toolStripMenuItem_ConfigFileRename
            // 
            this.toolStripMenuItem_ConfigFileRename.Enabled = false;
            this.toolStripMenuItem_ConfigFileRename.Name = "toolStripMenuItem_ConfigFileRename";
            this.toolStripMenuItem_ConfigFileRename.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem_ConfigFileRename.Text = "Rename";
            // 
            // toolStripComboBox_ConfigFile
            // 
            this.toolStripComboBox_ConfigFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox_ConfigFile.DropDownWidth = 250;
            this.toolStripComboBox_ConfigFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolStripComboBox_ConfigFile.Name = "toolStripComboBox_ConfigFile";
            this.toolStripComboBox_ConfigFile.Size = new System.Drawing.Size(250, 25);
            this.toolStripComboBox_ConfigFile.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox_ConfigFile_SelectedIndexChanged);
            // 
            // toolStripButton_ConfigFileSave
            // 
            this.toolStripButton_ConfigFileSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_ConfigFileSave.Enabled = false;
            this.toolStripButton_ConfigFileSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_ConfigFileSave.Image")));
            this.toolStripButton_ConfigFileSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ConfigFileSave.Name = "toolStripButton_ConfigFileSave";
            this.toolStripButton_ConfigFileSave.Size = new System.Drawing.Size(35, 22);
            this.toolStripButton_ConfigFileSave.Text = "Save";
            this.toolStripButton_ConfigFileSave.Click += new System.EventHandler(this.toolStripButton_ConfigFileSave_Click);
            // 
            // toolStripButton_ConfigFileSaveAs
            // 
            this.toolStripButton_ConfigFileSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_ConfigFileSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_ConfigFileSaveAs.Image")));
            this.toolStripButton_ConfigFileSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ConfigFileSaveAs.Name = "toolStripButton_ConfigFileSaveAs";
            this.toolStripButton_ConfigFileSaveAs.Size = new System.Drawing.Size(51, 22);
            this.toolStripButton_ConfigFileSaveAs.Text = "Save As";
            this.toolStripButton_ConfigFileSaveAs.Click += new System.EventHandler(this.toolStripButton_ConfigFileSaveAs_Click);
            // 
            // toolStripButton_ConfigFileDelete
            // 
            this.toolStripButton_ConfigFileDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_ConfigFileDelete.Enabled = false;
            this.toolStripButton_ConfigFileDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_ConfigFileDelete.Image")));
            this.toolStripButton_ConfigFileDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ConfigFileDelete.Name = "toolStripButton_ConfigFileDelete";
            this.toolStripButton_ConfigFileDelete.Size = new System.Drawing.Size(44, 22);
            this.toolStripButton_ConfigFileDelete.Text = "Delete";
            this.toolStripButton_ConfigFileDelete.Click += new System.EventHandler(this.toolStripButton_ConfigFileDelete_Click);
            // 
            // timer_Autosave
            // 
            this.timer_Autosave.Enabled = true;
            this.timer_Autosave.Interval = 60000;
            this.timer_Autosave.Tick += new System.EventHandler(this.timer_Autosave_Tick);
            // 
            // timer_Main
            // 
            this.timer_Main.Enabled = true;
            this.timer_Main.Interval = 1000;
            this.timer_Main.Tick += new System.EventHandler(this.timer_Main_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(76, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Log File Size Limit:";
            // 
            // label_LogFileSizeLimitUnit
            // 
            this.label_LogFileSizeLimitUnit.AutoSize = true;
            this.label_LogFileSizeLimitUnit.Enabled = false;
            this.label_LogFileSizeLimitUnit.Location = new System.Drawing.Point(303, 59);
            this.label_LogFileSizeLimitUnit.Name = "label_LogFileSizeLimitUnit";
            this.label_LogFileSizeLimitUnit.Size = new System.Drawing.Size(23, 13);
            this.label_LogFileSizeLimitUnit.TabIndex = 7;
            this.label_LogFileSizeLimitUnit.Text = "MB";
            // 
            // label_LogProcedureWhenFull
            // 
            this.label_LogProcedureWhenFull.AutoSize = true;
            this.label_LogProcedureWhenFull.Enabled = false;
            this.label_LogProcedureWhenFull.Location = new System.Drawing.Point(76, 86);
            this.label_LogProcedureWhenFull.Name = "label_LogProcedureWhenFull";
            this.label_LogProcedureWhenFull.Size = new System.Drawing.Size(110, 13);
            this.label_LogProcedureWhenFull.TabIndex = 8;
            this.label_LogProcedureWhenFull.Text = "Procedure When Full:";
            // 
            // comboBox_LogProcedureWhenFull
            // 
            this.comboBox_LogProcedureWhenFull.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_LogProcedureWhenFull.Enabled = false;
            this.comboBox_LogProcedureWhenFull.FormattingEnabled = true;
            this.comboBox_LogProcedureWhenFull.Location = new System.Drawing.Point(197, 83);
            this.comboBox_LogProcedureWhenFull.Name = "comboBox_LogProcedureWhenFull";
            this.comboBox_LogProcedureWhenFull.Size = new System.Drawing.Size(121, 21);
            this.comboBox_LogProcedureWhenFull.TabIndex = 9;
            // 
            // label_LogFileSizeLimitInfo
            // 
            this.label_LogFileSizeLimitInfo.AutoSize = true;
            this.label_LogFileSizeLimitInfo.Enabled = false;
            this.label_LogFileSizeLimitInfo.Location = new System.Drawing.Point(347, 59);
            this.label_LogFileSizeLimitInfo.Name = "label_LogFileSizeLimitInfo";
            this.label_LogFileSizeLimitInfo.Size = new System.Drawing.Size(136, 13);
            this.label_LogFileSizeLimitInfo.TabIndex = 10;
            this.label_LogFileSizeLimitInfo.Text = "<- (A value of 0 is unlimited)";
            this.label_LogFileSizeLimitInfo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numericUpDown_LogFileSizeLimit
            // 
            this.numericUpDown_LogFileSizeLimit.Enabled = false;
            this.numericUpDown_LogFileSizeLimit.Location = new System.Drawing.Point(197, 57);
            this.numericUpDown_LogFileSizeLimit.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDown_LogFileSizeLimit.Name = "numericUpDown_LogFileSizeLimit";
            this.numericUpDown_LogFileSizeLimit.Size = new System.Drawing.Size(100, 20);
            this.numericUpDown_LogFileSizeLimit.TabIndex = 11;
            // 
            // label_LogError
            // 
            this.label_LogError.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_LogError.ForeColor = System.Drawing.Color.Red;
            this.label_LogError.Location = new System.Drawing.Point(3, 147);
            this.label_LogError.Name = "label_LogError";
            this.label_LogError.Size = new System.Drawing.Size(488, 13);
            this.label_LogError.TabIndex = 12;
            this.label_LogError.Text = "label_LogError";
            // 
            // toolStripMenuItem_ConfigFileOpenDirectory
            // 
            this.toolStripMenuItem_ConfigFileOpenDirectory.Name = "toolStripMenuItem_ConfigFileOpenDirectory";
            this.toolStripMenuItem_ConfigFileOpenDirectory.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem_ConfigFileOpenDirectory.Text = "Explore Config Directory";
            this.toolStripMenuItem_ConfigFileOpenDirectory.Click += new System.EventHandler(this.toolStripMenuItem_ConfigFileOpenDirectory_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(502, 387);
            this.Controls.Add(this.toolStripContainer_Main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Terraria Server GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.splitContainer_Main.Panel1.ResumeLayout(false);
            this.splitContainer_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).EndInit();
            this.splitContainer_Main.ResumeLayout(false);
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage_Startup.ResumeLayout(false);
            this.tabPage_Startup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Port)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Players)).EndInit();
            this.tabPage_AutoCreation.ResumeLayout(false);
            this.tabPage_AutoCreation.PerformLayout();
            this.tabPage_Backup.ResumeLayout(false);
            this.tabPage_Backup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AutosaveDelay)).EndInit();
            this.tabPage_Logging.ResumeLayout(false);
            this.tabPage_Logging.PerformLayout();
            this.splitContainer_Console.Panel1.ResumeLayout(false);
            this.splitContainer_Console.Panel2.ResumeLayout(false);
            this.splitContainer_Console.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Console)).EndInit();
            this.splitContainer_Console.ResumeLayout(false);
            this.toolStrip_Header.ResumeLayout(false);
            this.toolStrip_Header.PerformLayout();
            this.toolStripContainer_Main.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer_Main.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer_Main.ContentPanel.ResumeLayout(false);
            this.toolStripContainer_Main.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer_Main.TopToolStripPanel.PerformLayout();
            this.toolStripContainer_Main.ResumeLayout(false);
            this.toolStripContainer_Main.PerformLayout();
            this.toolStrip_Footer.ResumeLayout(false);
            this.toolStrip_Footer.PerformLayout();
            this.toolStrip_Config.ResumeLayout(false);
            this.toolStrip_Config.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_LogFileSizeLimit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog_Main;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_Main;
        private System.Windows.Forms.SplitContainer splitContainer_Main;
        private System.Windows.Forms.TabControl tabControl_Main;
        private System.Windows.Forms.TabPage tabPage_Startup;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.TextBox textBox_BanList;
        private System.Windows.Forms.Button button_BanList;
        private System.Windows.Forms.CheckBox checkBox_Secure;
        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.NumericUpDown numericUpDown_Port;
        private System.Windows.Forms.TextBox textBox_MODT;
        private System.Windows.Forms.Label label_MODT;
        private System.Windows.Forms.Label label_Players;
        private System.Windows.Forms.TextBox textBox_World;
        private System.Windows.Forms.Button button_World;
        private System.Windows.Forms.Button button_ServerPath;
        private System.Windows.Forms.TextBox textBox_ServerPath;
        private System.Windows.Forms.Label label_ServerType;
        private System.Windows.Forms.NumericUpDown numericUpDown_Players;
        private System.Windows.Forms.ComboBox comboBox_ServerType;
        private System.Windows.Forms.TabPage tabPage_AutoCreation;
        private System.Windows.Forms.Label label_AutoCreateSize;
        private System.Windows.Forms.ComboBox comboBox_AutoCreateSize;
        private System.Windows.Forms.TextBox textBox_WorldPath;
        private System.Windows.Forms.Button button_WorldPath;
        private System.Windows.Forms.TextBox textBox_WorldName;
        private System.Windows.Forms.Label label_WorldName;
        private System.Windows.Forms.TabPage tabPage_Backup;
        private System.Windows.Forms.Button button_Execute;
        private System.Windows.Forms.RichTextBox richTextBox_Console;
        private System.Windows.Forms.TextBox textBox_Execute;
        private System.Windows.Forms.ToolStrip toolStrip_Header;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_File;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Exit;
        private System.Windows.Forms.ToolStripButton toolStripButton_StartServer;
        private System.Windows.Forms.ToolStripContainer toolStripContainer_Main;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ToolStrip toolStrip_Footer;
        private System.Windows.Forms.ToolStripButton toolStripButton_StatusIcon;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_StatusText;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar_Main;
        private System.Windows.Forms.ToolStrip toolStrip_Config;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_ConfigFile;
        private System.Windows.Forms.ToolStripButton toolStripButton_ConfigFileSave;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton_ConfigFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ConfigFileRename;
        private System.Windows.Forms.ToolStripButton toolStripButton_ConfigFileSaveAs;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_Config;
        private System.Windows.Forms.ToolStripButton toolStripButton_ConfigFileDelete;
        private System.Windows.Forms.SplitContainer splitContainer_Console;
        private System.Windows.Forms.CheckBox checkBox_AutoSave;
        private System.Windows.Forms.Label label_AutoSaveDelay;
        private System.Windows.Forms.NumericUpDown numericUpDown_AutosaveDelay;
        private System.Windows.Forms.ComboBox comboBox_AutosaveDelayFactor;
        private System.Windows.Forms.Timer timer_Autosave;
        private System.Windows.Forms.Label label_AutosaveTimeRemaining;
        private System.Windows.Forms.Label label_AutosaveTimeRemainingData;
        private System.Windows.Forms.Timer timer_Main;
        private System.Windows.Forms.TabPage tabPage_Logging;
        private System.Windows.Forms.CheckBox checkBox_Logging;
        private System.Windows.Forms.Button button_LoggingFolder;
        private System.Windows.Forms.TextBox textBox_LogFolder;
        private System.Windows.Forms.Label label_LogFilenamePrefix;
        private System.Windows.Forms.TextBox textBox_LogFilenamePrefix;
        private System.Windows.Forms.Label label_LogFileSizeLimitInfo;
        private System.Windows.Forms.ComboBox comboBox_LogProcedureWhenFull;
        private System.Windows.Forms.Label label_LogProcedureWhenFull;
        private System.Windows.Forms.Label label_LogFileSizeLimitUnit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_LogFileSizeLimit;
        private System.Windows.Forms.Label label_LogError;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ConfigFileOpenDirectory;
    }
}

