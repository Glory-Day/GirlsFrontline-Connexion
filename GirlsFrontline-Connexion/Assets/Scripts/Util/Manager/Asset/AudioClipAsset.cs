using System.Collections.Generic;

namespace Util.Manager.Asset
{
    public class AudioClipAsset
    {
        public AudioClipAsset()
        {
            Background = new Dictionary<string, UnityEngine.AudioClip>();
            Effect = new Dictionary<string, UnityEngine.AudioClip>();
            Voice = new Dictionary<string, UnityEngine.AudioClip>();
        }
        
        public Dictionary<string, UnityEngine.AudioClip> Background { get; set; }
        public Dictionary<string, UnityEngine.AudioClip> Effect { get; set; }
        public Dictionary<string, UnityEngine.AudioClip> Voice { get; set; }
    }
}
