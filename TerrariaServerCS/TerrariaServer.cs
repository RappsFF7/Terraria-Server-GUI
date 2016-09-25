using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TerrariaServerCS
{
    public class TerrariaServer : absTerrariaServer
    {
        public TerrariaServer() : base(new TerrariaServerArguments())
        { }

        protected override bool getIsCommandComplete(string psCommand, System.Diagnostics.DataReceivedEventArgs poLastServerOutput)
        {
            bool tbReturn = false;
            string tsOutput;

            // Possibly new solution
            // Problems: Terraria server accepts input (probably for a cancel on startup) while the server is still starting up, 
            //   this logic will incorrectly return true before the startup is complete
            /*
            foreach (ProcessThread thread in TerrariaServerProcess.Threads)
            {
                if (thread.ThreadState == ThreadState.Wait
                    && thread.WaitReason == ThreadWaitReason.UserRequest)
                {
                    tbReturn = true;
                }
            }

            return tbReturn;
            */

            // If the server output's null, the command is always complete
            if (poLastServerOutput.Data == null)
                tbReturn = true;

            // Filter the output
            tsOutput = (poLastServerOutput.Data == null ? "" : poLastServerOutput.Data.ToLower());

            // Check for specific end of command output and process the command
            Console.WriteLine("Command: [" + psCommand + "] Output [" + tsOutput + "]");
            switch (psCommand)
            {
                case "start":
                    if (tbReturn || new Regex(".*listening on port.*").IsMatch(tsOutput))
                    {
                        //IsServerRunning = true;
                        return true;
                    }
                    break;

                // This check is no longer necessary because the server outputs a null line when these commands end
                case "exit": case "exit-nosave":
                    if (tbReturn)
                    {
                        //IsServerRunning = false;
                        return true;
                    }
                    break;

                default:
                    break;
            }

            // No success condition was found, return false
            return false;
        }

        protected override void doCommandCompleteParent(string psCommand, System.Diagnostics.DataReceivedEventArgs poLastServerOuput)
        {
            // Check for specific end of command output and process the command
            switch (psCommand)
            {
                case "start":
                        IsServerRunning = true;
                    break;

                case "exit":
                case "exit-nosave":
                        IsServerRunning = false;
                    break;

                default:
                    break;
            }
        }

        public override void doCommand_StartServer(ref absTerrariaServerArguments poArgs)
        {
            // Starting the process manually, but setup the listener by issues doCommand with the fake flag set to true
            doCommand("start", true);
        }

        public override void doCommand_StopServer(bool pbSave)
        {
            if (pbSave)
                doCommand("exit");
            else
                doCommand("exit-nosave");
        }
        public override void doCommand_SaveServer()
        {
            doCommand("save");
        }
    }
}
