#region NAMESPACE API

using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;

using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Manager
{
    /// <summary>
    /// Manager that manages the entire sound used in <b>Game Application</b>
    /// </summary>
    public class SoundManager : Singleton<SoundManager>
    {
        #region SERIALIZABLE FIELD

        [Header("# Playing Background Audio Clip")]
        [SerializeField] 
        public AudioClip playingBackgroundAudioClip;

        #endregion

        /// <summary>
        /// Audio source playing background audio in <b>SoundManager</b>
        /// </summary>
        private AudioSource backgroundAudioSource;

        private Dictionary<string, AudioMixer> audioMixers;
        
        private Dictionary<string, AudioClip> backgroundAudioClips;
        private Dictionary<string, AudioClip> effectAudioClips;
        private Dictionary<string, AudioClip> voiceAudioClips;

        private const string None   = "None";
        private const string Master = "Master";

        protected SoundManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        // Awake is called when the script instance is being loaded
        private void Awake()
        {
            backgroundAudioSource = gameObject.AddComponent<AudioSource>();
            backgroundAudioSource.loop = true;
        }

        /// <summary>
        /// Initialize audio mixer and background, effect, voice audio clips
        /// </summary>
        public static void OnInitializeAudioClips()
        {
            LogManager.OnDebugLog(typeof(SoundManager), 
                $"OnInitializeAudioClips()");

            Instance.audioMixers          = new Dictionary<string, AudioMixer>();
            Instance.backgroundAudioClips = new Dictionary<string, AudioClip>();
            Instance.effectAudioClips     = new Dictionary<string, AudioClip>();
            Instance.voiceAudioClips      = new Dictionary<string, AudioClip>();
        }

        /// <summary>
        /// Play background audio source select by key value
        /// </summary>
        /// <param name="key"> Key value of background audio clips </param>
        private static void PlayBackgroundAudioSource(string key)
        {
            LogManager.OnDebugLog(typeof(SoundManager), 
                $"PlayBackgroundAudioSource()");

            // If there is no audio clip, set the name as 'None', set it as the name of the audio clip
            var audioClipName = Instance.playingBackgroundAudioClip != null
                ? Instance.playingBackgroundAudioClip.name
                : None;

            // Audio clip to change
            var audioClip = Instance.backgroundAudioClips[key];

            // If the audio clip is playing, do not change it
            if (audioClipName.Equals(audioClip.name)) return;

            LogManager.OnDebugLog(LabelType.Event, typeof(SoundManager), 
                $"Change background audio clip <b>{audioClipName}</b> to <b>{audioClip.name}</b>");
            
            Instance.backgroundAudioSource.clip = Instance.playingBackgroundAudioClip = audioClip;
            Instance.backgroundAudioSource.Play();
        }

        #region SOUND API

        /// <summary>
        /// Initialize background audio mixer to output audio mixer of background audio source
        /// </summary>
        public static void OnInitializeBackgroundAudioMixer()
        {
            LogManager.OnDebugLog(typeof(SoundManager), 
                $"OnInitializeBackgroundAudioMixer()");
            
            Instance.backgroundAudioSource.outputAudioMixerGroup = 
                Instance.audioMixers[DataManager.ResourceData.audioMixer.names[0]].FindMatchingGroups(
                    Master)[0];
        }
        
        /// <summary>
        /// Change the background audio clip when the scene changes
        /// </summary>
        /// <param name="name"> Name of the scene that changes </param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void OnChangeBackgroundAudioClip(SceneManager.SceneName name)
        {
            LogManager.OnDebugLog(typeof(SoundManager), 
                $"OnChangeBackgroundAudioClip()");
            
            switch (name)
            {
                case SceneManager.SceneName.MainScene:
                    PlayBackgroundAudioSource(DataManager.ResourceData.backgroundAudioClip.names[0]);
                    break;
                case SceneManager.SceneName.SelectionScene:
                    PlayBackgroundAudioSource(DataManager.ResourceData.backgroundAudioClip.names[0]);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(name), name, null);
            }
        }

        /// <summary>
        /// Set background audio mixer
        /// </summary>
        /// <param name="key"> <b>string</b> type key value </param>
        /// <param name="audioMixer"> Background audio mixer </param>
        public static void AddAudioMixer(string key, AudioMixer audioMixer) =>
            Instance.audioMixers.Add(key, audioMixer);
        
        /// <summary>
        /// Add background audio clip in <b>List&lt;AudioClip&gt; backgroundAudioClips</b>
        /// </summary>
        /// <param name="key"> <b>string</b> type key value </param>
        /// <param name="audioClip"> Background audio clip </param>
        public static void AddBackgroundAudioClip(string key, AudioClip audioClip) => 
            Instance.backgroundAudioClips.Add(key, audioClip);
        
        /// <summary>
        /// Add effect audio clip in <b>List&lt;AudioClip&gt; effectAudioClips</b>
        /// </summary>
        /// <param name="key"> <b>string</b> type key value </param>
        /// <param name="audioClip"> Effect audio clip </param>
        public static void AddEffectAudioClip(string key, AudioClip audioClip) => 
            Instance.effectAudioClips.Add(key, audioClip);
        
        /// <summary>
        /// Add voice audio clip in <b>List&lt;AudioClip&gt; voiceAudioClips</b>
        /// </summary>
        /// <param name="key"> <b>string</b> type key value </param>
        /// <param name="audioClip"> Voice audio clip </param>
        public static void AddVoiceAudioClip(string key, AudioClip audioClip) => 
            Instance.voiceAudioClips.Add(key, audioClip);

        /// <summary>
        /// Returns effect audio clip search by key value
        /// </summary>
        /// <param name="key"> Key value of effect audio clips </param>
        /// <returns> Effect audio clip </returns>
        public static AudioClip GetEffectAudioClip(string key) => Instance.effectAudioClips[key];
        
        /// <summary>
        /// Returns voice audio clip search by key value
        /// </summary>
        /// <param name="key"> Key value of voice audio clips </param>
        /// <returns> Voice audio clip </returns>
        public static AudioClip GetVoiceAudioClip(string key) => Instance.voiceAudioClips[key];

        #endregion
    }
}
