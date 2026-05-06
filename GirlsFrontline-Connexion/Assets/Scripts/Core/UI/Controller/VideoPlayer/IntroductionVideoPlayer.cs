using Core.UI.Controller.Button;
using UnityEngine;
using UnityEngine.Video;
using Core.Utility.Manager;

using Console = GloryDay.Debug.Console;

namespace Core.UI.Controller.VideoPlayer
{
    public class IntroductionVideoPlayer : VideoPlayerBase
    {
        #region SERIALIZABLE FIELD API

        [SerializeField]
        private SkipVideoButton skipVideoButton;

        #endregion

        // Awake is called when the script instance is being loaded
        protected override void Awake()
        {
            Console.LogProgress();

            base.Awake();

            VideoAudioOutputMode = VideoAudioOutputMode.AudioSource;
            OutputAudioMixerGroup = SoundManager.BackgroundAudioMixerGroup;

            DisableSkipVideoButton();
        }

        private void Start()
        {
            Console.LogProgress();

            // Set the video to loop.
            IsVideoLoop = true;
        }

        private void EnableSkipVideoButton()
        {
            Console.LogProgress();

            skipVideoButton.gameObject.SetActive(true);
        }

        private void DisableSkipVideoButton()
        {
            Console.LogProgress();

            skipVideoButton.gameObject.SetActive(false);
        }
    }
}
