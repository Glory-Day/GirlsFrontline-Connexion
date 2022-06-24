using System;
using System.Collections.Generic;

using UnityEngine;

using Manager.Log.Console;
using UnityEngine.Audio;

namespace Manager
{
    /// <summary>
    /// Manager that manages the entire sound used in the game
    /// </summary>
    public class SoundManager : Singleton<SoundManager>
    {
        [Header("# Playing Background Audio Clip")]
        [SerializeField] 
        public AudioClip playingBackgroundAudioClip;
        
        /// <summary>
        /// Audio source playing background audio in <b>SoundManager</b> class
        /// </summary>
        private AudioSource backgroundAudioSource;

        private AudioMixer backgroundAudioMixer;
        
        private List<AudioClip> backgroundAudioClips;
        private List<AudioClip> effectAudioClips;
        private List<AudioClip> voiceAudioClips;

        private const string None = "None";
        private const string Master = "Master";

        protected SoundManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        private void Awake()
        {
            backgroundAudioSource = gameObject.AddComponent<AudioSource>();
            backgroundAudioSource.loop = true;
        }

        /// <summary>
        /// Initialize background, effect, voice audio clips
        /// </summary>
        public static void OnInitializeAudioClips()
        {
            LogManager.OnDebugLog(typeof(SoundManager), 
                $"Called OnInitializeAudioClips()");

            Instance.backgroundAudioClips = new List<AudioClip>();
            Instance.effectAudioClips     = new List<AudioClip>();
            Instance.voiceAudioClips      = new List<AudioClip>();
        }

        /// <summary>
        /// Play background audio select by index
        /// </summary>
        /// <param name="index"> Index of background audio clips </param>
        private static void PlayBackgroundAudio(int index)
        {
            LogManager.OnDebugLog(typeof(SoundManager), 
                $"Called PlayBackgroundAudio()");

            // If there is no audio clip, set the name as 'None', set it as the name of the audio clip
            var audioClipName = Instance.playingBackgroundAudioClip != null
                ? Instance.playingBackgroundAudioClip.name
                : None;

            // Audio clip to change
            var audioClip = Instance.backgroundAudioClips[index];

            // If the audio clip is playing, do not change it
            if (audioClipName.Equals(audioClip.name)) return;

            LogManager.OnDebugLog(Label.LabelType.Event, typeof(SoundManager), 
                $"Change background audio clip <b>{audioClipName}</b> to <b>{audioClip.name}</b>");
            
            Instance.backgroundAudioSource.clip = Instance.playingBackgroundAudioClip = audioClip;
            Instance.backgroundAudioSource.Play();
        }

        #region STATIC API

        /// <summary>
        /// Initialize background audio mixer to output audio mixer of background audio source
        /// </summary>
        public static void OnInitializeBackgroundAudioMixer()
        {
            LogManager.OnDebugLog(typeof(SoundManager), 
                $"Called OnInitializeBackgroundAudioMixer()");
            
            Instance.backgroundAudioSource.outputAudioMixerGroup = 
                Instance.backgroundAudioMixer.FindMatchingGroups(Master)[0];
        }
        
        /// <summary>
        /// Change the background audio clip when the scene changes
        /// </summary>
        /// <param name="name"> Name of the scene that changes </param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void OnChangeBackgroundAudioClip(SceneManager.SceneName name)
        {
            LogManager.OnDebugLog(typeof(SoundManager), 
                $"Called OnChangeBackgroundAudioClip()");
            
            switch (name)
            {
                case SceneManager.SceneName.MainScene:
                    PlayBackgroundAudio(0);
                    break;
                case SceneManager.SceneName.SelectionScene:
                    PlayBackgroundAudio(0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(name), name, null);
            }
        }

        /// <summary>
        /// Set background audio mixer
        /// </summary>
        /// <param name="audioMixer"> Background audio mixer </param>
        public static void SetBackgroundAudioMixer(AudioMixer audioMixer) =>
            Instance.backgroundAudioMixer = audioMixer;
        
        /// <summary>
        /// Add background audio clip with name
        /// </summary>
        /// <param name="audioClip"> Background audio clip </param>
        public static void AddBackgroundAudioClip(AudioClip audioClip) => 
            Instance.backgroundAudioClips.Add(audioClip);
        
        /// <summary>
        /// Add effect audio clip with name
        /// </summary>
        /// <param name="audioClip"> Effect audio clip </param>
        public static void AddEffectAudioClip(AudioClip audioClip) => 
            Instance.effectAudioClips.Add(audioClip);
        
        /// <summary>
        /// Add voice audio clip with name
        /// </summary>
        /// <param name="audioClip"> Voice audio clip </param>
        public static void AddVoiceAudioClip(AudioClip audioClip) => 
            Instance.voiceAudioClips.Add(audioClip);

        /// <summary>
        /// Returns effect audio clip search by name
        /// </summary>
        /// <param name="index"> Index of effect audio clips </param>
        /// <returns> Effect audio clip </returns>
        public static AudioClip GetEffectAudioClip(int index) => Instance.effectAudioClips[index];
        
        /// <summary>
        /// Returns voice audio clip search by name
        /// </summary>
        /// <param name="index"> Index of voice audio clips </param>
        /// <returns> Voice audio clip </returns>
        public static AudioClip GetVoiceAudioClip(int index) => Instance.voiceAudioClips[index];

        #endregion
    }
}
