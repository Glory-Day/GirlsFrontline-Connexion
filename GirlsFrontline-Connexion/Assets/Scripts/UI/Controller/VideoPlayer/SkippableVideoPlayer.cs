﻿using Controller.VideoPlayer;
using GloryDay.Log;
using UnityEngine.Video;
using Utility.Manager;

namespace UI.Controller.VideoPlayer
{
    public class SkippableVideoPlayer : VideoPlayerBase
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