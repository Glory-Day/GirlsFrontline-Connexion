using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Utility.Manager;

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
            LogManager.LogProgress();
            
            backgroundAudioClips = new Dictionary<string, AudioClip>();
            effectAudioClips = new Dictionary<string, AudioClip>();
            voiceAudioClips = new Dictionary<string, AudioClip>();
            
            Initialize();
        }

        private void Initialize()
        {
            LogManager.LogProgress();
            
            // Initialize audio source component
            gameObject.AddComponent<AudioListener>();
            backgroundAudioSource = gameObject.AddComponent<AudioSource>();
            backgroundAudioSource.playOnAwake = false;
            backgroundAudioSource.loop = true;
            backgroundAudioSource.outputAudioMixerGroup = backgroundAudioMixerGroup;
        }

        private void PlayBackgroundAudioSource(string key)
        {
            LogManager.LogProgress();

            // If there is no audio clip, set the name as 'None', set it as the name of the audio clip
            var audioClipName = playingBackgroundAudioClip != null
                                    ? playingBackgroundAudioClip.name
                                    : None;
            var audioClip = AssetManager.AudioClipAssets.Background[key];

            // If the audio clip is playing, do not change it
            if (audioClipName.Equals(audioClip.name)) return;

            playingBackgroundAudioClip = audioClip;
            backgroundAudioSource.PlayOneShot(playingBackgroundAudioClip);

            LogManager.LogSuccess($"Change background audio clip <b>{audioClipName}</b> to <b>{audioClip.name}</b>");
        }

        #region STATIC METHOD API

        public static void OnChangeBackgroundAudioClip(Utility.Manager.Scene.Label label)
        {
            LogManager.LogProgress();

            switch (label)
            {
                case Utility.Manager.Scene.Label.Main:
                    Instance.PlayBackgroundAudioSource(DataManager.AudioSourceData.Background.Main);
                    break;
                case Utility.Manager.Scene.Label.Selection:
                    Instance.PlayBackgroundAudioSource(DataManager.AudioSourceData.Background.Main);
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
