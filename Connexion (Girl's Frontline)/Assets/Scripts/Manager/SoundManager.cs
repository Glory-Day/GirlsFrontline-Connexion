using System;
using System.Collections.Generic;

using UnityEngine;

using Manager.Log;

namespace Manager
{
    /// <summary>
    /// Manager that manages the entire sound used in the game
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
        /// Initialize background, effect, voice audio clips
        /// </summary>
        public static void OnInitializeAudioClips()
        {
            LogManager.OnDebugLog(typeof(SoundManager), 
                $"Called OnInitializeAudioClips()");

            _backgroundAudioClips = new Dictionary<string, AudioClip>();
            _effectAudioClips = new Dictionary<string, AudioClip>();
            _voiceAudioClips = new Dictionary<string, AudioClip>();
        }

        #region STATIC API

        /// <summary>
        /// Add background audio clip with name
        /// </summary>
        /// <param name="key"> Name of background audio clip </param>
        /// <param name="audioClip"> Background audio clip </param>
        public static void AddBackgroundAudioClip(string key, AudioClip audioClip) => 
            _backgroundAudioClips.Add(key, audioClip);
        
        /// <summary>
        /// Add effect audio clip with name
        /// </summary>
        /// <param name="key"> Name of effect audio clip </param>
        /// <param name="audioClip"> Effect audio clip </param>
        public static void AddEffectAudioClip(string key, AudioClip audioClip) => 
            _effectAudioClips.Add(key, audioClip);
        
        /// <summary>
        /// Add voice audio clip with name
        /// </summary>
        /// <param name="key"> Name of voice audio clip </param>
        /// <param name="audioClip"> Voice audio clip </param>
        public static void AddVoiceAudioClip(string key, AudioClip audioClip) => 
            _voiceAudioClips.Add(key, audioClip);

        /// <summary>
        /// Returns background audio clip search by name
        /// </summary>
        /// <param name="key"> Background audio clip name to search for </param>
        /// <returns> Background audio clip </returns>
        public static AudioClip GetBackgroundAudioClip(string key) => _backgroundAudioClips[key];
        
        /// <summary>
        /// Returns effect audio clip search by name
        /// </summary>
        /// <param name="key"> Effect audio clip name to search for </param>
        /// <returns> Effect audio clip </returns>
        public static AudioClip GetEffectAudioClip(string key) => _effectAudioClips[key];
        
        /// <summary>
        /// Returns voice audio clip search by name
        /// </summary>
        /// <param name="key"> Voice audio clip name to search for </param>
        /// <returns> Voice audio clip </returns>
        public static AudioClip GetVoiceAudioClip(string key) => _voiceAudioClips[key];

        #endregion
    }
}
