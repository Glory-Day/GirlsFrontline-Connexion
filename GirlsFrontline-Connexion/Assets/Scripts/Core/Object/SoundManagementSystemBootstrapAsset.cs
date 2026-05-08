using System.Collections;
using Core.Utility.Management;
using GloryDay.Debug;
using UnityEngine;

namespace Core.Object
{
    [CreateAssetMenu(fileName = "Sound Management System Bootstrap Asset", menuName = "Scriptable Object/Bootstrap Asset/Sound Management System Bootstrap Asset")]
    public class SoundManagementSystemBootstrapAsset : BootstrapAsset
    {
        protected override IEnumerator Booting_Internal()
        {
            Console.LogMessage("Sound management system is booting...");

            // Set volume values and whether to mute in user data.
            var sound = DataManager.UserData.Sound;
            SoundManager.SetBackgroundAudioVolume(sound[0].Volume);
            SoundManager.SetEffectAudioVolume(sound[1].Volume);
            SoundManager.SetVoiceAudioVolume(sound[2].Volume);
            SoundManager.IsBackgroundAudioMute = sound[0].IsMute;
            SoundManager.IsEffectAudioMute = sound[1].IsMute;
            SoundManager.IsVoiceAudioMute = sound[2].IsMute;

            Console.LogSuccess("Booting sound management system is completed");

            yield return null;
        }
    }
}
