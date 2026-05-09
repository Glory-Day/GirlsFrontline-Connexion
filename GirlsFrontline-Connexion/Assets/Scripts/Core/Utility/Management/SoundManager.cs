using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Audio;
using GloryDay.Debug;
using GloryDay.Utility;
using Core.Utility.Attribute;

namespace Core.Utility.Management
{
    public class SoundManager : SingletonGameObject<SoundManager>
    {
        #region SERIALIZABLE FIELD API

        [field: Title("Audio")]
        [field: Alias("Master Audio Mixer")]
        [field: SerializeField]
        private AudioMixer MasterAudioMixer_Internal { get; set; }

        [field: Alias("Background Audio Mixer")]
        [field: SerializeField]
        private AudioMixerGroup BackgroundAudioMixer_Internal { get; set; }

        [field: Alias("Effect Audio Mixer")]
        [field: SerializeField]
        private AudioMixerGroup EffectAudioMixer_Internal { get; set; }

        [field: Alias("Voice Audio Mixer")]
        [field: SerializeField]
        private AudioMixerGroup VoiceAudioMixer_Internal { get; set; }

        #endregion

        private AudioSource _backgroundAudioSource;
        private AudioSource _effectAudioSource;
        private AudioSource _voiceAudioSource;

        protected override void Awake()
        {
            Console.LogProgress();

            base.Awake();

            // Initialize background, voice audio sources.
            _backgroundAudioSource = transform.GetChild(0).GetComponent<AudioSource>();
            _effectAudioSource = transform.GetChild(1).GetComponent<AudioSource>();
            _voiceAudioSource = transform.GetChild(2).GetComponent<AudioSource>();

            Console.LogSuccess("<b>All Audio Sources</b> are initialized");
        }

        private void PlayBackgroundAudioSource_Internal(AudioClip clip)
        {
            Console.LogProgress();

            _backgroundAudioSource.clip = clip;
            _backgroundAudioSource.Play();

            Console.LogMessage($"Play <b>{clip.name}</b>");
        }

        private void StopBackgroundAudioSource_Internal()
        {
            Console.LogProgress();

            if (_backgroundAudioSource.isPlaying)
            {
                _backgroundAudioSource.Stop();
            }
        }

        private void PlayEffectAudioSource_Internal(AudioClip clip)
        {
            Console.LogProgress();

            if (clip == null)
            {
                return;
            }

            _effectAudioSource.PlayOneShot(clip);
        }

        private void PlayVoiceAudioSource_Internal(AudioClip clip)
        {
            Console.LogProgress();

            _voiceAudioSource.clip = clip;
            _voiceAudioSource.Play();

            Console.LogMessage($"Play <b>{clip.name}</b>");
        }

        public bool IsBackgroundAudioSourcePlaying_Internal(string backgroundMusicName)
        {
            var source = _backgroundAudioSource;

            return source != null && source.isPlaying && source.clip.name == backgroundMusicName;
        }

        private float BackgroundAudioVolume_Internal
        {
            set => MasterAudioMixer_Internal.SetFloat(BackgroundAudioMixer_Internal.name, value);
        }

        private float EffectAudioVolume_Internal
        {
            set => MasterAudioMixer_Internal.SetFloat(EffectAudioMixer_Internal.name, value);
        }

        private float VoiceAudioVolume_Internal
        {
            set => MasterAudioMixer_Internal.SetFloat(VoiceAudioMixer_Internal.name, value);
        }

        #region STATIC METHOD API

        /// <summary>
        /// Play background music with that name.
        /// </summary>
        /// <param name="clip"> Name of background music. </param>
        public static void PlayBackgroundAudioSource(AudioClip clip)
        {
            Console.LogProgress();

            Instance.PlayBackgroundAudioSource_Internal(clip);
        }

        /// <summary>
        /// Stop the background music that is currently playing.
        /// </summary>
        public static void StopBackgroundMusic()
        {
            Console.LogProgress();

            Instance.StopBackgroundAudioSource_Internal();
        }

        public static void PlayEffectAudioSource(AudioClip clip)
        {
            Console.LogProgress();

            Instance.PlayEffectAudioSource_Internal(clip);
        }

        public static void PlayVoiceAudioSource(AudioClip clip)
        {
            Console.LogProgress();

            Instance.PlayVoiceAudioSource_Internal(clip);
        }

        /// <summary>
        /// Check is background music is playing.
        /// </summary>
        /// <param name="backgroundAudioSourceName"> Name of background music. </param>
        public static bool IsBackgroundAudioSourcePlaying(string backgroundAudioSourceName)
        {
            return Instance.IsBackgroundAudioSourcePlaying_Internal(backgroundAudioSourceName);
        }

        #endregion

        #region STATIC PROPERTIES API

        public static AudioMixer MasterAudioMixer => Instance.MasterAudioMixer_Internal;

        public static AudioMixerGroup BackgroundAudioMixer => Instance.BackgroundAudioMixer_Internal;

        public static AudioMixerGroup EffectAudioMixer => Instance.EffectAudioMixer_Internal;

        public static AudioMixerGroup VoiceAudioMixer => Instance.VoiceAudioMixer_Internal;

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

        /// <param name="value"> Volume value for background sound. </param>
        public static float BackgroundAudioVolume
        {
            set => Instance.BackgroundAudioVolume_Internal = value;
        }

        /// <param name="value"> Volume value for effect sound. </param>
        public static float EffectAudioVolume
        {
            set => Instance.EffectAudioVolume_Internal = value;
        }

        /// <param name="value"> Volume value for voice sound. </param>
        public static float VoiceAudioVolume
        {
            set => Instance.VoiceAudioVolume_Internal = value;
        }

        #endregion
    }
}
