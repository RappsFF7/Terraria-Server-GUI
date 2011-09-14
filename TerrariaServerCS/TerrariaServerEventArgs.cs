using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TerrariaServerCS
{
    public class TerrariaServerEventArgs : EventArgs
    {
        public string Data { get; set; }

        public TerrariaServerEventArgs(string _Data) 
        {
            Data = _Data;
        }

        public TerrariaServerEventArgs(DataReceivedEventArgs Source) 
        {
            if (Source != null)
                Data = Source.Data;
        }
    }
}
