using System;
using System.Collections;
using System.Collections.Generic;
using Core.UI.Controller.VideoPlayer;
using UnityEngine;
using Sirenix.OdinInspector;

using Console = GloryDay.Debug.Console;

namespace Core.Object
{
    public class BootingSystem : MonoBehaviour
    {
        [Title("UI - Video Player")]
        [SerializeField] private IntroductionVideoPlayer videoPlayer;

        [Title("Booting System")]
        [SerializeField] private List<BootstrapAsset> assets;

        private void Awake()
        {
            Console.LogProgress();

            videoPlayer.Initialize();

            StartCoroutine(Booting());
        }

        private void OnEnable()
        {
            OnBootingStarted += HandleBootingStarted;
            OnBootingCompleted += HandleBootingCompleted;
        }

        private void OnDisable()
        {
            OnBootingStarted -= HandleBootingStarted;
            OnBootingCompleted -= HandleBootingCompleted;
        }

        private void OnDestroy()
        {
            Console.LogProgress();

            OnBootingStarted = null;
            OnBootingCompleted = null;
        }

        /// <summary>
        /// Booting all assets, data, and objects for running application.
        /// </summary>
        private IEnumerator Booting()
        {
            Console.LogProgress();

            OnBootingStarted?.Invoke();

            var count = assets.Count;
            for (var i = 0; i < 2; i++)
            {
                yield return StartCoroutine(assets[i].Booting());
            }

            OnBootingCompleted?.Invoke();

            Console.LogSuccess("<b>Booting All Management System</b> is completed");
        }

        private void HandleBootingStarted()
        {
            // Set the video to loop.
            videoPlayer.IsVideoLoop = true;

            videoPlayer.Prepare();
        }

        private void HandleBootingCompleted()
        {
            // Unset the loop of the video and set the event called at the end of the video.
            videoPlayer.RegisterLoopPointEventHandler();
            videoPlayer.IsVideoLoop = false;

            // Activate the skip button.
            videoPlayer.EnableSkipVideoButton();
        }

        public event Action OnBootingStarted;

        public event Action OnBootingCompleted;
    }
}
