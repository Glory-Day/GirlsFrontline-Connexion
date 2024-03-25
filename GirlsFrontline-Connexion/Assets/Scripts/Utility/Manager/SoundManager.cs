using System;
using UnityEngine;
using UnityEngine.Audio;
using GloryDay.Log;
using GloryDay.Utility;

namespace Utility.Manager
{
    public class SoundManager : SingletonGameObject<SoundManager>
    {
        #region SERIALIZABLE FIELD API
        
        [Header("# Master Audio Mixer")]
        [SerializeField] 
        private AudioMixer masterAudioMixer;
        
        [Header("# Audio Mixer Controllers")]
        [SerializeField]
        private AudioMixerControllers audioMixerControllers;
        
        [Header("# Playing Background Music")]
        [SerializeField]
        private AudioClip backgroundMusic;

        #endregion
        
        #region COMPONENT API

        private AudioSource _backgroundAudioSource;

        #endregion

        private bool _isBackgroundAudioMute;
        private bool _isEffectAudioMute;
        private bool _isVoiceAudioMute;
        
        // Start is called before the first frame update.
        private void Start()
        {
            LogManager.LogProgress();
            
            gameObject.AddComponent<AudioListener>();
        }

        //TODO: This code is not complete yet. You need to add effects and voice audio source code.
        private void InitializeAudioSources()
        {
            LogManager.LogProgress();
            
            // Initialize background audio source component.
            _backgroundAudioSource = gameObject.AddComponent<AudioSource>();
            _backgroundAudioSource.playOnAwake = false;
            _backgroundAudioSource.loop = true;
            _backgroundAudioSource.outputAudioMixerGroup = audioMixerControllers.background;
            
            // Initialize effect audio source component.
            
            // Initialize voice audio source component.
        }

        private void PlayBackgroundMusic(string backgroundMusicName)
        {
            LogManager.LogProgress();
            
            backgroundMusic = ResourceManager.AudioClipResource.Background[backgroundMusicName];
            _backgroundAudioSource.PlayOneShot(backgroundMusic);

            LogManager.LogMessage($"Play <b>{backgroundMusic.name}</b>");
        }

        private void StopBackgroundMusic()
        {
            LogManager.LogProgress();

            if (_backgroundAudioSource.isPlaying)
            {
                _backgroundAudioSource.Stop();
            }
        }

        private string BackgroundAudioMixerControllerName => audioMixerControllers.background.name;

        private string EffectAudioMixerControllerName => audioMixerControllers.effect.name;

        private string VoiceAudioMixerControllerName => audioMixerControllers.voice.name;

        #region STATIC METHOD API
        
        /// <summary>
        /// Initialize all audio source components.
        /// </summary>
        public static void OnInitializeAudioSources()
        {
            LogManager.LogProgress();
            
            Instance.InitializeAudioSources();
            
            LogManager.LogSuccess("<b>All Audio Sources</b> are initialized");
        }

        /// <summary>
        /// Initialize sound settings stored in user data.
        /// </summary>
        public static void OnInitializeSoundSettings()
        {
            LogManager.LogProgress();
            
            // Set volume values in user data.
            var volume = DataManager.UserData.Option.Volume;
            SetBackgroundAudioVolume(volume.Background);
            SetEffectAudioVolume(volume.Effect);
            SetVoiceAudioVolume(volume.Voice);

            // Set whether to mute in user data.
            var isMute = DataManager.UserData.Option.IsMute;
            IsBackgroundAudioMute = isMute.Background;
            IsEffectAudioMute = isMute.Effect;
            IsVoiceAudioMute = isMute.Voice;
        }
        
        /// <summary>
        /// Play background music with that name.
        /// </summary>
        /// <param name="backgroundMusicName"> Name of background music. </param>
        public static void OnPlayBackgroundMusic(string backgroundMusicName)
        {
            LogManager.LogProgress();
            
            Instance.PlayBackgroundMusic(backgroundMusicName);
        }

        /// <summary>
        /// Stop the background music that is currently playing.
        /// </summary>
        public static void OnStopBackgroundMusic()
        {
            LogManager.LogProgress();
            
            Instance.StopBackgroundMusic();
        }

        /// <summary>
        /// Set the volume value for background sound.
        /// </summary>
        /// <param name="value"> Value of the volume. </param>
        public static void SetBackgroundAudioVolume(float value) =>
            Instance.masterAudioMixer.SetFloat(Instance.BackgroundAudioMixerControllerName, value);
        
        /// <summary>
        /// Set the volume value for effect sound.
        /// </summary>
        /// <param name="value"> Value of the volume. </param>
        public static void SetEffectAudioVolume(float value) =>
            Instance.masterAudioMixer.SetFloat(Instance.EffectAudioMixerControllerName, value);
        
        /// <summary>
        /// Set the volume value for voice sound.
        /// </summary>
        /// <param name="value"> Value of the volume. </param>
        public static void SetVoiceAudioVolume(float value) =>
            Instance.masterAudioMixer.SetFloat(Instance.VoiceAudioMixerControllerName, value);

        /// <summary>
        /// Check is background music is playing.
        /// </summary>
        /// <param name="backgroundMusicName"> Name of background music. </param>
        public static bool IsBackgroundMusicPlaying(string backgroundMusicName) => 
            Instance._backgroundAudioSource.isPlaying && 
            Instance.backgroundMusic != null && 
            Instance.backgroundMusic.name == backgroundMusicName;

        #endregion

        #region STATIC PROPERTIES API

        public static AudioMixer MasterAudioMixer => Instance.masterAudioMixer;

        public static AudioMixerGroup BackgroundAudioMixerGroup => Instance.audioMixerControllers.background;
        
        public static bool IsBackgroundAudioMute
        {
            get => Instance._isBackgroundAudioMute;
            set => Instance._isBackgroundAudioMute = value;
        }
        
        public static bool IsEffectAudioMute
        {
            get => Instance._isEffectAudioMute;
            set => Instance._isEffectAudioMute = value;
        }
        
        public static bool IsVoiceAudioMute
        {
            get => Instance._isVoiceAudioMute;
            set => Instance._isVoiceAudioMute = value;
        }

        #endregion
    }
    
    [Serializable]
    public struct AudioMixerControllers
    {
        public AudioMixerGroup background;
        public AudioMixerGroup effect;
        public AudioMixerGroup voice;
    }
}
