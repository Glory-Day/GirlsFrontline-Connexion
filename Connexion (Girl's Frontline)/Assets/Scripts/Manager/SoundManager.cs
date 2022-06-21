using System.Collections.Generic;

using UnityEngine;

using Manager.Log;

namespace Manager
{
    public class SoundManager : Singleton<SoundManager>
    {
        private static Dictionary<string, AudioClip> _backgroundAudioClips;
        private static Dictionary<string, AudioClip> _effectAudioClips;
        private static Dictionary<string, AudioClip> _voiceAudioClips;
        
        protected SoundManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        // Start is called before the first frame update
        public static void OnInitializeAudioData()
        {
#if UNITY_EDITOR

            LogManager.OnDebugLog(
                typeof(SoundManager), 
                $"Called OnInitializeAudioData()");

#endif
            
            _backgroundAudioClips = new Dictionary<string, AudioClip>();
            _effectAudioClips = new Dictionary<string, AudioClip>();
            _voiceAudioClips = new Dictionary<string, AudioClip>();
        }

        #region STATIC API

        public static void AddBackgroundAudioClip(string key, AudioClip audioClip) => 
            _backgroundAudioClips.Add(key, audioClip);
        
        public static void AddEffectAudioClip(string key, AudioClip audioClip) => 
            _effectAudioClips.Add(key, audioClip);
        
        public static void AddVoiceAudioClip(string key, AudioClip audioClip) => 
            _voiceAudioClips.Add(key, audioClip);

        public static AudioClip GetBackgroundAudioClip(string key) => _backgroundAudioClips[key];
        public static AudioClip GetEffectAudioClip(string key) => _effectAudioClips[key];
        public static AudioClip GetVoiceAudioClip(string key) => _voiceAudioClips[key];

        #endregion

    }
}
