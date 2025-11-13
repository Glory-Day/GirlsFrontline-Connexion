using Controller.VideoPlayer;
using GloryDay.Debug.Log;
using UnityEngine.Video;
using Backend.Utility.Management;

namespace Backend.Object.UI.Controller.VideoPlayer
{
    public class IntroductionVideoPlayer : VideoPlayerBase
    {
        // Awake is called when the script instance is being loaded
        protected override void Awake()
        {
            LogManager.LogProgress();

            base.Awake();

            VideoAudioOutputMode = VideoAudioOutputMode.AudioSource;
            OutputAudioMixerGroup = SoundManager.BackgroundAudioMixerGroup;
        }
    }
}
