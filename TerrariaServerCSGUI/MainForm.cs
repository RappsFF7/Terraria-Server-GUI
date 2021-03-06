﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TerrariaServerCS;
using TerrariaServerCS.Classes;
using System.IO;
using System.Diagnostics;

namespace TerrariaServerGUI
{
    public partial class MainForm : Form
    {
        #region enums
        private enum enumFormState
        {
            stopped,
            stopping,
            started,
            starting,
            error
        }

        private enum enumTheme
        {
            Default,
            Red
        }
        #endregion

        #region events & delegates
        #endregion

        #region variables
        private enumFormState moFormState;
        private absTerrariaServer moTerrariaServer;
        private DateTime moLastAutosave;
        #endregion

        #region properties
        #endregion

        public MainForm()
        {
            InitializeComponent();
            initialize();
        }

        #region methods - intializers and loads
        /// <summary>
        /// Initialize code that was not auto generated
        /// </summary>
        private void initialize()
        {
            // Load drop downs
            comboBox_ServerType.DataSource = Enum.GetNames(typeof(enumTerrariaServer));
            comboBox_ServerType.SelectedIndex = 0;
            comboBox_Lobby.DataSource = Enum.GetNames(typeof(enumSteamLobby));
            comboBox_Lobby.SelectedIndex = 0;

            // Initialize the server object (to get the default server path)
            initializeServerObject((enumTerrariaServer)Enum.Parse(typeof(enumTerrariaServer), comboBox_ServerType.SelectedItem.ToString()));

            // Load the default server location
            textBox_ServerPath.Text = moTerrariaServer.ServerExecutableLocation;
            
            // Initialize drop downs
            //  force gui state drop down
            (Enum.GetNames(typeof(enumFormState))).ToList().ForEach(s =>
                toolStripMenuItem_ForceGuiState.DropDownItems.Add(new ToolStripMenuItem(s, null, toolStripComboBox_ForceGuiState_MenuItems_Click)));
            //  world creation size drop down
            comboBox_AutoCreateSize.DataSource = Enum.GetNames(typeof(TerrariaServerCS.enumTerrariaServerSize));
            //  server type drop down
            comboBox_ServerType.DataSource = Enum.GetNames(typeof(TerrariaServerCS.enumTerrariaServer));
            //  autosave factor drop down
            comboBox_AutosaveDelayFactor.DataSource = Enum.GetNames(typeof(TerrariaServerCS.enumTerrariaBackupFactor));
            //  logging full procedure drop down
            comboBox_LogProcedureWhenFull.DataSource = Enum.GetNames(typeof(TerrariaServerCS.enumTerrariaLogFileFullProcedure)).Select(s => s.Replace("_", " ")).ToArray();
            
            // Load the available config files
            refreshConfigFileList("");

            // Load config data from the config file
            loadArgumentsToForm(moTerrariaServer.ServerStartArguments);

            // Set initial form state
            doTSUpdateFormState(enumFormState.stopped);
            
            // Modify the default settings on the config file save dialog
            saveFileDialog_Config.DefaultExt = moTerrariaServer.ServerStartArguments._DefaultConfigFileExtention;
            saveFileDialog_Config.FileName = moTerrariaServer.ServerStartArguments._DefaultConfigFileName;
            saveFileDialog_Config.Filter = "Terraria Server GUI Config File|*." + moTerrariaServer.ServerStartArguments._DefaultConfigFileExtention;
        
            // Start timers
            moLastAutosave = DateTime.Now;
            timer_Main.Start();

            // Clear the log error text
            label_LogError.Text = "";

            // Handle startup command line args
            initializeCommandArgs();
        }

        private void initializeServerObject(enumTerrariaServer toServerType)
        {
            // Get a new server object
            moTerrariaServer = TerrariaServerFactory.newServer(toServerType);

            // Setup server process callbacks
            moTerrariaServer.DataRecievedOutput += new TerrariaServerEventHandler(moTerrariaServer_DataRecievedOutput);
            moTerrariaServer.DataRecievedError += new TerrariaServerEventHandler(moTerrariaServer_DataRecievedError);
            moTerrariaServer.ServerCommandComplete += new TerrariaServerEventHandler(moTerrariaServer_ServerCommandComplete);

            // Setup form field callbacks
            checkBox_AutoSave.CheckedChanged += saveableOption_OnChange;
            numericUpDown_AutosaveDelay.ValueChanged += saveableOption_OnChange;
            comboBox_AutosaveDelayFactor.SelectedIndexChanged += saveableOption_OnChange;
            textBox_ServerPath.TextChanged += saveableOption_OnChange;
            comboBox_ServerType.SelectedIndexChanged += saveableOption_OnChange;
            textBox_LogFolder.TextChanged += saveableOption_OnChange;
            textBox_LogFilenamePrefix.TextChanged += saveableOption_OnChange;
            numericUpDown_LogFileSizeLimit.ValueChanged += saveableOption_OnChange;
            comboBox_LogProcedureWhenFull.SelectedIndexChanged += saveableOption_OnChange;
            checkBox_LogPercentageCollapsed.CheckedChanged += saveableOption_OnChange;

            textBox_ServerPath.TextChanged += saveableOption_OnChange;
            textBox_World.TextChanged += saveableOption_OnChange;
            textBox_MODT.TextChanged += saveableOption_OnChange;
            textBox_BanList.TextChanged += saveableOption_OnChange;
            comboBox_ServerType.SelectedIndexChanged += saveableOption_OnChange;
            textBox_Password.TextChanged += saveableOption_OnChange;
            numericUpDown_Players.ValueChanged += saveableOption_OnChange;
            numericUpDown_Port.ValueChanged += saveableOption_OnChange;
            checkBox_Secure.CheckStateChanged += saveableOption_OnChange;
            textBox_WorldName.TextChanged += saveableOption_OnChange;
            textBox_WorldPath.TextChanged += saveableOption_OnChange;
            comboBox_AutoCreateSize.SelectedIndexChanged += saveableOption_OnChange;
            comboBox_Lobby.SelectedIndexChanged += saveableOption_OnChange;
            checkBox_Difficulty.CheckedChanged += saveableOption_OnChange;
            checkBox_UPNP.CheckedChanged += saveableOption_OnChange;
        }

        private void initializeCommandArgs()
        {
            // First argument is the path of the executable, so we ignore it
            string[] args = Environment.GetCommandLineArgs();
            for (int n = 1; n < args.Length; n++)
            {
                string key = args[n];
                string val = (n + 1 < args.Length ? args[++n] : null);
                switch (key.ToLower())
                {
                    case "-start":
                        toolStripComboBox_ConfigFile.Text = val;
                        if (toolStripComboBox_ConfigFile.Text == val) { 
                            doTSOutput("Auto-Starting : " + val);
                            toolStripButton_StartServer.PerformClick();
                        } else {
                            doTSOutput("Unable to find: " + val);
                        }
                        break;
                    default:
                        doTSOutput("Unknown argument: " + key);
                        break;
                }
            }
        }

        private void loadArgumentsToForm(absTerrariaServerArguments poArgs)
        {
            // GUI options
            checkBox_AutoSave.Checked = (poArgs.TSG_AutoSave == 0 ? false : true);
            numericUpDown_AutosaveDelay.Value = poArgs.TSG_AutoSaveDelay;
            comboBox_AutosaveDelayFactor.SelectedIndex = poArgs.TSG_AutoSaveFactor - 1;
            textBox_ServerPath.Text = poArgs.TSG_ServerPath;
            comboBox_ServerType.SelectedIndex = poArgs.TSG_ServerType - 1;
            textBox_LogFolder.Text = poArgs.TSG_LogFolder;
            textBox_LogFilenamePrefix.Text = poArgs.TSG_LogFilePrefix;
            numericUpDown_LogFileSizeLimit.Value = poArgs.TSG_LogFileSizeLimit;
            comboBox_LogProcedureWhenFull.SelectedIndex = poArgs.TSG_LogFileFullProcedure - 1;
            checkBox_LogPercentageCollapsed.Checked = (poArgs.TSG_LogPercentagesCollapsed == 0 ? false : true);

            // Server options
            numericUpDown_Players.Value = poArgs.Players;
            textBox_World.Text = poArgs.World;
            numericUpDown_Port.Value = poArgs.Port;
            textBox_Password.Text = poArgs.Password;
            textBox_MODT.Text = poArgs.MOTD;
            textBox_WorldPath.Text = poArgs.WorldPath;
            comboBox_AutoCreateSize.SelectedIndex = poArgs.AutoCreate - 1;
            textBox_WorldName.Text = poArgs.WorldName;
            textBox_BanList.Text = poArgs.BanList;
            checkBox_Secure.Checked = (poArgs.Secure == 0 ? false : true);
            checkBox_Difficulty.Checked = (poArgs.Difficulty == 0 ? false : true);
            checkBox_UPNP.Checked = poArgs.NoUPNP;
            comboBox_Lobby.SelectedIndex = comboBox_Lobby.FindString(poArgs.Lobby);

            // Disable the save button as the most recent file info is now displayed in the form
            toolStripButton_ConfigFileSave.Enabled = false;

            // Move the cursor for serveral text fields to the right (so you can see the filename)
            textBox_ServerPath.SelectionStart = textBox_ServerPath.Text.Length;
            textBox_World.SelectionStart = textBox_World.Text.Length;
            textBox_WorldPath.SelectionStart = textBox_WorldPath.Text.Length;
            textBox_LogFolder.SelectionStart = textBox_LogFolder.Text.Length;
        }

        private void saveArgumentsToObject(absTerrariaServerArguments poArgs)
        {
            // GUI options
            poArgs.TSG_AutoSave = (checkBox_AutoSave.Checked ? 1 : 0);
            poArgs.TSG_AutoSaveDelay = Convert.ToInt32(numericUpDown_AutosaveDelay.Value);
            poArgs.TSG_AutoSaveFactor = comboBox_AutosaveDelayFactor.SelectedIndex + 1;
            poArgs.TSG_ServerPath = textBox_ServerPath.Text;
            poArgs.TSG_ServerType = comboBox_ServerType.SelectedIndex + 1;
            poArgs.TSG_LogFolder = textBox_LogFolder.Text;
            poArgs.TSG_LogFilePrefix = textBox_LogFilenamePrefix.Text;
            poArgs.TSG_LogFileSizeLimit = Convert.ToInt32(numericUpDown_LogFileSizeLimit.Value);
            poArgs.TSG_LogFileFullProcedure = comboBox_LogProcedureWhenFull.SelectedIndex + 1;
            poArgs.TSG_LogPercentagesCollapsed = (checkBox_LogPercentageCollapsed.Checked ? 1 : 0);
            
            // Server options
            poArgs.Players = Convert.ToInt32(numericUpDown_Players.Value);
            poArgs.World = textBox_World.Text;
            poArgs.Port = Convert.ToInt32(numericUpDown_Port.Value);
            poArgs.Password = textBox_Password.Text;
            poArgs.MOTD = textBox_MODT.Text;
            poArgs.WorldPath = textBox_WorldPath.Text;
            poArgs.AutoCreate = comboBox_AutoCreateSize.SelectedIndex + 1;
            poArgs.WorldName = textBox_WorldName.Text;
            poArgs.BanList = textBox_BanList.Text;
            poArgs.Secure = (checkBox_Secure.Checked ? 1 : 0);
            poArgs.Difficulty = (checkBox_Difficulty.Checked ? 1 : 0);
            poArgs.NoUPNP = checkBox_UPNP.Checked;
            poArgs.Lobby = comboBox_Lobby.SelectedValue.ToString();

            // The steam value is based on the lobby choice
            enumSteamLobby lobbyEnum = (enumSteamLobby)
                Enum.Parse(typeof(enumSteamLobby), comboBox_Lobby.SelectedValue.ToString());
            poArgs.Steam = (lobbyEnum == enumSteamLobby.NoSteamSupport ? false : true);
        }

        private void saveConfigFile()
        {
            // If the config drop down has an item selected, use that filename
            string tsFileName = (toolStripComboBox_ConfigFile.SelectedItem ?? "").ToString();

            // Save the config file
            saveConfigFile(tsFileName);
        }

        /// <summary>
        /// Saves the current options to the server object and then to a config file.
        /// Supplying an empty string for the file will draw from the currently selected config file in the application.
        /// </summary>
        /// <param name="tsConfigFile"></param>
        private void saveConfigFile(string tsConfigFilePathAndName)
        {
            string tsConfigFile = Path.GetFileName(tsConfigFilePathAndName);
            string tsExtension = Path.GetExtension(tsConfigFilePathAndName);

            // Check if the file name was specified
            if (Path.GetFileNameWithoutExtension(tsConfigFilePathAndName).Length == 0)
                tsConfigFile = moTerrariaServer.ServerStartArguments._DefaultConfigFileName;

            // Check if the file extension was specified
            tsExtension = (Path.HasExtension(tsConfigFilePathAndName) ? Path.GetExtension(tsConfigFile) : moTerrariaServer.ServerStartArguments._DefaultConfigFileExtention);

            // Create the full file name
            tsConfigFile = Path.ChangeExtension(tsConfigFile, tsExtension);

            // Save the form content to the arguments object
            saveArgumentsToObject(moTerrariaServer.ServerStartArguments);

            // Save the arguments object to a file
            moTerrariaServer.ServerStartArguments.saveToFile(tsConfigFile);

            // Reload the file after saving to make sure the info got saved (and to trigger any save events)
            loadArgumentsToForm(moTerrariaServer.ServerStartArguments);

            // Refresh the config file list
            refreshConfigFileList(tsConfigFile);
        }

        /// <summary>
        /// Refreshes the current config file list. 
        /// Passing in a string will attempt to change the selection to that item after the refresh instead of restoring the current selection.
        /// </summary>
        /// <param name="psNewSelection"></param>
        private void refreshConfigFileList(string psNewSelection)
        {
            List<string> tsFileNamesOnly = new List<string>();
            IEnumerable<string> tsFiles = null;
            string tsCurrentSelection = "";

            // Get a list of available files
            tsFiles = Directory.EnumerateFiles(Environment.CurrentDirectory, "*." + moTerrariaServer.ServerStartArguments._DefaultConfigFileExtention);

            // Format to only display the name
            foreach (string tsFileFullPath in tsFiles)
                tsFileNamesOnly.Add((new FileInfo(tsFileFullPath).Name));

            // Save the currently select text because the list needs to be recreated
            if (toolStripComboBox_ConfigFile.SelectedItem != null)
                tsCurrentSelection = toolStripComboBox_ConfigFile.SelectedItem.ToString();

            // If a new selection was supplied, use that instead of the current
            if (psNewSelection.Trim().Length > 0)
                tsCurrentSelection = psNewSelection;

            // Bind the list to the form
            toolStripComboBox_ConfigFile.Items.Clear();
            toolStripComboBox_ConfigFile.Items.AddRange(tsFileNamesOnly.ToArray());

            // Restore the last selection
            if (tsCurrentSelection.Trim().Length > 0)
                toolStripComboBox_ConfigFile.SelectedItem = tsCurrentSelection;
            else if (toolStripComboBox_ConfigFile.Items.Count > 0)
                toolStripComboBox_ConfigFile.SelectedIndex = 0;
        }

        private void refreshAutosaveTimer()
        {
            int tiAutosaveInterval = 0;

            // Calculate the delay factor
            int tiAutosaveDelayFactor = 1000 /*1 second*/ * 60 /*1 minute*/;

            if (comboBox_AutosaveDelayFactor.SelectedIndex >= (decimal)1)
                tiAutosaveDelayFactor *= 60; /*1 hour*/
            if (comboBox_AutosaveDelayFactor.SelectedIndex >= (decimal)2)
                tiAutosaveDelayFactor *= 24; /*1 day*/

            // Reset the interval
            tiAutosaveInterval = Convert.ToInt32(numericUpDown_AutosaveDelay.Value) * tiAutosaveDelayFactor;
            timer_Autosave.Interval = tiAutosaveInterval;

            // Reset the last autosave time
            moLastAutosave = DateTime.Now;
        }
        #endregion

        #region methods - do commands
        void doOutput(string psMessage, Color poColor)
        {
            if (psMessage == null) psMessage = "";

            // Prefix the line with a timestamp
            if (psMessage.Trim() != "") psMessage = DateTime.Now.ToString() + " - " + psMessage;

            // Log the message
            doLog(psMessage);

            // Pause the refresh of the console until after all output is complete
            // (otherwise it may blink)
            richTextBox_Console.SuspendLayout();

            // Out the data to the console
            richTextBox_Console.AppendText(psMessage, poColor);

            // Limit the console length
            if (richTextBox_Console.Text.Length > 5000)
                richTextBox_Console.Text = richTextBox_Console.Text.Substring(richTextBox_Console.Text.Length - 5000);

            // Auto scroll to text box
            richTextBox_Console.SelectionStart = richTextBox_Console.Text.Length;
            richTextBox_Console.ScrollToCaret();

            // Resume painting the text box
            richTextBox_Console.ResumeLayout();
        }

        void doLog(string psMessage)
        {
            if (checkBox_Logging.Checked)
            {
                string tsFile = "";

                // Check for collapsed logging
                if (moTerrariaServer.ServerStartArguments.TSG_LogPercentagesCollapsed == 1 && psMessage.Contains("%"))
                    return;

                // Create the log filename
                tsFile = moTerrariaServer.ServerStartArguments.TSG_LogFolder +
                    moTerrariaServer.ServerStartArguments.TSG_LogFilePrefix +
                    ".txt";
                
                try
                {
                    // Clear the last error message
                    label_LogError.Text = "";

                    // Check for the log folder location
                    if (!Directory.Exists(moTerrariaServer.ServerStartArguments.TSG_LogFolder))
                        Directory.CreateDirectory(moTerrariaServer.ServerStartArguments.TSG_LogFolder);

                    // Write the log contents
                    File.AppendAllText(tsFile, psMessage);
                }
                catch (Exception e)
                {
                    label_LogError.Text = "Last Log Attempt Threw an Error: " + e.Message;
                }
            }
        }

        /// <summary>
        /// [Thread Safe] Outputs to the main form console
        /// </summary>
        /// <param name="psMessage"></param>
        void doTSOutput(string psMessage)
        {
            doTSOutput(psMessage, Color.Black);
        }

        /// <summary>
        /// [Thread Safe] Outputs to the main form console
        /// </summary>
        /// <param name="psMessage"></param>
        void doTSOutput(string psMessage, Color poColor)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    doOutput(psMessage, poColor);
                });
            }
            catch (Exception)
            {
                if (!this.IsDisposed)
                    doOutput(psMessage, poColor);
            }
        }

        private void doUpdateStatus(string psMessage, int piPercentComplete)
        {
            string tsMessage = psMessage;

            // Check for an error command
            if (piPercentComplete == -1)
                doTSUpdateFormState(enumFormState.error);

            // Cap the parameters
            if (tsMessage.Length > 50) tsMessage = tsMessage.Substring(0, 47) + "...";
            if (piPercentComplete < 0) piPercentComplete = 0;
            if (piPercentComplete > 100) piPercentComplete = 100;

            // Update the GUI
            toolStripLabel_StatusText.Text = tsMessage;
            toolStripLabel_StatusText.ToolTipText = psMessage;
            toolStripProgressBar_Main.Value = piPercentComplete;

            // Hide the progress bar if the progress is not active
            toolStripProgressBar_Main.Visible = !(piPercentComplete == 0 || piPercentComplete == 100);
        }

        /// <summary>
        /// [Thread Safe] Update the main status bar with an error message
        /// </summary>
        /// <param name="psMessage"></param>
        private void doTSUpdateStatusError(string psMessage)
        {
            doTSUpdateStatus(psMessage, -1);
        }

        /// <summary>
        /// [Thread Safe] Updates the main status bar.
        /// </summary>
        /// <param name="psMessage"></param>
        /// <param name="piPercentComplete">A percentage complete between 0 and 100.</param>
        private void doTSUpdateStatus(string psMessage, int piPercentComplete)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    doUpdateStatus(psMessage, piPercentComplete);
                });
            }
            catch (Exception e)
            {
                if (!this.IsDisposed)
                    doUpdateStatus(psMessage, piPercentComplete);
            }
        }

        private void doUpdateFormState(enumFormState poState)
        {
            List<Control> toControlList = new List<Control>(){
                toolStrip_Footer
            };

            // Suspend drawing until layout changes are complete
            toControlList.ForEach(c => c.SuspendLayout());

            // Reset the controls
            toolStripButton_StartServer.Enabled = true;
            toolStripButton_StartServer.Text = "Start Server";

            // Refresh the bunny icon
            toolStripButton_StatusIcon.Image = null;

            // Apply selected state
            switch (poState)
            {
                case enumFormState.started:
                    toolStripButton_StatusIcon.Image = TerrariaServerCS.Properties.Resources.Bunny_Animated;
                    toolStripButton_StartServer.Enabled = true;
                    toolStripButton_StartServer.Text = "Stop Server";
                    break;

                case enumFormState.starting:
                    toolStripButton_StatusIcon.Image = TerrariaServerCS.Properties.Resources.Bunny_Animated;
                    toolStripButton_StartServer.Enabled = false;
                    label_AutosaveTimeRemainingData.Text = "<server not running>";
                    break;

                case enumFormState.stopped:
                    toolStripButton_StatusIcon.Image = TerrariaServerCS.Properties.Resources.Bunny;
                    label_AutosaveTimeRemainingData.Text = "<server not running>";
                    break;

                case enumFormState.stopping:
                    toolStripButton_StatusIcon.Image = TerrariaServerCS.Properties.Resources.Bunny_Animated;
                    toolStripButton_StartServer.Enabled = false;
                    toolStripButton_StartServer.Text = "Stop Server";
                    label_AutosaveTimeRemainingData.Text = "<server not running>";
                    break;

                case enumFormState.error:
                    toolStripButton_StatusIcon.Image = TerrariaServerCS.Properties.Resources.Bunny_Corrupt;
                    break;

                default:
                    throw new NotImplementedException("No code for state change: " + poState);
            }

            // Set the new state
            moFormState = poState;

            // Update the status message
            doTSUpdateStatus(Enum.GetName(typeof(enumFormState), poState), 0);

            // Check if the autosave timer should be running
            checkBox_AutoSave_CheckedChanged(null, null);

            // Force the controls to redraw
            toControlList.ForEach(c => c.ResumeLayout(true));
        }

        /// <summary>
        /// [Thread Safe] Updates the state of the form
        /// </summary>
        /// <param name="poState"></param>
        private void doTSUpdateFormState(enumFormState poState)
        {
            // Check to make sure the object is not null in the case that a command is processed after the form closed
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    doUpdateFormState(poState);
                });
            }
            catch (Exception)
            {
                if (!this.IsDisposed)
                    doUpdateFormState(poState);
            }
        }
        #endregion

        #region methods - misc
        private void doOpenFileOrDirectoryDialog(Control psControl, bool pbDirectoryOnly)
        {
            // Make the dialog open at the currently selected location
            if (psControl.Text != "")
            {
                DirectoryInfo toDirectory = new System.IO.DirectoryInfo(psControl.Text);
                FileInfo toFile = new System.IO.FileInfo(psControl.Text);

                folderBrowserDialog_Main.SelectedPath = toDirectory.FullName;
                openFileDialog_Main.InitialDirectory = toFile.Directory.FullName;
                openFileDialog_Main.FileName = toFile.Name;
            }

            // Open the dialog
            if (pbDirectoryOnly)
            {
                if (folderBrowserDialog_Main.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    psControl.Text = folderBrowserDialog_Main.SelectedPath;
            }
            else
            {
                if (openFileDialog_Main.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    psControl.Text = openFileDialog_Main.FileName;
            }
        }

        /// <summary>
        /// Not used yet, hard to make it look good since this program wasn't designed for color :/
        /// </summary>
        private void setTheme(enumTheme theme)
        {
            switch(theme)
            {
                case enumTheme.Default:
                    toolStrip_Header.BackColor = System.Drawing.SystemColors.Control;
                    break;
                case enumTheme.Red:
                    toolStrip_Header.BackColor = System.Drawing.SystemColors.Control;
                    break;
            }
        }
        #endregion

        #region events - callbacks
        void moTerrariaServer_DataRecievedOutput(object sender, TerrariaServerEventArgs e)
        {
            doTSOutput(e.Data + Environment.NewLine);
        }

        void moTerrariaServer_DataRecievedError(object sender, TerrariaServerEventArgs e)
        {
            doTSOutput(e.Data + Environment.NewLine, Color.Red);
        }

        void moTerrariaServer_ServerCommandComplete(object sender, TerrariaServerEventArgs e)
        {
            if (moTerrariaServer.IsServerRunning)
                doTSUpdateFormState(enumFormState.started);
            else
                doTSUpdateFormState(enumFormState.stopped);
        }

        private void saveableOption_OnChange(object sender, EventArgs args)
        {
            toolStripButton_ConfigFileSave.Enabled = true;
        }
        #endregion

        #region events - toolbar
        private void toolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            // Exit the application
            Application.Exit();
        }

        private void toolStripButton_ConfigFileSave_Click(object sender, EventArgs e)
        {
            saveConfigFile();
        }

        private void toolStripComboBox_ConfigFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Populate the object with the file contents
            try
            {
                moTerrariaServer.ServerStartArguments.loadFromFile(toolStripComboBox_ConfigFile.Text);
            }
            catch (Exception toE)
            {
                doUpdateStatus("Error loading selected config file", 0);
            }

            // Populate the form with the argument object contents
            loadArgumentsToForm(moTerrariaServer.ServerStartArguments);

            // Enable the save button as a file was selected
            toolStripButton_ConfigFileDelete.Enabled = true;
        }
        #endregion

        #region events - server
        private void button_Execute_Click(object sender, EventArgs e)
        {
            // Send the command to the server
            moTerrariaServer.doCommand(textBox_Execute.Text);
        }

        private void textBox_Execute_TextChanged(object sender, EventArgs e)
        {
            string tsText = textBox_Execute.Text;

            if (tsText.Contains(Environment.NewLine))
            {
                button_Execute_Click(sender, null);
                textBox_Execute.Clear();
            }
        }

        private void toolStripButton_StartServer_Click(object sender, EventArgs e)
        {
            if (moFormState == enumFormState.stopped)
            {
                // Initialize the server object
                initializeServerObject((enumTerrariaServer)Enum.Parse(typeof(enumTerrariaServer), comboBox_ServerType.SelectedItem.ToString()));

                // Update the server path
                moTerrariaServer.ServerExecutableLocation = textBox_ServerPath.Text;

                // Save the config file
                saveConfigFile();

                // Run the server
                moTerrariaServer.run();

                // Set the form state
                doTSUpdateFormState(enumFormState.starting);
            }
            else if (moFormState == enumFormState.started)
            {
                // Send command
                moTerrariaServer.doCommand_StopServer(true);

                // Set the form state
                doTSUpdateFormState(enumFormState.stopping);
            }
        }

        private void toolStripButton_ConfigFileSaveAs_Click(object sender, EventArgs e)
        {
            // If a config file is currently selected, default the new file to that name
            if (toolStripComboBox_ConfigFile.SelectedItem != null)
                saveFileDialog_Config.FileName = toolStripComboBox_ConfigFile.SelectedItem.ToString();

            // Set the initial directory to the current directory
            if (saveFileDialog_Config.InitialDirectory == "")
                saveFileDialog_Config.InitialDirectory = Environment.CurrentDirectory;

            // Show the dialog
            if (saveFileDialog_Config.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Save the info to the config file
                saveConfigFile(saveFileDialog_Config.FileName);
            }
        }

        private void toolStripButton_ConfigFileDelete_Click(object sender, EventArgs e)
        {
            DialogResult toDeleteConfirm;

            // Confirm the deletion
            toDeleteConfirm = MessageBox.Show("Are you sure you want to delete this configuration file?", "Delete Config File", MessageBoxButtons.YesNo);

            if (toDeleteConfirm == System.Windows.Forms.DialogResult.Yes)
            {
                string tsSelectedFile = "";

                // Get the selected file
                tsSelectedFile = toolStripComboBox_ConfigFile.SelectedItem.ToString();

                // Delete the selected file
                File.Delete(tsSelectedFile);

                // Disable the delete button now that the current item has been removed
                toolStripButton_ConfigFileDelete.Enabled = false;

                // Refresh the config file list
                refreshConfigFileList("");
            }
        }

        private void checkBox_AutoSave_CheckedChanged(object sender, EventArgs e)
        {
            bool tbEnabled = checkBox_AutoSave.Checked;

            // Disable or enable other autosave controls if the user changes the autosave checkbox
            numericUpDown_AutosaveDelay.Enabled = tbEnabled;
            comboBox_AutosaveDelayFactor.Enabled = tbEnabled;

            // Disable or enable the save timer
            timer_Autosave.Enabled = (tbEnabled && moFormState == enumFormState.started);

            // Recalculate the autosave timer
            refreshAutosaveTimer();
        }
        #endregion

        #region events - main form
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If the server is running, command it to stop before allowing the application to close
            if (moTerrariaServer.IsServerRunning)
            {
                // Close the application upon executing the callback
                moTerrariaServer.ServerCommandComplete += (pSender, pE) => { Application.Exit(); };

                // Save and exit the server
                moTerrariaServer.doCommand_StopServer(true);

                // Update the GUI
                doTSUpdateFormState(enumFormState.stopping);

                // Cancel the close operation on the application
                e.Cancel = true;
            }
        }

        private void button_ServerPath_Click(object sender, EventArgs e)
        {
            doOpenFileOrDirectoryDialog(textBox_ServerPath, false);
        }

        private void button_World_Click(object sender, EventArgs e)
        {
            doOpenFileOrDirectoryDialog(textBox_World, false);
        }

        private void button_BanList_Click(object sender, EventArgs e)
        {
            doOpenFileOrDirectoryDialog(textBox_BanList, false);
        }

        private void button_WorldPath_Click(object sender, EventArgs e)
        {
            doOpenFileOrDirectoryDialog(textBox_WorldPath, true);
        }

        private void numericUpDown_AutosaveDelay_ValueChanged(object sender, EventArgs e)
        {
            refreshAutosaveTimer();
        }

        private void comboBox_AutosaveDelayFactor_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshAutosaveTimer();
        }

        private void timer_Main_Tick(object sender, EventArgs e)
        {
            // Server not running
            if (moFormState != enumFormState.started)
            {
            }
            // Server IS running
            else
            {
                if (tabControl_Main.SelectedIndex == 2)
                {
                    // Update the autosave timer
                    if (timer_Autosave.Enabled)
                    {
                        // Calculations
                        DateTime toNow = DateTime.Now;
                        TimeSpan toTimePassed = toNow - moLastAutosave;
                        int tiMillisecondsTilSave = timer_Autosave.Interval - (int)toTimePassed.TotalMilliseconds;
                        TimeSpan toTimespanTilSave = (new TimeSpan(0, 0, 0, 0, tiMillisecondsTilSave));

                        // Update the label
                        label_AutosaveTimeRemainingData.Text = string.Format(@"{0:d\:hh\:mm\:ss}", toTimespanTilSave);
                    }
                    else
                        label_AutosaveTimeRemainingData.Text = "-------";
                }
            }
        }

        private void timer_Autosave_Tick(object sender, EventArgs e)
        {
            // Save the server
            moTerrariaServer.doCommand_SaveServer();

            // Refresh the timer
            refreshAutosaveTimer();
        }

        private void button_LoggingFolder_Click(object sender, EventArgs e)
        {
            doOpenFileOrDirectoryDialog(textBox_LogFolder, true);
        }

        private void checkBox_Logging_CheckedChanged(object sender, EventArgs e)
        {
            bool tbEnabled = checkBox_Logging.Checked;

            // Enable or disable logging controls
            button_LoggingFolder.Enabled = tbEnabled;
            textBox_LogFolder.Enabled = tbEnabled;
            textBox_LogFilenamePrefix.Enabled = tbEnabled;
            checkBox_LogPercentageCollapsed.Enabled = tbEnabled;
        }

        private void toolStripMenuItem_ConfigFileOpenDirectory_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe" , string.Format(@" ""{0}""",
                Environment.CurrentDirectory)
            );
        }

        private void toolStripComboBox_ForceGuiState_MenuItems_Click(object sender, EventArgs e)
        {
            try
            {
                // Parse the selected item
                enumFormState toFormState = (enumFormState)Enum.Parse(typeof(enumFormState), sender.ToString());

                // Update the form state
                doUpdateFormState(toFormState);
            }
            catch (Exception toE)
            {
                doTSUpdateStatusError("error: " + sender.ToString());
            }
        }

        private void toolStripMenuItem_Help_Click(object sender, EventArgs e)
        {
            // Show the form
            (new HelpForm()).Show();
        }
        #endregion
    }
}
