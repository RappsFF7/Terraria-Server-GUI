using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace TerrariaServerCS
{
    /// <summary>
    /// T is the class inheriting this abstract class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class absTerrariaServerArguments<T>
    {
        #region Properties
        public virtual string _ConfigFileLocation { get { return "TerrariaServerConfig.txt"; } }
        public abstract T _DefaultValues { get; }
        #endregion

        #region methods - public
        /// <summary>
        /// Creates an argument string that can be output to create an config file
        /// </summary>
        /// <returns></returns>
        public string getArgumentsForFile()
        {
            string tsResult = "";

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

            // Output a config file
            File.WriteAllText(_ConfigFileLocation, getArgumentsForFile());

            // Create a command to read from the config file
            tsResult = string.Format("-config {0}", _ConfigFileLocation);

            return tsResult;
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

            // For each property, create an argument for it if it doesn't not equal the default value
            TerrariaServerArguments toEmptyArgs = new TerrariaServerArguments();
            foreach (PropertyInfo toCurrentProperty in toCurrentProperties)
            {
                // Get the property value
                object toPropertyValue = toCurrentProperty.GetValue(this, null) ?? toCurrentProperty.GetValue(this._DefaultValues, null);
                
                // Add the name and value to the text file
                toOutput.Add(string.Format("{0}={1}", toCurrentProperty.Name, toPropertyValue));
            }

            return toOutput;
        }
        #endregion
    }
}
