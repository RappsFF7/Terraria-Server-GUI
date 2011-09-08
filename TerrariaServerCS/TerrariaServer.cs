using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TerrariaServerCS
{
    public class TerrariaServer : absTerrariaServer
    {
        public TerrariaServer()
        {
            initialize(getServerLocationDefault(), new TerrariaServerArguments());
        }

        protected override bool getIsCommandComplete(string psCommand, System.Diagnostics.DataReceivedEventArgs poLastServerOutput)
        {
            bool tbReturn = false;
            string tsOutput = "";
            
            // If the server output's null, the command is always complete
            if (poLastServerOutput.Data == null)
                tbReturn = true;

            // Filter the output
            tsOutput = (poLastServerOutput.Data == null ? "" : poLastServerOutput.Data.ToLower());

            // Check the various cases for the output
            Regex toCommandCompletePattern = null;

            switch (psCommand)
            {
                case "start":
                    toCommandCompletePattern = new Regex(".*server started.*");
                    if (tbReturn || toCommandCompletePattern.IsMatch(tsOutput))
                    {
                        IsServerRunning = true;
                        return true;
                    }
                    break;

                case "exit": case "exit-nosave":
                    if (tbReturn)
                    {
                        IsServerRunning = false;
                        return true;
                    }
                    break;

                default:
                    break;
            }

            // No success condition was found, return false
            return false;
        }
    }
}
