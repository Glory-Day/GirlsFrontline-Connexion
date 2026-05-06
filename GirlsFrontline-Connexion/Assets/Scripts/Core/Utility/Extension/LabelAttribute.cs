using UnityEngine;

namespace Core.Utility.Extension
{
    public class LabelAttribute : PropertyAttribute
    {
        public string Text { get; private set; }
        
        public LabelAttribute(string text) => Text = text;
    }
}