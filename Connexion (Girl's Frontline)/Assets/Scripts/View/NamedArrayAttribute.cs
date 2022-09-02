#region NAMESPACE API

using UnityEngine;

#endregion

namespace View
{
    public class NamedArrayAttribute : PropertyAttribute
    {
        public NamedArrayAttribute(string name)
        {
            Name = name;
            Start = 0;
        }
        
        public NamedArrayAttribute(string name, int start)
        {
            Name = name;
            Start = start;
        }
        
        public string Name { get; }
        
        public int Start { get; }
    }
}
