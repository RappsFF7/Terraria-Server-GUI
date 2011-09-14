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

        public absTerrariaServer(absTerrariaServerArguments poServerStartArguments)
        {
            initialize(poServerStartArguments);
        }

        #region methods - protected
        /// <summary>
        /// Initializes the server
        /// </summary>
        /// <param name="psServerExecutableLocation"></param>
        /// <param name="poServerStartArguments"></param>
        protected void initialize(absTerrariaServerArguments poServerStartArguments)
        {
            // Create the process
            moTerrariaServerProcess = new Process();
            moTerrariaServerProcess.OutputDataReceived += new DataReceivedEventHandler(moTerrariaServerProcess_OutputDataReceived);
            moTerrariaServerProcess.ErrorDataReceived += new DataReceivedEventHandler(moTerrariaServerProcess_ErrorDataReceived);

            // Save the supplied arguments
            ServerExecutableLocation = poServerStartArguments.TSG_ServerPath;
            ServerStartArguments = poServerStartArguments;
        }
        #endregion

        #region methods - public
        /// <summary>
        /// Start up the terraria server
        /// </summary>
        public void run(string psConfigFile)
        {
            // Start the server with the start arguments
            absTerrariaServerArguments toArgs = ServerStartArguments;
            doCommand_StartServer(ref toArgs);

            // Setup the process
            TerrariaServerProcess.StartInfo.Arguments = toArgs.getArgumentsForCmd(psConfigFile);
            TerrariaServerProcess.StartInfo.CreateNoWindow = true;
            TerrariaServerProcess.StartInfo.UseShellExecute = false;
            TerrariaServerProcess.StartInfo.RedirectStandardOutput = true;
            TerrariaServerProcess.StartInfo.RedirectStandardError = true;
            TerrariaServerProcess.StartInfo.RedirectStandardInput = true;

            // Start the process
            TerrariaServerProcess.Start();
            TerrariaServerProcess.BeginOutputReadLine();
            TerrariaServerProcess.BeginErrorReadLine();
            IsServerRunning = true;
        }

        /// <summary>
        /// Creates a listener and writes a line to the server's input stream.
        /// </summary>
        public void doCommand(string psCommand)
        {
            doCommand(psCommand, false);
        }

        /// <summary>
        /// Creates a listener and writes a line to the server's input stream.
        /// If instructed to be "fake" the command still start up a listener but not send the actual input to the server.
        /// (this is used if the command will be sent manually to the server by some other means)
        /// </summary>
        /// <param name="psCommand"></param>
        public void doCommand(string psCommand, bool pbFake)
        {
            // Exit if the server is not running
            if (!IsServerRunning && !pbFake)
            {
                DataRecievedOutput(this, new TerrariaServerEventArgs("Cannot run command. Server is not running."));
                return;
            }

            // Record the command
            msCommandLast = psCommand;

            // Setup a callback capturing method
            TerrariaServerProcess.OutputDataReceived += new DataReceivedEventHandler(moTerrariaServerProcess_OutputDataReceived_Command);

            // Execute the command
            if (!pbFake)
                TerrariaServerProcess.StandardInput.WriteLine(psCommand);
        }

        /// <summary>
        /// Called after a command is completed
        /// </summary>
        /// <param name="psCommand"></param>
        protected virtual void doCommandComplete(string psCommand, DataReceivedEventArgs e)
        {
            // Call the inherited command before the event is fired
            doCommandCompleteParent(psCommand, e);

            // Trigger the event
            if (ServerCommandComplete != null)
                ServerCommandComplete(this, new TerrariaServerEventArgs(e));
        }

        /// <summary>
        /// This method is called while the server is sending output after a command is sent.
        /// The server's output must be interpreted and determined if the command has completed.
        /// </summary>
        /// <param name="psCommand"></param>
        /// <param name="poLastServerOutput"></param>
        /// <returns>True if the command has completed</returns>
        protected abstract bool getIsCommandComplete(string psCommand, DataReceivedEventArgs poLastServerOutput);

        /// <summary>
        /// This method is called when a command is completed
        /// </summary>
        /// <param name="psCommand"></param>
        /// <param name="poLastServerOutput"></param>
        protected abstract void doCommandCompleteParent(string psCommand, DataReceivedEventArgs poLastServerOutput);

        public abstract void doCommand_StartServer(ref absTerrariaServerArguments poArgs);
        public abstract void doCommand_StopServer(bool pbSave);
        public abstract void doCommand_SaveServer();
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
            if (getIsCommandComplete(msCommandLast, e))

                // Call the complete operation before triggering the event
                doCommandComplete(msCommandLast, e);
        }

        private void moTerrariaServerProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            // Stop tracking output
            TerrariaServerProcess.OutputDataReceived -= moTerrariaServerProcess_OutputDataReceived_Command;

            // Convert the event args to a custom (editable) object
            if (DataRecievedError != null)
                DataRecievedError(sender, new TerrariaServerEventArgs(e));
        }
        #endregion
    }
}
