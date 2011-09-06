using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Win32;

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
        #endregion

        #region properties
        public string ServerExecutableLocation
        {
            get { return moTerrariaServerProcess.StartInfo.FileName; }
            set { moTerrariaServerProcess.StartInfo.FileName = value; }
        }

        public bool IsServerRunning { get; private set; }

        public absTerrariaServerArguments ServerStartArguments { get; set; }

        /// <summary>
        /// Get the process running the server, this is null until "run()" is executed
        /// </summary>
        public Process TerrariaServerProcess
        {
            get { return moTerrariaServerProcess; }
            private set { moTerrariaServerProcess = value; }
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
            // Try to get the server path from Steam
            string tsServerPath = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Valve\Steam", "SteamPath", "").ToString();

            // If found, transform to get server location
            if (tsServerPath != "")
                tsServerPath += @"\steamapps\common\terraria\TerrariaServer.exe";
            else
                tsServerPath = "";

            // Return
            return tsServerPath;
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

            // Process the command
            switch (psCommand.ToLower())
            {
                default:
                    moTerrariaServerProcess.StandardInput.WriteLine(psCommand);
                    break;
            }

            // Trigger the event
            if (ServerCommandComplete != null)
                ServerCommandComplete(this, new TerrariaServerEventArgs(psCommand));
        }
        #endregion

        #region events
        private void moTerrariaServerProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            // Convert the event args to a custom (editable) object
            if (DataRecievedOutput != null)
                DataRecievedOutput(sender, new TerrariaServerEventArgs(e));
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
