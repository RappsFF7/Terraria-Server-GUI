using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace TerrariaServerCS
{
    public class TerrariaServer
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

        public TerrariaServerArguments ServerStartArguments { get; set; }

        /// <summary>
        /// Get the process running the server, this is null until "run()" is executed
        /// </summary>
        public Process TerrariaServerProcess
        {
            get { return moTerrariaServerProcess; }
            private set { moTerrariaServerProcess = value; }
        }
        #endregion

        #region delegates & events
        public delegate void ServerExitEventHandler();
        public delegate void TerrariaServerEventHandler(object sender, TerrariaServerEventArgs e);

        public event TerrariaServerEventHandler DataRecievedOutput;
        public event TerrariaServerEventHandler DataRecievedError;

        public event ServerExitEventHandler ServerExited;
        #endregion

        public TerrariaServer()
        {
            initialize(@"C:\Program Files (x86)\Steam\steamapps\common\terraria\TerrariaServer.exe", new TerrariaServerArguments());
        }

        public TerrariaServer(string psServerExecutableLocation, TerrariaServerArguments poServerStartArguments)
        {
            initialize(psServerExecutableLocation, poServerStartArguments);
        }

        #region methods - private
        private void initialize(string psServerExecutableLocation, TerrariaServerArguments poServerStartArguments)
        {
            moTerrariaServerProcess = new Process();
            moTerrariaServerProcess.OutputDataReceived += new DataReceivedEventHandler(moTerrariaServerProcess_OutputDataReceived);
            moTerrariaServerProcess.ErrorDataReceived += new DataReceivedEventHandler(moTerrariaServerProcess_ErrorDataReceived);

            ServerExecutableLocation = psServerExecutableLocation;
            ServerStartArguments = poServerStartArguments;
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

        public void doExit()
        {
            // Add an event to report when the exit is complete
            moTerrariaServerProcess.OutputDataReceived += new DataReceivedEventHandler(moTerrariaServerProcess_OutputDataReceived_Exit);

            // Send the exit command
            doCommand("exit");
        }

        /// <summary>
        /// Writes a line to the server's input stream
        /// </summary>
        /// <param name="psCommand"></param>
        public void doCommand(string psCommand)
        {
            if (IsServerRunning)
                moTerrariaServerProcess.StandardInput.WriteLine(psCommand);
            else
                doDataRecievedOutput(this, new TerrariaServerEventArgs("Cannot run command. Server is not running."));
        }
        #endregion

        #region events
        void doDataRecievedOutput(object sender, TerrariaServerEventArgs e)
        {
            DataRecievedOutput(sender, e);
        }

        void doDataRecievedError(object sender, TerrariaServerEventArgs e)
        {
            DataRecievedError(sender, e);
        }

        void moTerrariaServerProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            // Convert the event args to a custom (editable) object
            if (DataRecievedOutput != null) 
                doDataRecievedOutput(sender, new TerrariaServerEventArgs(e));
        }

        void moTerrariaServerProcess_OutputDataReceived_Exit(object sender, DataReceivedEventArgs e)
        {
            if (e.Data.ToLower().Contains("resetting"))
            {
                // Kill the process
                moTerrariaServerProcess.Kill();

                // Mark the server as not-running
                IsServerRunning = false;

                // Remove this handler for future commands
                moTerrariaServerProcess.OutputDataReceived -= moTerrariaServerProcess_OutputDataReceived_Exit;
                
                // Report the exit
                ServerExited();
            }
        }

        void moTerrariaServerProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            // Convert the event args to a custom (editable) object
            if (DataRecievedError != null) 
                doDataRecievedError(sender, new TerrariaServerEventArgs(e));
        }
        #endregion
    }
}
