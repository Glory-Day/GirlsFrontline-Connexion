using System;
using System.Globalization;
using UnityEngine;

namespace Utility.Extension
{
    public class SerializableStructureAttribute : PropertyAttribute
    {
        public SerializableStructureAttribute(Type type)
        {
            var textInfo = new CultureInfo("en-US",false).TextInfo;
            
            var fieldInfos = type.GetFields();
            var length = fieldInfos.Length;
            
            FieldNames = new string[length];
            for (var i = 0; i < length; i++)
            {
                var fieldInfo = fieldInfos[i];
                FieldNames[i] = fieldInfo.Name;
            }
        }
        
        public string[] FieldNames { get; }
    }
}