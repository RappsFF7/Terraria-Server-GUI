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
        public TerrariaServerArguments() : base()
        {
            char tsDirSeparater = Path.DirectorySeparatorChar;
            string tsPathMyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string tsPathTerrariaSaves = string.Format("{0}{1}My Games{1}Terraria{1}", tsPathMyDocuments, tsDirSeparater);

            // GUI default values
            TSG_AutoSave = 1;
            TSG_AutoSaveDelay = 1;
            TSG_AutoSaveFactor = 2;
            TSG_ServerPath = (_DefaultGameLocation == "" ? "" : _DefaultGameLocation + "TerrariaServer.exe");
            TSG_ServerType = 1;
            TSG_LogFolder = string.Format(@"{0}Logs{1}", tsPathTerrariaSaves, tsDirSeparater);
            TSG_LogFilePrefix = "TerrariaServerLog";
            TSG_LogFileSizeLimit = 5;
            TSG_LogFileFullProcedure = 1;

            // Official server default values
            Players = 8;
            World = string.Format(@"{0}Worlds{1}world1.wld", tsPathTerrariaSaves, tsDirSeparater);
            Port = 7777;
            Password = "";
            MOTD = "Welcome to terraria";
            WorldPath = string.Format(@"{0}Worlds{1}", tsPathTerrariaSaves, tsDirSeparater);
            AutoCreate = 1;
            WorldName = "World";
            BanList = "banlist.txt";
            Secure = 1;
        }
    }
}
