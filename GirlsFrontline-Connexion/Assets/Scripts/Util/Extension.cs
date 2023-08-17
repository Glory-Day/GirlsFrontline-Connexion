using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Util
{
    public static class Extension
    {
        public static List<string> GetPropertyNames(this Type type)
        {
            return type.GetProperties().Select(propertyInfo => propertyInfo.Name.ToLower()).ToList();
        }
        
        public static List<string> GetKeys<T>(this IDictionary dictionary)
        {
            return dictionary.Keys.Cast<string>().ToList();
        }

        public static string GetName(this string name)
        {
            return string.Concat(name.Where(i => char.IsWhiteSpace(i) == false));
        }
        
#if UNITY_EDITOR || DEVELOPMENT_BUILD
        
        /// <summary>
        /// Get the name of <see cref="Manager.Log.LogLabel"/> in all upper case
        /// </summary>
        public static string GetName(this Manager.Log.LogLabel label)
        {
            return Enum.GetName(typeof(Manager.Log.LogLabel), label)?.ToUpper();
        }

#endif
    }
}
