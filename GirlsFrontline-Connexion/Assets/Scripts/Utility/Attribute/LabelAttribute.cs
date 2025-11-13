using UnityEngine;

namespace Backend.Utility.Attribute
{
    public class LabelAttribute : PropertyAttribute
    {
        public string Text { get; private set; }

        public LabelAttribute(string text) => Text = text;
    }
}
