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
        #region properties - custom
        /// <summary>
        /// Specifies the port to listen on.
        /// Usage: port {port number}
        /// </summary>
        public int? Port { get; set; }

        /// <summary>
        /// Sets the max number of players.
        /// Usage: players {number}
        /// Alias: maxplayers {number}
        /// </summary>
        public int? Players { get; set; }

        /// <summary>
        /// Sets the server password.
        /// Usage: password {password}
        /// Alias: pass {password}
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Load a world and automatically start the server.
        /// Usage: world {world file}
        /// </summary>
        public string World { get; set; }

        /// <summary>
        /// Creates a world if none is found in the path specified by -world. World size is specified by: 1(small), 2(medium), and 3(large).
        /// Usage: autocreate {#}
        /// </summary>
        public int? AutoCreate { get; set; }

        /// <summary>
        /// Set the message of the day
        /// Usage: motd {message} 
        /// </summary>
        public string MOTD { get; set; }

        /// <summary>
        /// Specifies the location of the banlist. Defaults to "banlist.txt" in the working directory.
        /// Usage: banlist {path}
        /// </summary>
        public string BanList { get; set; }

        /// <summary>
        /// Sets the name of the world when using -autocreate.
        /// Usage: worldname {world name}
        /// </summary>
        public string WorldName { get; set; }

        /// <summary>
        /// Sets the folder where world files will be stored
        /// Usage: worldpath {full folder path}
        /// </summary>
        public string WorldPath { get; set; }

        /// <summary>
        /// Adds addition cheat protection to the server.
        /// Usage: secure {1 | 0}
        /// </summary>
        public int? Secure { get; set; }
        #endregion

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
