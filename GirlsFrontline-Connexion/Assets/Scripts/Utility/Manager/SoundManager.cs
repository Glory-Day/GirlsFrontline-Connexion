using UnityEngine;
using UnityEngine.Audio;
using GloryDay;
using GloryDay.Debug.Log;
using Utility.Extension;

namespace Utility.Manager
{
    public class SoundManager : SingletonGameObject<SoundManager>
    {
        #region SERIALIZABLE FIELD API
        
        [Label("Master")]
        [SerializeField] private AudioMixer masterAudioMixer;
        [Label("Background")]
        [SerializeField] private AudioMixerGroup backgroundAudioMixerGroup;
        [Label("Effect")]
        [SerializeField] private AudioMixerGroup effectAudioMixerGroup;
        [Label("Voice")]
        [SerializeField] private AudioMixerGroup voiceAudioMixerGroup;

        #endregion
        
        #region COMPONENT FIELD API

        private AudioSource _backgroundAudioSource;
        private AudioSource _effectAudioSource;
        private AudioSource _voiceAudioSource;

        #endregion

        protected override void OnAwake()
        {
            LogManager.LogProgress();
            
            base.OnAwake();
            
            // Initialize background, voice audio sources.
            _backgroundAudioSource = transform.GetChild(0).GetComponent<AudioSource>();
            _effectAudioSource = transform.GetChild(1).GetComponent<AudioSource>();
            _voiceAudioSource = transform.GetChild(2).GetComponent<AudioSource>();
            
            LogManager.LogSuccess("<b>All Audio Sources</b> are initialized");
        }

        private void PlayBackgroundAudioSource(AudioClip clip)
        {
            LogManager.LogProgress();
            
            _backgroundAudioSource.clip = clip;
            _backgroundAudioSource.Play();

            LogManager.LogMessage($"Play <b>{clip.name}</b>");
        }

        private void StopBackgroundAudioSource()
        {
            LogManager.LogProgress();

            if (_backgroundAudioSource.isPlaying)
            {
                _backgroundAudioSource.Stop();
            }
        }

        private void PlayEffectAudioSource(AudioClip clip)
        {
            LogManager.LogProgress();

            if (clip is null)
            {
                return;
            }
            
            _effectAudioSource.PlayOneShot(clip);
        }
        
        private void PlayVoiceAudioSource(AudioClip clip)
        {
            LogManager.LogProgress();
            
            _voiceAudioSource.clip = clip;
            _voiceAudioSource.Play();

            LogManager.LogMessage($"Play <b>{clip.name}</b>");
        }

        private string BackgroundAudioMixerControllerName => backgroundAudioMixerGroup.name;

        private string EffectAudioMixerControllerName => effectAudioMixerGroup.name;

        private string VoiceAudioMixerControllerName => voiceAudioMixerGroup.name;

        #region STATIC METHOD API
        
        /// <summary>
        /// Play background music with that name.
        /// </summary>
        /// <param name="clip"> Name of background music. </param>
        public static void OnPlayBackgroundAudioSource(AudioClip clip)
        {
            LogManager.LogProgress();
            
            Instance.PlayBackgroundAudioSource(clip);
        }

        /// <summary>
        /// Stop the background music that is currently playing.
        /// </summary>
        public static void OnStopBackgroundMusic()
        {
            LogManager.LogProgress();
            
            Instance.StopBackgroundAudioSource();
        }

        public static void OnPlayEffectAudioSource(AudioClip clip)
        {
            LogManager.LogProgress();
            
            Instance.PlayEffectAudioSource(clip);
        }
        
        public static void OnPlayVoiceAudioSource(AudioClip clip)
        {
            LogManager.LogProgress();
            
            Instance.PlayVoiceAudioSource(clip);
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
        public static bool IsBackgroundAudioSourcePlaying(string backgroundMusicName)
        {
            var source = Instance._backgroundAudioSource;
            
            return source is null == false && source.isPlaying && source.clip.name == backgroundMusicName;
        }
        
        #endregion

        #region STATIC PROPERTIES API

        public static AudioMixer MasterAudioMixer => Instance.masterAudioMixer;

        public static AudioMixerGroup BackgroundAudioMixerGroup => Instance.backgroundAudioMixerGroup;

        public static AudioMixerGroup EffectAudioMixerGroup => Instance.effectAudioMixerGroup;

        public static AudioMixerGroup VoiceAudioMixerGroup => Instance.voiceAudioMixerGroup;

        public static AudioSource BackgroundAudioSource => Instance._backgroundAudioSource;
        
        public static bool IsBackgroundAudioMute
        {
            get => Instance._backgroundAudioSource.mute; 
            set => Instance._backgroundAudioSource.mute = value;
        }

        public static bool IsEffectAudioMute
        {
            get => Instance._effectAudioSource.mute; 
            set => Instance._effectAudioSource.mute = value;
        }

        public static bool IsVoiceAudioMute
        {
            get => Instance._voiceAudioSource.mute; 
            set => Instance._voiceAudioSource.mute = value;
        }

        #endregion
    }
}
