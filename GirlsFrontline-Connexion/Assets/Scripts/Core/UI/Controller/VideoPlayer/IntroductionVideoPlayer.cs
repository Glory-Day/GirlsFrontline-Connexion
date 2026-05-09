using Core.UI.Controller.Button;
using Sirenix.OdinInspector;
using UnityEngine;

using Console = GloryDay.Debug.Console;

namespace Core.UI.Controller.VideoPlayer
{
    public class IntroductionVideoPlayer : VideoPlayerBase
    {
        #region SERIALIZABLE FIELD API

        [Title("UI - Button")]
        [SerializeField] private SkipVideoButton skipVideoButton;

        #endregion

        public override void Initialize()
        {
            Console.LogProgress();

            base.Initialize();

            skipVideoButton.Initialize();
            DisableSkipVideoButton();

            // Set the video to loop.
            IsVideoLoop = true;

            OnPreparingCompleted += Play;

            Pause();
        }

        public void EnableSkipVideoButton()
        {
            Console.LogProgress();

            skipVideoButton.gameObject.SetActive(true);
        }

        public void DisableSkipVideoButton()
        {
            Console.LogProgress();

            skipVideoButton.gameObject.SetActive(false);
        }

        public void RegisterLoopPointEventHandler()
        {
            Console.LogProgress();

            OnLoopPointReached += delegate
            {
                skipVideoButton.OnClick.Invoke();
            };
        }
    }
}
