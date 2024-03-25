using System.Collections.Generic;
using UnityEngine;

namespace Utility.Manager.Resource
{
    public class AudioClipResource
    {
        public Dictionary<string, AudioClip> Background { get; } = new Dictionary<string, AudioClip>();

        public Dictionary<string, AudioClip> Effect { get; } = new Dictionary<string, AudioClip>();
        
        public Dictionary<string, AudioClip> Voice { get; } = new Dictionary<string, AudioClip>();
    }
}
