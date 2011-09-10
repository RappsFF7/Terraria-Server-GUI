using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace TerrariaServerCS
{
    public class TerrariaServerArguments : absTerrariaServerArguments
    {
        public TerrariaServerArguments()
        {
            // Setup default values
            Players = 8;
            World = string.Format(@"{0}\My Games\Terraria\Worlds\world1.wld", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            Port = 7777;
            Password = "terraria";
            MOTD = "Welcome to terraria";
            WorldPath = string.Format(@"{0}\My Games\Terraria\Worlds\", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            AutoCreate = 1;
            WorldName = "World";
            BanList = "banlist.txt";
            Secure = 1;
        }
    }
}
