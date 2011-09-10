using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TerrariaServerCS;
using TerrariaServerCS.Classes;

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
        #endregion

        #region events & delegates
        #endregion

        #region variables
        private enumFormState moFormState;
        private absTerrariaServer moTerrariaServer;
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

            // Initialize the server object (to get the default server path)
            initializeServerObject((enumTerrariaServer)Enum.Parse(typeof(enumTerrariaServer), comboBox_ServerType.SelectedItem.ToString()));

            // Load the default server location
            textBox_ServerPath.Text = moTerrariaServer.ServerExecutableLocation;

            // Initialize the world creation size drop down
            comboBox_AutoCreateSize.DataSource = Enum.GetNames(typeof(TerrariaServerCS.enumTerrariaServerSize));

            // Load config data from the config file
            loadArgumentsToForm(moTerrariaServer.ServerStartArguments);

            // Set initial form state
            doTSUpdateFormState(enumFormState.stopped);
        }

        private void initializeServerObject(enumTerrariaServer toServerType)
        {
            // Get a new server object
            moTerrariaServer = TerrariaServerFactory.newServer(toServerType);

            // Setup callbacks
            moTerrariaServer.DataRecievedOutput += new TerrariaServerEventHandler(moTerrariaServer_DataRecievedOutput);
            moTerrariaServer.DataRecievedError += new TerrariaServerEventHandler(moTerrariaServer_DataRecievedError);
            moTerrariaServer.ServerCommandComplete += new TerrariaServerEventHandler(moTerrariaServer_ServerCommandComplete);
        }

        private void loadArgumentsToForm(absTerrariaServerArguments poArgs)
        {
            // Populate the form
            numericUpDown_Players.Value = poArgs.Players.Value;
            textBox_World.Text = poArgs.World;
            numericUpDown_Port.Value = poArgs.Port.Value;
            textBox_Password.Text = poArgs.Password;
            textBox_MODT.Text = poArgs.MOTD;
            textBox_WorldPath.Text = poArgs.WorldPath;
            comboBox_ServerType.SelectedIndex = poArgs.AutoCreate.Value - 1;
            textBox_WorldName.Text = poArgs.WorldName;
            textBox_BanList.Text = poArgs.BanList;
            checkBox_Secure.Checked = (poArgs.Secure.Value == 0 ? false : true);
        }

        private void saveArgumentsToObject(absTerrariaServerArguments poArgs)
        {
            // Populate the form
            poArgs.Players = Convert.ToInt32(numericUpDown_Players.Value);
            poArgs.World = textBox_World.Text;
            poArgs.Port = Convert.ToInt32(numericUpDown_Port.Value);
            poArgs.Password = textBox_Password.Text;
            poArgs.MOTD = textBox_MODT.Text;
            poArgs.WorldPath = textBox_WorldPath.Text;
            poArgs.AutoCreate = comboBox_ServerType.SelectedIndex;
            poArgs.WorldName = textBox_WorldName.Text;
            poArgs.BanList = textBox_BanList.Text;
            poArgs.Secure = (checkBox_Secure.Checked ? 1 : 0);
        }
        #endregion

        #region methods - do commands
        void doOutput(string psMessage, Color poColor)
        {
            if (psMessage == null) psMessage = "";

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
            // Check for an error command
            if (piPercentComplete == -1)
                doTSUpdateFormState(enumFormState.error);

            // Cap the parameters
            if (psMessage.Length > 20) psMessage = psMessage.Substring(0, 17) + "...";
            if (piPercentComplete < 0) piPercentComplete = 0;
            if (piPercentComplete > 100) piPercentComplete = 100;

            // Update the GUI
            toolStripLabel_StatusText.Text = psMessage;
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
            catch (Exception)
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
                    break;

                case enumFormState.stopped:
                    toolStripButton_StatusIcon.Image = TerrariaServerCS.Properties.Resources.Bunny;
                    break;

                case enumFormState.stopping:
                    toolStripButton_StatusIcon.Image = TerrariaServerCS.Properties.Resources.Bunny_Animated;
                    toolStripButton_StartServer.Enabled = false;
                    toolStripButton_StartServer.Text = "Stop Server";
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
            // Setup the callback to collect the selected item
            //openFileDialog_Main.FileOk += (poSender, poEventArgs) => { psControl.Text = openFileDialog_Main.FileName; };

            // Make the dialog open at the currently selected location
            if (psControl.Text != "")
            {
                folderBrowserDialog_Main.SelectedPath = (new System.IO.DirectoryInfo(psControl.Text)).FullName;
                openFileDialog_Main.InitialDirectory = (new System.IO.FileInfo(psControl.Text)).FullName;
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
        #endregion

        #region events - toolbar
        private void toolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            // Exit the application
            Application.Exit();
        }
        #endregion

        #region events - server
        private void button_Execute_Click(object sender, EventArgs e)
        {
            // Send the command to the server
            moTerrariaServer.doCommand(textBox_Execute.Text);
        }

        private void textBox_Execute_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // Send the command when enter is clicked
                case Keys.Enter:
                    button_Execute_Click(sender, null);
                    break;
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
        #endregion
    }
}
