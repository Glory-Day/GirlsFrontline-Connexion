using UnityEngine;

namespace Utility.Extension
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

        #region PROPERTIES API

        public string Name { get; }
        
        public int Start { get; }

        #endregion
    }
}
