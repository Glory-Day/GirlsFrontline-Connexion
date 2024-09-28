using System.Collections.Generic;
using UnityEngine;

namespace Utility.Data
{
    [CreateAssetMenu(fileName = "Reorderable Text Template", 
                     menuName = "Scriptable Object/Template/Reorderable Text Template")]
    public class ReorderableTextTemplate : ScriptableObject
    {
        [SerializeField] private List<string> texts = new List<string>();
        
        public List<string> Items => texts;
    }
}
