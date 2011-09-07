using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TerrariaServerCS
{
    public enum enumTerrariaServer
    {
        Classic
    }

    public class TerrariaServerFactory
    {
        public absTerrariaServer newServer(enumTerrariaServer poServerType, ref absTerrariaServerArguments poOutputServerArguments)
        {
            switch (poServerType)
            {
                case enumTerrariaServer.Classic:
                    poOutputServerArguments = new TerrariaServerArguments();
                    return new TerrariaServer();

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
