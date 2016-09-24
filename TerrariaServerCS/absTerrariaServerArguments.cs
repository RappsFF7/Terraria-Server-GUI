using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using Microsoft.Win32;

namespace TerrariaServerCS
{
    #region enums
    public enum enumTerrariaServerSize
    {
        Small = 1,
        Medium = 2,
        Large = 3
    }

    public enum enumTerrariaBackupFactor
    {
        Minutes,
        Hours,
        Days
    }

    public enum enumTerrariaLogFileFullProcedure
    {
        Overwrite,
        New_File
    }

    public enum enumSteamLobby
    {
        NoSteamSupport = 0,
        Friends,
        Private
    }
    #endregion

    public abstract class absTerrariaServerArguments
    {
        /// <summary>
        /// If a config file line starts with this string, the line is skipped (treated as a comment line)
        /// </summary>
        public string msConfigFileComment = "#";

        #region properties
        public string _DefaultConfigFileExtention
        {
            get { return "txt"; }
        }
        public virtual string _DefaultConfigFileName 
        {
            get { return "TerrariaServerGUIConfig"; }
        }
        public virtual string _DefaultGameLocation
        { get; protected set; }
        #endregion

        #region properties - gui server config file parameters
        /// <summary>
        /// The location of this configuration file
        /// </summary>
        public string TSG_ConfigPath { set; get; }

        /// <summary>
        /// The location of the server executable
        /// </summary>
        public string TSG_ServerPath { set; get; }

        /// <summary>
        /// The type of the server
        /// </summary>
        public int TSG_ServerType { get; set; }

        /// <summary>
        /// Determines if the gui will autosave or not
        /// </summary>
        public int TSG_AutoSave { get; set; }

        /// <summary>
        /// The time between autosaves
        /// </summary>
        public int TSG_AutoSaveDelay { get; set; }

        /// <summary>
        /// The unit the auto save delay is measured in
        /// </summary>
        public int TSG_AutoSaveFactor { get; set; }

        /// <summary>
        /// The location the log files are stored
        /// </summary>
        public string TSG_LogFolder { get; set; }

        /// <summary>
        /// The prefix used to name the log files
        /// </summary>
        public string TSG_LogFilePrefix { get; set; }

        /// <summary>
        /// The maximum size the log file will be allowed to reach
        /// </summary>
        public int TSG_LogFileSizeLimit { get; set; }

        /// <summary>
        /// The action to take when the log file reaches it's limit
        /// </summary>
        public int TSG_LogFileFullProcedure { get; set; }

        /// <summary>
        /// Determines if percentages output by the server are logged or not
        /// (as it tends to clog up the log file)
        /// </summary>
        public int TSG_LogPercentagesCollapsed { get; set; }
        #endregion

        #region properties - official server config file parameters
        /// <summary>
        /// Specifies the port to listen on.
        /// Usage: port {port number}
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Sets the max number of players.
        /// Usage: players {number}
        /// Alias: maxplayers {number}
        /// </summary>
        public int Players { get; set; }

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
        public int AutoCreate { get; set; }

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
        public int Secure { get; set; }

        /// <summary>
        /// Sets world difficulty when using -autocreate. Options 0 (normal), 1 (expert)
        /// Usage: difficulty {1 | 0}
        /// </summary>
        public int Difficulty { get; set; }

        /// <summary>
        /// Disables automatic universal plug and play
        /// Usage: difficulty {true | false}
        /// </summary>
        public Boolean NoUPNP { get; set; }

        /// <summary>
        /// Enables Steam support
        /// Usage: difficulty {true | false}
        /// </summary>
        public Boolean Steam { get; set; }

        /// <summary>
        /// Allows friends to join the server or sets it to private if Steam is enabled
        /// Usage: difficulty {friends | private}
        /// </summary>
        public string Lobby { get; set; }
        #endregion

        protected absTerrariaServerArguments()
        {
            _DefaultGameLocation = getGameLocationDefault();
        }

        #region methods - public
        /// <summary>
        /// Creates an argument string that can be output to create an config file
        /// </summary>
        /// <returns></returns>
        public string getArgumentsForFile()
        {
            string tsResult = "";

            // For each set of argument key and value pairs, add line breaks to separate them in the file
            getArgumentsArray().ForEach(s => tsResult += string.Format("{0}{1}{1}", s, Environment.NewLine));

            return tsResult;
        }

        /// <summary>
        /// Creates an argument string that can be used when starting the server
        /// </summary>
        /// <returns></returns>
        public string getArgumentsForCmd()
        {
            string tsResult = "";

            // Create a command to read from the config file
            if (TSG_ConfigPath.Trim().Length > 0)
                tsResult = string.Format("-config {0} {1} -lobby {2} {3}"
                    , "\"" +TSG_ConfigPath + "\""
                    , (Steam ? "-steam" : "")
                    , Lobby
                    , (NoUPNP ? "-noupnp" : ""));

            return tsResult;
        }

        public virtual void loadFromFile(string psFile)
        {
            string tsFileLine = "";
            int tiLineCount = 0;

            // Safely open the file
            using (StreamReader toReader = File.OpenText(psFile))
            {
                // Parse the file
                while (!toReader.EndOfStream)
                {
                    // Read the line
                    tsFileLine = toReader.ReadLine().Trim();
                    tiLineCount++;

                    // Check for empty and commented out lines
                    if (tsFileLine.Length > 0 && !tsFileLine.StartsWith(msConfigFileComment))
                    {
                        PropertyInfo toProperty;
                        string[] tsConfigLine;
                        string tsKey;
                        string tsValue;

                        // Split the line into key and value
                        tsConfigLine = tsFileLine.Split('=');

                        // Check that the data meets the required structure
                        if (tsConfigLine.Length < 2)
                            throw new Exception("Error reading config file line: " + tiLineCount);

                        tsKey = tsConfigLine[0];
                        tsValue = tsConfigLine[1];

                        // Get the property
                        toProperty = this.GetType().GetProperty(tsKey);

                        if (toProperty == null)
                            throw new Exception("Error, no property exists by the name: " + tsKey);

                        // Set the property
                        toProperty.SetValue(this, Convert.ChangeType(tsValue, toProperty.PropertyType), null);
                    }
                }
            }
            
            TSG_ConfigPath = psFile;
        }

        public virtual void saveToFile(string psFile)
        {
            File.WriteAllText(psFile, getArgumentsForFile());
            TSG_ConfigPath = psFile;
        }
        #endregion

        #region methods - protected
        /// <summary>
        /// Looks in the computers registry for the game path from Steam with a trailing directory slash.
        /// Returns an empty string if no registry entry was found.
        /// </summary>
        /// <returns></returns>
        protected virtual string getGameLocationDefault()
        {
            char PS = Path.DirectorySeparatorChar;

            // Try to get the server path from Steam
            string tsServerFile = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Valve\Steam", "SteamPath", "").ToString();

            // If found, transform to get server location
            if (tsServerFile != "")
            {
                // Convert the file path string to use the system's file separators
                tsServerFile = new FileInfo(tsServerFile).FullName;

                // Add the default path for the server
                tsServerFile = string.Format(@"{1}{0}steamapps{0}common{0}terraria{0}", PS, tsServerFile);
            }

            // Return
            return tsServerFile;
        }
        #endregion

        #region methods - private
        /// <summary>
        /// Creates and list of arguments from the class properties
        /// </summary>
        private List<string> getArgumentsArray()
        {
            Type toCurrentType;
            PropertyInfo[] toCurrentProperties;
            List<string> toOutput;

            // Initialize
            toOutput = new List<string>();

            // Get the current type
            toCurrentType = this.GetType();

            // Get the properties for the current type
            toCurrentProperties = toCurrentType.GetProperties().Where(p => !p.Name.StartsWith("_")).ToArray();

            foreach (PropertyInfo toCurrentProperty in toCurrentProperties)
            {
                // Get the property value
                object toPropertyValue = toCurrentProperty.GetValue(this, null);
                
                // Add the name and value to the text file
                toOutput.Add(string.Format("{0}={1}", toCurrentProperty.Name, toPropertyValue));
            }

            return toOutput;
        }
        #endregion
    }
}
