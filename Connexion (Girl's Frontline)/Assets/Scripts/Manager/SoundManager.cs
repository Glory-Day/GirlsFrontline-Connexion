#region NAMESPACE API

using System;
using System.Collections.Generic;
using UnityEngine;
using Object;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Manager
{
    public class SoundManager : Singleton<SoundManager>
    {
        #region SERIALIZABLE FIELD

        [Header("# Playing Background Audio Clip")]
        [SerializeField]
        public AudioClip playingBackgroundAudioClip;

        #endregion

        private AudioSource      backgroundAudioSource;
        private AudioMixerGroups audioMixerGroups;

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
        public static void OnInitialize(AudioMixerGroups audioMixerGroups)
        {
            LogManager.OnDebugLog(
                typeof(SoundManager),
                $"OnInitialize()");

            Instance.audioMixerGroups = audioMixerGroups;
            
            Instance.gameObject.AddComponent<AudioListener>();
            Instance.backgroundAudioSource = Instance.gameObject.AddComponent<AudioSource>();
            Instance.backgroundAudioSource.playOnAwake = false;
            Instance.backgroundAudioSource.loop = true;
            Instance.backgroundAudioSource.outputAudioMixerGroup = Instance.audioMixerGroups.Background;
            
            Instance.backgroundAudioClips = new Dictionary<string, AudioClip>();
            Instance.effectAudioClips = new Dictionary<string, AudioClip>();
            Instance.voiceAudioClips = new Dictionary<string, AudioClip>();
        }

        private void PlayBackgroundAudioSource(string key)
        {
            LogManager.OnDebugLog(
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
                LabelType.Success, 
                typeof(SoundManager),
                $"Change background audio clip <b>{audioClipName}</b> to <b>{audioClip.name}</b> successfully");
        }

        #region SOUND API

        public static void OnChangeBackgroundAudioClip(SceneManager.SceneName name)
        {
            LogManager.OnDebugLog(
                typeof(SoundManager),
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

        public static Dictionary<string, AudioClip> BackgroundAudioClip => Instance.backgroundAudioClips;

        public static Dictionary<string, AudioClip> EffectAudioClip => Instance.effectAudioClips;

        public static Dictionary<string, AudioClip> VoiceAudioClip => Instance.voiceAudioClips;

        #endregion
    }
}
