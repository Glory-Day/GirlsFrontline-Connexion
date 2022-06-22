using System.Collections.Generic;

using UnityEngine;

using Manager.Log;

namespace Manager
{
    /// <summary>
    /// Class to manage sound needed for the game
    /// </summary>
    public class SoundManager : Singleton<SoundManager>
    {
        private static Dictionary<string, AudioClip> _backgroundAudioClips;
        private static Dictionary<string, AudioClip> _effectAudioClips;
        private static Dictionary<string, AudioClip> _voiceAudioClips;
        
        protected SoundManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }
        
        /// <summary>
        /// Initialize audios
        /// </summary>
        public static void OnInitializeAudios()
        {
#if UNITY_EDITOR

            LogManager.OnDebugLog(
                typeof(SoundManager), 
                $"Called OnInitializeAudios()");

#endif
            
            _backgroundAudioClips = new Dictionary<string, AudioClip>();
            _effectAudioClips = new Dictionary<string, AudioClip>();
            _voiceAudioClips = new Dictionary<string, AudioClip>();
        }

        #region STATIC API

        /// <summary>
        /// Add background audio with name
        /// </summary>
        /// <param name="key"> Name of background audio </param>
        /// <param name="audioClip"> Background audio </param>
        public static void AddBackgroundAudioClip(string key, AudioClip audioClip) => 
            _backgroundAudioClips.Add(key, audioClip);
        
        /// <summary>
        /// Add effect audio with name
        /// </summary>
        /// <param name="key"> Name of effect audio </param>
        /// <param name="audioClip"> Effect audio </param>
        public static void AddEffectAudioClip(string key, AudioClip audioClip) => 
            _effectAudioClips.Add(key, audioClip);
        
        /// <summary>
        /// Add voice audio with name
        /// </summary>
        /// <param name="key"> Name of voice audio </param>
        /// <param name="audioClip"> Voice audio </param>
        public static void AddVoiceAudioClip(string key, AudioClip audioClip) => 
            _voiceAudioClips.Add(key, audioClip);

        /// <summary>
        /// Search for and return background audio by name
        /// </summary>
        /// <param name="key"> Background audio name to search for </param>
        /// <returns> Discovered background audio </returns>
        public static AudioClip GetBackgroundAudioClip(string key) => _backgroundAudioClips[key];
        
        /// <summary>
        /// Search for and return effect audio by name
        /// </summary>
        /// <param name="key"> Effect audio name to search for </param>
        /// <returns> Discovered effect audio </returns>
        public static AudioClip GetEffectAudioClip(string key) => _effectAudioClips[key];
        
        /// <summary>
        /// Search for and return voice audio by name
        /// </summary>
        /// <param name="key"> Voice audio name to search for </param>
        /// <returns> Discovered voice audio </returns>
        public static AudioClip GetVoiceAudioClip(string key) => _voiceAudioClips[key];

        #endregion

    }
}
