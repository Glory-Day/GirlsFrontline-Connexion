using UnityEngine;

namespace Core.Utility.Attribute
{
    public class AliasAttribute : PropertyAttribute
    {
        public string Text { get; private set; }
        
        public AliasAttribute(string text) => Text = text;
    }
}