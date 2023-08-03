using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Util.Manager;
using Util.Log;

namespace Object.Manager
{
    public class SoundManager : Singleton<SoundManager>
    {
        #region SERIALIZABLE FIELD API

        [Header("# Master Audio Mixer Group")]
        [SerializeField]
        private AudioMixerGroup masterAudioMixerGroup;
        
        [Header("# Background Audio Mixer Group")]
        [SerializeField]
        private AudioMixerGroup backgroundAudioMixerGroup;
        
        [Header("# Effect Audio Mixer Group")]
        [SerializeField]
        private AudioMixerGroup effectAudioMixerGroup;
        
        [Header("# Voice Audio Mixer Group")]
        [SerializeField]
        private AudioMixerGroup voiceAudioMixerGroup;
        
        [Header("# Playing Background Audio Clip")]
        [SerializeField]
        private AudioClip playingBackgroundAudioClip;

        #endregion
        
        #region COMPONENT FIELD API

        private AudioSource backgroundAudioSource;

        #endregion
        
        #region CONSTANT FIELD API
        
        // Audio clip name if audio clip of background audio source is none
        private const string None = "None";

        // Audio mixer group object name
        private const string AudioMixerGroupsName = "Audio Mixer Groups";

        #endregion

        private Dictionary<string, AudioClip> backgroundAudioClips;
        private Dictionary<string, AudioClip> effectAudioClips;
        private Dictionary<string, AudioClip> voiceAudioClips;

        protected SoundManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }
        
        private void Start()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(SoundManager),
                $"Start()");
            
            backgroundAudioClips = new Dictionary<string, AudioClip>();
            effectAudioClips = new Dictionary<string, AudioClip>();
            voiceAudioClips = new Dictionary<string, AudioClip>();
            
            Initialize();
        }

        private void Initialize()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(SoundManager),
                $"Initialize()");
            
            // Initialize audio source component
            gameObject.AddComponent<AudioListener>();
            backgroundAudioSource = gameObject.AddComponent<AudioSource>();
            backgroundAudioSource.playOnAwake = false;
            backgroundAudioSource.loop = true;
            backgroundAudioSource.outputAudioMixerGroup = backgroundAudioMixerGroup;
        }

        private void PlayBackgroundAudioSource(string key)
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(SoundManager),
                $"PlayBackgroundAudioSource()");

            // If there is no audio clip, set the name as 'None', set it as the name of the audio clip
            var audioClipName = playingBackgroundAudioClip != null
                                    ? playingBackgroundAudioClip.name
                                    : None;
            var audioClip = backgroundAudioClips[key];

            // If the audio clip is playing, do not change it
            if (audioClipName.Equals(audioClip.name)) return;

            playingBackgroundAudioClip = audioClip;
            backgroundAudioSource.PlayOneShot(playingBackgroundAudioClip);

            LogManager.OnDebugLog(
                Label.Success, 
                typeof(SoundManager),
                $"Change background audio clip <b>{audioClipName}</b> to <b>{audioClip.name}</b>");
        }

        #region STATIC METHOD API

        public static void OnChangeBackgroundAudioClip(Util.Manager.Scene.Label label)
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(SoundManager),
                $"OnChangeBackgroundAudioClip()");

            switch (label)
            {
                case Util.Manager.Scene.Label.Main:
                    Instance.PlayBackgroundAudioSource(DataManager.AssetData.backgroundAudioClip.names[0]);
                    break;
                case Util.Manager.Scene.Label.Selection:
                    Instance.PlayBackgroundAudioSource(DataManager.AssetData.backgroundAudioClip.names[0]);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(label), label, null);
            }
        }

        #endregion

        #region STATIC PROPERTIES API

        public static Dictionary<string, AudioClip> BackgroundAudioClip => Instance.backgroundAudioClips;

        public static Dictionary<string, AudioClip> EffectAudioClip => Instance.effectAudioClips;

        public static Dictionary<string, AudioClip> VoiceAudioClip => Instance.voiceAudioClips;

        public static AudioMixer MasterAudioMixer => Instance.masterAudioMixerGroup.audioMixer;
        
        public static AudioMixer BackgroundAudioMixer => Instance.backgroundAudioMixerGroup.audioMixer;
        
        public static AudioMixer EffectAudioMixer => Instance.effectAudioMixerGroup.audioMixer;
        
        public static AudioMixer VoiceAudioMixer => Instance.voiceAudioMixerGroup.audioMixer;

        #endregion
    }
}
