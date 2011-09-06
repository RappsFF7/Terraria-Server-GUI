using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TerrariaServerCS
{
    public class TerrariaServer : absTerrariaServer
    {
        public TerrariaServer()
        {
            initialize(getServerLocationDefault(), new TerrariaServerArguments());
        }

        protected override void doCommandComplete(string psCommand)
        {
            switch (psCommand.ToLower())
            {
                case "exit":
                    IsServerRunning = false;
                    break;
                default:
                    break;
            }
        }
    }
}
