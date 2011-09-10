using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace TerrariaServerCS
{
    #region enums
    public enum enumTerrariaServerSize
    {
        Small = 1,
        Medium = 2,
        Large = 3
    }
    #endregion

    public abstract class absTerrariaServerArguments
    {
        private string msConfigFileLocation = "TerrariaServerGUIConfig.tsg";

        /// <summary>
        /// If a config file line starts with this string, the line is skipped (treated as a comment line)
        /// </summary>
        public string msConfigFileComment = "#";

        #region properties
        /*public virtual string _ConfigFileLocation 
        {
            get { return msConfigFileLocation; }
            set { msConfigFileLocation = value; }
        }*/
        #endregion

        #region properties - file
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
        #endregion

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
        public string getArgumentsForCmd(string psConfigFile)
        {
            string tsResult = "";

            // Create a command to read from the config file
            if (psConfigFile.Trim().Length > 0)
                tsResult = string.Format("-config {0}", psConfigFile);

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
        }

        public virtual void saveToFile(string psFile)
        {
            File.WriteAllText(psFile, getArgumentsForFile());
        }
        #endregion

        #region methods - protected
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
