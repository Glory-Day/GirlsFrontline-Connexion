#region NAMESPACE API

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Util.Manager;
using Util.Manager.Log;

#endregion

namespace Object.Manager
{
    public class SoundManager : Singleton<SoundManager>
    {
        #region SERIALIZABLE FIELD API

        [Header("# Playing Background Audio Clip")]
        [SerializeField]
        public AudioClip playingBackgroundAudioClip;

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

        private AudioMixerGroup masterAudioGroup;
        private AudioMixerGroup backgroundAudioGroup;
        private AudioMixerGroup effectAudioGroup;
        private AudioMixerGroup voiceAudioGroup;

        private Dictionary<string, AudioClip> backgroundAudioClips;
        private Dictionary<string, AudioClip> effectAudioClips;
        private Dictionary<string, AudioClip> voiceAudioClips;

        protected SoundManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
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

        public static void OnInitialize()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(SoundManager),
                $"OnInitialize()");
            
            // Initialize audio mixer groups
            var audioMixerGroups = GameObject.Find(AudioMixerGroupsName).GetComponent<AudioMixerGroups>();
            Instance.masterAudioGroup = audioMixerGroups.Master;
            Instance.backgroundAudioGroup = audioMixerGroups.Background;
            Instance.effectAudioGroup = audioMixerGroups.Effect;
            Instance.voiceAudioGroup = audioMixerGroups.Voice;
            
            // Initialize audio source component
            Instance.gameObject.AddComponent<AudioListener>();
            Instance.backgroundAudioSource = Instance.gameObject.AddComponent<AudioSource>();
            Instance.backgroundAudioSource.playOnAwake = false;
            Instance.backgroundAudioSource.loop = true;
            Instance.backgroundAudioSource.outputAudioMixerGroup = Instance.backgroundAudioGroup;
            
            // Initialize audio clips
            Instance.backgroundAudioClips = new Dictionary<string, AudioClip>();
            Instance.effectAudioClips = new Dictionary<string, AudioClip>();
            Instance.voiceAudioClips = new Dictionary<string, AudioClip>();
        }

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

        public static AudioMixer MasterAudioMixer => 
            Instance != null ? Instance.masterAudioGroup.audioMixer : null;

        public static AudioMixer BackgroundAudioMixer => 
            Instance != null ? Instance.backgroundAudioGroup.audioMixer : null;

        public static AudioMixer EffectAudioMixer => 
            Instance != null ? Instance.effectAudioGroup.audioMixer : null;

        public static AudioMixer VoiceAudioMixer => 
            Instance != null ? Instance.voiceAudioGroup.audioMixer : null;

        #endregion
    }
}
