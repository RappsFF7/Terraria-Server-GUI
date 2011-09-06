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
            starting
        }
        #endregion

        #region events & delegates
        #endregion

        #region variables
        private bool mbPendingExit = false;
        private enumFormState moFormState;
        private TerrariaServer moTerrariaServer;
        #endregion

        #region properties
        #endregion

        public MainForm()
        {
            InitializeComponent();
            initialize();
        }

        #region methods - private
        /// <summary>
        /// Initialize code that was not auto generated
        /// </summary>
        private void initialize()
        {
            // Set the default form state
            setFormState(enumFormState.stopped);

            // Initialize classes
            moTerrariaServer = new TerrariaServer();
            moTerrariaServer.DataRecievedOutput += new TerrariaServer.TerrariaServerEventHandler(moTerrariaServer_DataRecievedOutput);
            moTerrariaServer.DataRecievedError += new TerrariaServer.TerrariaServerEventHandler(moTerrariaServer_DataRecievedError);
            moTerrariaServer.ServerExited += new TerrariaServer.ServerExitEventHandler(moTerrariaServer_ServerExited);
        }

        /// <summary>
        /// Outputs to the main form console
        /// </summary>
        /// <param name="psMessage"></param>
        void doTSOutput(string psMessage)
        {
            doTSOutput(psMessage, Color.Black);
        }

        /// <summary>
        /// Outputs to the main form console
        /// </summary>
        /// <param name="psMessage"></param>
        void doTSOutput(string psMessage, Color poColor)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (psMessage == null) psMessage = "";
                
                // Format the message for a rich text box
                //psMessage = psMessage.Replace(moTerrariaServer.TerrariaServerProcess.StandardInput.NewLine, "p\r\n");

                // Out the data to the console
                richTextBox_Console.AppendText(psMessage, poColor);

                // Limit the console length
                if (richTextBox_Console.Text.Length > 5000)
                    richTextBox_Console.Text = richTextBox_Console.Text.Substring(richTextBox_Console.Text.Length - 5000);

                // Auto scroll to text box
                richTextBox_Console.SelectionStart = richTextBox_Console.Text.Length;
                richTextBox_Console.ScrollToCaret();
            });
        }

        /// <summary>
        /// Updates the main status bar.
        /// </summary>
        /// <param name="psMessage"></param>
        /// <param name="piPercentComplete">A percentage complete between 0 and 100.</param>
        private void doTSUpdateStatus(string psMessage, int piPercentComplete)
        {
            // Cap the parameters
            if (psMessage.Length > 20) psMessage = psMessage.Substring(0, 17) + "...";
            if (piPercentComplete < 0) piPercentComplete = 0;
            if (piPercentComplete > 100) piPercentComplete = 100;

            this.Invoke((MethodInvoker)delegate
            {
                // Update the GUI
                toolStripLabel_StatusText.Text = psMessage;
                toolStripProgressBar_Main.Value = piPercentComplete;

                // Hide the progress bar if the progress is not active
                toolStripProgressBar_Main.Visible = !(piPercentComplete == 0 || piPercentComplete == 100);
            });
        }

        private void setFormState(enumFormState poState)
        {
            List<Control> toControlList = new List<Control>(){
                button_StartServer
            };
            
            // Suspend drawing until layout changes are complete
            toControlList.ForEach(c => c.SuspendLayout());

            // Reset the controls
            button_StartServer.Text = "Start Server";

            // Refresh the bunny icon
            toolStripButton_StatusIcon.Image = null;

            // Apply selected state
            switch (poState)
            {
                case enumFormState.started:
                        toolStripButton_StatusIcon.Image = TerrariaServerCS.Properties.Resources.Bunny_Animated;
                    break;

                case enumFormState.starting:
                        toolStripButton_StatusIcon.Image = TerrariaServerCS.Properties.Resources.Bunny_Animated;
                    break;

                case enumFormState.stopped:
                        toolStripButton_StatusIcon.Image = TerrariaServerCS.Properties.Resources.Bunny;
                    break;

                case enumFormState.stopping:
                        toolStripButton_StatusIcon.Image = TerrariaServerCS.Properties.Resources.Bunny_Animated;
                    break;

                default:
                    throw new NotImplementedException("No code for state change: " + poState);
            }

            // Set the new state
            moFormState = poState;

            // Force the controls to redraw
            toControlList.ForEach(c => c.ResumeLayout(true));
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
        #endregion

        #region events - toolbar
        private void toolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            // Exit the application
            Application.Exit();
        }

        private void button_StartServer_Click(object sender, EventArgs e)
        {
            // Run the server
            moTerrariaServer.run();
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
        #endregion

        #region events - misc
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If the server is running, command it to stop and don't allow this application to close
            if (moTerrariaServer.IsServerRunning)
            {
                moTerrariaServer.doCommand("exit");
                e.Cancel = true;
            }
        }

        void moTerrariaServer_ServerExited()
        {
            // If the "exit" command is pending, close once the server has exited
            if (mbPendingExit)
                Application.Exit();
        }
        #endregion
    }
}
