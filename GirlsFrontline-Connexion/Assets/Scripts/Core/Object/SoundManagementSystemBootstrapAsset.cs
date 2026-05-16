using System.Collections;
using Core.Utility.Management;
using GloryDay.Debug;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Audio;

namespace Core.Object
{
    [CreateAssetMenu(fileName = "Sound Management System Bootstrap Asset", menuName = "Scriptable Object/Bootstrap Asset/Sound Management System Bootstrap Asset")]
    public class SoundManagementSystemBootstrapAsset : BootstrapAsset
    {
        #region SERIALIZABLE FIELD API

        [field: Title("Audio")]
        [field: SerializeField] private AudioMixer MasterAudioMixer { get; set; }
        [field: SerializeField] private AudioMixerGroup BackgroundAudioMixer { get; set; }
        [field: SerializeField] private AudioMixerGroup EffectAudioMixer { get; set; }
        [field: SerializeField] private AudioMixerGroup VoiceAudioMixer { get; set; }

        #endregion

        protected override IEnumerator Booting_Internal()
        {
            Console.LogMessage("Sound management system is booting...");

            // Set audio mixers.
            SoundManager.MasterAudioMixer = MasterAudioMixer;
            SoundManager.BackgroundAudioMixer = BackgroundAudioMixer;
            SoundManager.EffectAudioMixer = EffectAudioMixer;
            SoundManager.VoiceAudioMixer = VoiceAudioMixer;

            // Create audio channel object to sound management object.
            var backgroundAudioChannelObject = SoundManager.CreateChannelObject("Background Audio Channel");
            var effectAudioChannelObject = SoundManager.CreateChannelObject("Effect Audio Channel");
            var voiceAudioChannelObject = SoundManager.CreateChannelObject("Voice Audio Channel");

            // Set audio sources.
            SoundManager.BackgroundAudioSource = SoundManager.AddAudioSourceComponent(backgroundAudioChannelObject, BackgroundAudioMixer);
            SoundManager.EffectAudioSource = SoundManager.AddAudioSourceComponent(effectAudioChannelObject, EffectAudioMixer);
            SoundManager.VoiceAudioSource = SoundManager.AddAudioSourceComponent(voiceAudioChannelObject, VoiceAudioMixer);

            // Set volume values and whether to mute in user data.
            var data = DataManager.UserData.Sound;
            SoundManager.BackgroundAudioVolume = data[0].Volume;
            SoundManager.EffectAudioVolume = data[1].Volume;
            SoundManager.VoiceAudioVolume = data[2].Volume;
            SoundManager.IsBackgroundAudioMute = data[0].IsMute;
            SoundManager.IsEffectAudioMute = data[1].IsMute;
            SoundManager.IsVoiceAudioMute = data[2].IsMute;

            Console.LogSuccess("Booting sound management system is completed");

            yield return null;
        }
    }
}
