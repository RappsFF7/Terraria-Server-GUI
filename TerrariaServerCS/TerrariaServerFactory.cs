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

    public static class TerrariaServerFactory
    {
        public static absTerrariaServer newServer(enumTerrariaServer poServerType)
        {
            switch (poServerType)
            {
                case enumTerrariaServer.Classic:
                    return new TerrariaServer();

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
