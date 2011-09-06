using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace TerrariaServerCS.Classes
{
    public class CustomDataReceivedEventArgs : EventArgs
    {
        public string Data { get; set; }

        public CustomDataReceivedEventArgs(string _Data) 
        {
            Data = Data;
        }

        public CustomDataReceivedEventArgs(DataReceivedEventArgs Source) 
        {
            Data = Source.Data;
        }
    }
}
