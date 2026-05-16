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
        private GameObject CreateChannelObject_Internal(string channelName)
        {
            var child = new GameObject(channelName);
            child.transform.SetParent(transform);

            return child;
        }

        private AudioSource AddAudioSourceComponent_Internal(GameObject channelObject, AudioMixerGroup audioMixerGroup)
        {
            var audioSource = channelObject.AddComponent<AudioSource>();
            audioSource.outputAudioMixerGroup = audioMixerGroup;

            return audioSource;
        }

        private void PlayBackgroundAudioSource_Internal(AudioClip clip)
        {
            Console.LogProgress();

            BackgroundAudioSource_Internal.clip = clip;
            BackgroundAudioSource_Internal.Play();

            Console.LogMessage($"Play <b>{clip.name}</b>");
        }

        private void StopBackgroundAudioSource_Internal()
        {
            Console.LogProgress();

            if (BackgroundAudioSource_Internal.isPlaying)
            {
                BackgroundAudioSource_Internal.Stop();
            }
        }

        private void PlayEffectAudioSource_Internal(AudioClip clip)
        {
            Console.LogProgress();

            if (clip == null)
            {
                return;
            }

            EffectAudioSource_Internal.PlayOneShot(clip);
        }

        private void PlayVoiceAudioSource_Internal(AudioClip clip)
        {
            Console.LogProgress();

            VoiceAudioSource_Internal.clip = clip;
            VoiceAudioSource_Internal.Play();

            Console.LogMessage($"Play <b>{clip.name}</b>");
        }

        private void PlayUIAudioSource_Internal(AudioClip clip)
        {
            PlayEffectAudioSource_Internal(clip);
        }

        public bool IsBackgroundAudioSourcePlaying_Internal(string backgroundMusicName)
        {
            var source = BackgroundAudioSource_Internal;

            return source != null && source.isPlaying && source.clip.name == backgroundMusicName;
        }

        private AudioMixer MasterAudioMixer_Internal { get; set; }

        private AudioMixerGroup BackgroundAudioMixer_Internal { get; set; }

        private AudioMixerGroup EffectAudioMixer_Internal { get; set; }

        private AudioMixerGroup VoiceAudioMixer_Internal { get; set; }

        private AudioSource BackgroundAudioSource_Internal { get; set; }

        private AudioSource EffectAudioSource_Internal { get; set; }

        private AudioSource VoiceAudioSource_Internal { get; set; }

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

        public static GameObject CreateChannelObject(string channelName)
        {
            return Instance.CreateChannelObject_Internal(channelName);
        }

        public static AudioSource AddAudioSourceComponent(GameObject channelObject, AudioMixerGroup audioMixerGroup)
        {
            return Instance.AddAudioSourceComponent_Internal(channelObject, audioMixerGroup);
        }

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

        public static void PlayUIAudioSource(AudioClip clip)
        {
            Console.LogProgress();

            Instance.PlayUIAudioSource_Internal(clip);
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

        public static AudioMixer MasterAudioMixer
        {
            get => Instance.MasterAudioMixer_Internal;
            set => Instance.MasterAudioMixer_Internal = value;
        }

        public static AudioMixerGroup BackgroundAudioMixer
        {
            get => Instance.BackgroundAudioMixer_Internal;
            set => Instance.BackgroundAudioMixer_Internal = value;
        }

        public static AudioMixerGroup EffectAudioMixer
        {
            get => Instance.EffectAudioMixer_Internal;
            set => Instance.EffectAudioMixer_Internal = value;
        }

        public static AudioMixerGroup VoiceAudioMixer
        {
            get => Instance.VoiceAudioMixer_Internal;
            set => Instance.VoiceAudioMixer_Internal = value;
        }

        public static AudioSource BackgroundAudioSource
        {
            get => Instance.BackgroundAudioSource_Internal;
            set => Instance.BackgroundAudioSource_Internal = value;
        }

        public static AudioSource EffectAudioSource
        {
            get => Instance.EffectAudioSource_Internal;
            set => Instance.EffectAudioSource_Internal = value;
        }

        public static AudioSource VoiceAudioSource
        {
            get => Instance.VoiceAudioSource_Internal;
            set => Instance.VoiceAudioSource_Internal = value;
        }

        public static bool IsBackgroundAudioMute
        {
            get => Instance.BackgroundAudioSource_Internal.mute;
            set => Instance.BackgroundAudioSource_Internal.mute = value;
        }

        public static bool IsEffectAudioMute
        {
            get => Instance.EffectAudioSource_Internal.mute;
            set => Instance.EffectAudioSource_Internal.mute = value;
        }

        public static bool IsVoiceAudioMute
        {
            get => Instance.VoiceAudioSource_Internal.mute;
            set => Instance.VoiceAudioSource_Internal.mute = value;
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
