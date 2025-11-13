using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.UI.CommandConsole
{
    /// <summary>
    /// Data for storing parameter information in the input command line
    /// </summary>
    public class ParameterData
    {
        private readonly Dictionary<string, string[]> _parameters;
        
        /// <param name="names"> The names of the parameters </param>
        /// <param name="data"> The data of the parameters </param>
        public ParameterData(IReadOnlyList<string> names, IReadOnlyList<string[]> data)
        {
            _parameters = new Dictionary<string, string[]>();

            var count = names.Count;
            for (var i = 0; i < count; i++)
            {
                _parameters.Add(names[i], data[i]);
            }
        }
        
        /// <returns>
        /// Parameter names in <see cref="ParameterData"/>
        /// </returns>
        public string[] Names => _parameters.Keys.ToArray();

        /// <returns>
        /// Number of parameters in <see cref="ParameterData"/>
        /// </returns>
        public int Count => _parameters.Count;
        
        public string[] this[string key] => _parameters[key];
    }
}