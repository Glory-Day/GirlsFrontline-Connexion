using System;
using UnityEngine;
using UnityEngine.Audio;
using Utility.Manager;
using Utility.Singleton;

namespace Object.Manager
{
    public class SoundManager : MonoBehavioural<SoundManager>
    {
        #region SERIALIZABLE FIELD API
        
        [Serializable]
        private struct AudioMixerGroups
        {
            public AudioMixerGroup master;
            public AudioMixerGroup background;
            public AudioMixerGroup effect;
            public AudioMixerGroup voice;
        }
        
        [Header("# Audio Mixer Groups")]
        [SerializeField]
        private AudioMixerGroups audioMixerGroups;
        
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

        #endregion
        
        private void Start()
        {
            LogManager.LogProgress();
            
            gameObject.AddComponent<AudioListener>();
            InitializeAudioSources();
        }

        //TODO: This code is not complete yet. You need to add effects and voice audio source code.
        private void InitializeAudioSources()
        {
            LogManager.LogProgress();
            
            // Initialize background audio source component
            backgroundAudioSource = gameObject.AddComponent<AudioSource>();
            backgroundAudioSource.playOnAwake = false;
            backgroundAudioSource.loop = true;
            backgroundAudioSource.outputAudioMixerGroup = audioMixerGroups.background;
            
            // Initialize effect audio source component
            // Initialize voice audio source component
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

        public static void OnChangeBackgroundAudioClip(int sceneIndex)
        {
            LogManager.LogProgress();
            
            Instance.PlayBackgroundAudioSource(DataManager.SceneData[sceneIndex].BackgroundMusic);
        }

        #endregion

        #region STATIC PROPERTIES API
        
        public static AudioMixer BackgroundAudioMixer => Instance.audioMixerGroups.background.audioMixer;
        
        public static AudioMixer EffectAudioMixer => Instance.audioMixerGroups.effect.audioMixer;
        
        public static AudioMixer VoiceAudioMixer => Instance.audioMixerGroups.voice.audioMixer;

        #endregion
    }
}
