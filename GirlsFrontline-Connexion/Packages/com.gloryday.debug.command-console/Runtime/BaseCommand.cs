using System;
using System.Collections.Generic;

namespace GloryDay.Debug
{
    public abstract class BaseCommand : IExecutable
    {
        public virtual void Execute(ParameterData data)
        {
            if (IsParameterDataValid(data) == false)
            {
                return;
            }
            
            Console.LogAsAdministrator($"{Name} is executed");
            
            var count = data.Count;
            for (var i = 0; i < count; i++)
            {
                var key = data.Names[i];
                if (Arguments.TryGetValue(key, out var argument))
                {
                    argument.SetProperties(data[key]);
                }
            }
        }
        
        /// <param name="data"> </param>
        /// <returns></returns>
        private bool IsParameterDataValid(ParameterData data)
        {
            if (data == null)
            {
                return false;
            }
            
            var count = data.Count;
            for (var i = 0; i < count; i++)
            {
                var name = data.Names[i];
                if (Arguments.ContainsKey(name))
                {
                    continue;
                }
                
                Console.LogError("Not supported argument is input");

                return false;
            }

            return true;
        }
        
        /// <returns>
        /// Name of the command to execute
        /// </returns>
        public string Name { get; set; }
        
        public Dictionary<string, BaseArgument> Arguments { get; } = new Dictionary<string, BaseArgument>();
    }
}