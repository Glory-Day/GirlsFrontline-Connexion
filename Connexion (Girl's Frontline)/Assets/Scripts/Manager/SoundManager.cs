﻿#region NAMESPACE API

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Manager.Sound;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Manager
{
    /// <summary>
    /// Manager that manages sound used in <b>Game Application</b>
    /// </summary>
    public class SoundManager : Singleton<SoundManager>
    {
        #region SERIALIZABLE FIELD

        [Header("# Playing Background Audio Clip")]
        [SerializeField]
        public AudioClip playingBackgroundAudioClip;

        #endregion

        /// <summary>
        /// <see cref="AudioSource"/> playing background <see cref="AudioClip"/>
        /// </summary>
        private AudioSource backgroundAudioSource;
        
        private AudioMixer masterAudioMixer;

        private AudioMixerGroup backgroundAudioMixerGroup;
        private AudioMixerGroup effectAudioMixerGroup;
        private AudioMixerGroup voiceAudioMixerGroup;

        private Dictionary<string, AudioClip> backgroundAudioClips;
        private Dictionary<string, AudioClip> effectAudioClips;
        private Dictionary<string, AudioClip> voiceAudioClips;

        #region CONSTANT FIELD
        
        // Audio clip name if audio clip of background audio source is none
        private const string None = "None";

        // Audio mixer object name
        private const string AudioMixerName = "Audio Mixer";

        #endregion

        protected SoundManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        /// <summary>
        /// Initialize <see cref="SoundManager"/> components and fields
        /// </summary>
        public static void OnInitialize()
        {
            LogManager.OnDebugLog(typeof(SoundManager),
                $"OnInitialize()");
            
            // Initialize audio mixer group
            var audioMixerData = GameObject.Find(AudioMixerName).GetComponent<AudioMixerData>();
            Instance.masterAudioMixer = audioMixerData.masterAudioMixer;
            Instance.backgroundAudioMixerGroup = audioMixerData.backgroundAudioMixerGroup;
            Instance.effectAudioMixerGroup = audioMixerData.effectAudioMixerGroup;
            Instance.voiceAudioMixerGroup = audioMixerData.voiceAudioMixerGroup;
            
            // Initialize audio source component and setting
            Instance.gameObject.AddComponent<AudioListener>();
            Instance.backgroundAudioSource = Instance.gameObject.AddComponent<AudioSource>();
            Instance.backgroundAudioSource.playOnAwake = false;
            Instance.backgroundAudioSource.loop = true;
            Instance.backgroundAudioSource.outputAudioMixerGroup = Instance.backgroundAudioMixerGroup;
            
            // Initialize list of audio clips
            Instance.backgroundAudioClips = new Dictionary<string, AudioClip>();
            Instance.effectAudioClips = new Dictionary<string, AudioClip>();
            Instance.voiceAudioClips = new Dictionary<string, AudioClip>();
        }

        /// <summary>
        /// Play background audio source select by key value
        /// </summary>
        /// <param name="key"> Key value of background audio clips </param>
        private void PlayBackgroundAudioSource(string key)
        {
            LogManager.OnDebugLog(typeof(SoundManager),
                $"PlayBackgroundAudioSource()");

            // If there is no audio clip, set the name as 'None', set it as the name of the audio clip
            var audioClipName = playingBackgroundAudioClip != null
                                    ? playingBackgroundAudioClip.name
                                    : None;

            // Audio clip to change
            var audioClip = backgroundAudioClips[key];

            // If the audio clip is playing, do not change it
            if (audioClipName.Equals(audioClip.name)) return;

            playingBackgroundAudioClip = audioClip;
            backgroundAudioSource.PlayOneShot(playingBackgroundAudioClip);

            LogManager.OnDebugLog(LabelType.Success, typeof(SoundManager),
                $"Change background audio clip <b>{audioClipName}</b> to <b>{audioClip.name}</b> successfully");
        }

        #region SOUND API

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
                    Instance.PlayBackgroundAudioSource(DataManager.AssetData.backgroundAudioClip.names[0]);
                    break;
                case SceneManager.SceneName.SelectionScene:
                    Instance.PlayBackgroundAudioSource(DataManager.AssetData.backgroundAudioClip.names[0]);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(name), name, null);
            }
        }

        /// <summary>
        /// Add background audio clip in List&lt;AudioClip&gt; backgroundAudioClips
        /// </summary>
        /// <param name="key"> Key value of background audio clips </param>
        /// <param name="audioClip"> Background audio clip </param>
        public static void AddBackgroundAudioClip(string key, AudioClip audioClip)
        {
            Instance.backgroundAudioClips.Add(key, audioClip);
        }

        /// <summary>
        /// Add effect audio clip in List&lt;AudioClip&gt; effectAudioClips
        /// </summary>
        /// <param name="key"> Key value of effect audio clips </param>
        /// <param name="audioClip"> Effect audio clip </param>
        public static void AddEffectAudioClip(string key, AudioClip audioClip)
        {
            Instance.effectAudioClips.Add(key, audioClip);
        }

        /// <summary>
        /// Add voice audio clip in List&lt;AudioClip&gt; voiceAudioClips
        /// </summary>
        /// <param name="key"> Key value of voice audio clips </param>
        /// <param name="audioClip"> Voice audio clip </param>
        public static void AddVoiceAudioClip(string key, AudioClip audioClip)
        {
            Instance.voiceAudioClips.Add(key, audioClip);
        }

        public static AudioMixer MasterAudioMixer
        {
            get => Instance.masterAudioMixer;
            set => Instance.masterAudioMixer = value;
        }

        /// <summary>
        /// Get effect audio clip search by key value
        /// </summary>
        /// <param name="key"> Key value of effect audio clips </param>
        /// <returns> Effect audio clip </returns>
        public static AudioClip GetEffectAudioClip(string key)
        {
            return Instance.effectAudioClips[key];
        }

        /// <summary>
        /// Get voice audio clip search by key value
        /// </summary>
        /// <param name="key"> Key value of voice audio clips </param>
        /// <returns> Voice audio clip </returns>
        public static AudioClip GetVoiceAudioClip(string key)
        {
            return Instance.voiceAudioClips[key];
        }

        #endregion
    }
}
