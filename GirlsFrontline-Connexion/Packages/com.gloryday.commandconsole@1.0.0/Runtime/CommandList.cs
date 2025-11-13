using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GloryDay.Debug.Log;

namespace Library.UI.CommandConsole
{
    public static class CommandList
    {
        private static readonly Dictionary<string, BaseCommand> Commands;
        
        /// <returns>
        /// Sorted names of supported commands
        /// </returns>
        public static readonly string[] Names;
        
        static CommandList()
        {
            Commands = new Dictionary<string, BaseCommand>();

            // Get all class types derived from base class
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(
                type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(BaseCommand))).ToArray();
            
            // Create instances and set command properties
            var length = types.Length;
            for (var i = 0; i < length; i++)
            {
                var instance = (BaseCommand)Activator.CreateInstance(types[i]);
                foreach (var type in types[i].GetNestedTypes(BindingFlags.NonPublic))
                {
                    instance.Arguments.Add(type.Name, (BaseArgument)Activator.CreateInstance(type));
                }
                instance.Name = types[i].Name;
                
                Commands.Add(instance.Name, instance);
            }

            Names = Commands.Keys.OrderBy(key => key).ToArray();
        }

        /// <param name="key"> The key of the command to get </param>
        /// <param name="value">
        /// When this method returns, contains the value associated with the specified key, if the key is found.
        /// otherwise, null pointer
        /// </param>
        /// <returns> True if the command list contains an element with the specified key. otherwise, False </returns>
        /// <exception cref="UnsupportedCommandLineException">
        /// Represents an error that occurs when command line in the list is returned by the key
        /// </exception>
        public static bool TryGetValue(string key, out BaseCommand value)
        {
            try
            {
                if (Commands.ContainsKey(key) == false)
                {
                    throw new UnsupportedCommandLineException();
                }

                value = Commands[key];
                
                return true;
            }
            catch (UnsupportedCommandLineException exception)
            {
                LogManager.LogError(exception.Message);

                value = null;
            }

            return false;
        }

        #region PROPERTIES API

        /// <returns>
        /// Number of supported commands
        /// </returns>
        public static int Count => Commands.Count;

        #endregion
    }
}
