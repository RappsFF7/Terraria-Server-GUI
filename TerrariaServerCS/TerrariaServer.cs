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

        public event DataReceivedEventHandler DataRecievedOutput;
        public event DataReceivedEventHandler DataRecievedError;

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
            moTerrariaServerProcess.StandardInput.WriteLine(psCommand);
        }
        #endregion

        #region events
        void moTerrariaServerProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (DataRecievedOutput != null) DataRecievedOutput.Invoke(sender, e);
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
            if (DataRecievedError != null) DataRecievedError.Invoke(sender, e);
        }
        #endregion
    }
}
