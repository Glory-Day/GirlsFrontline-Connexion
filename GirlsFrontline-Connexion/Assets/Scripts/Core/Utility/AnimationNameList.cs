using System.Collections;
using System.Linq;
using UnityEngine;

namespace GloryDay.Animation
{
    /// <summary>
    /// Names inside animation component
    /// </summary>
    public class AnimationNameList
    {
        private readonly string[] _names;
        
        public AnimationNameList(IEnumerable animation)
        {
            _names = (from AnimationState state in animation select state.name).ToArray();
        }
        
        public string this[int index] => _names[index];
    }
}
