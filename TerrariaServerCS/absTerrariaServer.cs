using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;

namespace TerrariaServerCS
{
    #region delegates
    public delegate void TerrariaServerEventHandler(object sender, TerrariaServerEventArgs e);
    #endregion

    /// <summary>
    /// A base terraria server
    /// </summary>
    /// <typeparam name="TServer">The class using this abstract class</typeparam>
    /// <typeparam name="TArgs">The class used for arguments</typeparam>
    public abstract class absTerrariaServer
    {
        #region variables
        private Process moTerrariaServerProcess;
        private string msCommandLast;
        #endregion

        #region properties
        public string ServerExecutableLocation
        {
            get { return moTerrariaServerProcess.StartInfo.FileName; }
            set { moTerrariaServerProcess.StartInfo.FileName = value; }
        }

        public bool IsServerRunning { get; protected set; }

        public absTerrariaServerArguments ServerStartArguments { get; set; }

        /// <summary>
        /// Get the process running the server, this is null until "run()" is executed
        /// </summary>
        public Process TerrariaServerProcess
        {
            get { return moTerrariaServerProcess; }
            protected set { moTerrariaServerProcess = value; }
        }
        #endregion

        #region events
        public event TerrariaServerEventHandler DataRecievedOutput;
        public event TerrariaServerEventHandler DataRecievedError;

        public event TerrariaServerEventHandler ServerCommandComplete;
        #endregion

        public absTerrariaServer()
        {
            initialize(null, null);
        }

        public absTerrariaServer(string psServerExecutableLocation, absTerrariaServerArguments poServerStartArguments)
        {
            initialize(psServerExecutableLocation, poServerStartArguments);
        }

        #region methods - protected
        /// <summary>
        /// Initializes the server
        /// </summary>
        /// <param name="psServerExecutableLocation"></param>
        /// <param name="poServerStartArguments"></param>
        protected void initialize(string psServerExecutableLocation, absTerrariaServerArguments poServerStartArguments)
        {
            // Create the process
            moTerrariaServerProcess = new Process();
            moTerrariaServerProcess.OutputDataReceived += new DataReceivedEventHandler(moTerrariaServerProcess_OutputDataReceived);
            moTerrariaServerProcess.ErrorDataReceived += new DataReceivedEventHandler(moTerrariaServerProcess_ErrorDataReceived);

            // Save the supplied arguments
            ServerExecutableLocation = psServerExecutableLocation;
            ServerStartArguments = poServerStartArguments;
        }

        protected virtual string getServerLocationDefault()
        {
            char PS = Path.DirectorySeparatorChar;

            // Try to get the server path from Steam
            string tsServerFile = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Valve\Steam", "SteamPath", "").ToString();

            // If found, transform to get server location
            if (tsServerFile != "")
            {
                // Convert the file path string to use the system's file separators
                tsServerFile = new FileInfo(tsServerFile).FullName;

                // Add the default path for the server
                tsServerFile = string.Format(@"{1}{0}steamapps{0}common{0}terraria{0}TerrariaServer.exe", PS, tsServerFile);
            }

            // Return
            return tsServerFile;
        }
        #endregion

        #region methods - public
        /// <summary>
        /// Start up the terraria server
        /// </summary>
        public void run()
        {
            moTerrariaServerProcess.StartInfo.Arguments = ServerStartArguments.getArgumentsForCmd();
            moTerrariaServerProcess.StartInfo.CreateNoWindow = true;
            moTerrariaServerProcess.StartInfo.UseShellExecute = false;
            moTerrariaServerProcess.StartInfo.RedirectStandardOutput = true;
            moTerrariaServerProcess.StartInfo.RedirectStandardError = true;
            moTerrariaServerProcess.StartInfo.RedirectStandardInput = true;

            // Starting the process doesn't run through the command method, so we fake the start command
            msCommandLast = "start";
            moTerrariaServerProcess.OutputDataReceived += new DataReceivedEventHandler(moTerrariaServerProcess_OutputDataReceived_Command);

            // Start the server
            moTerrariaServerProcess.Start();
            moTerrariaServerProcess.BeginOutputReadLine();
            moTerrariaServerProcess.BeginErrorReadLine();
            IsServerRunning = true;
        }

        /// <summary>
        /// Writes a line to the server's input stream
        /// </summary>
        /// <param name="psCommand"></param>
        public void doCommand(string psCommand)
        {
            // Exit if the server is not running
            if (!IsServerRunning)
            {
                DataRecievedOutput(this, new TerrariaServerEventArgs("Cannot run command. Server is not running."));
                return;
            }

            // Record the command
            msCommandLast = psCommand;

            // Execute the command
            doCommandExecute(psCommand);
        }

        /// <summary>
        /// Called when a command is sent while the server is running
        /// </summary>
        /// <param name="psCommand"></param>
        protected virtual void doCommandExecute(string psCommand)
        {
            switch (psCommand.ToLower())
            {
                // Write the command verbatim to the server input stream
                default:
                    TerrariaServerProcess.OutputDataReceived += new DataReceivedEventHandler(moTerrariaServerProcess_OutputDataReceived_Command);
                    TerrariaServerProcess.StandardInput.WriteLine(psCommand);
                    break;
            }
        }

        /// <summary>
        /// Called after a command is completed
        /// </summary>
        /// <param name="psCommand"></param>
        protected virtual void doCommandComplete(string psCommand, DataReceivedEventArgs e)
        {
            // Stop tracking output
            TerrariaServerProcess.OutputDataReceived -= moTerrariaServerProcess_OutputDataReceived_Command;

            // Format the command name
            string tsCommand = psCommand.ToLower();

            // Check for specific server events
            if (tsCommand.StartsWith("exit"))
                IsServerRunning = false;

            else if (tsCommand.StartsWith("start"))
                IsServerRunning = true;

            // Trigger the event
            if (ServerCommandComplete != null)
                ServerCommandComplete(this, new TerrariaServerEventArgs(e));
        }
        #endregion

        #region events
        private void moTerrariaServerProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            // Convert the event args to a custom (editable) object
            if (DataRecievedOutput != null)
            {
                DataRecievedOutput(sender, new TerrariaServerEventArgs(e));
            }
        }

        private void moTerrariaServerProcess_OutputDataReceived_Command(object sender, DataReceivedEventArgs e)
        {
            // Watch for the command to complete
            if (e.Data == null)
            {
                // Call the complete operation before triggering the event
                doCommandComplete(msCommandLast, e);
            }
        }

        private void moTerrariaServerProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            // Convert the event args to a custom (editable) object
            if (DataRecievedError != null)
                DataRecievedError(sender, new TerrariaServerEventArgs(e));
        }
        #endregion
    }
}
