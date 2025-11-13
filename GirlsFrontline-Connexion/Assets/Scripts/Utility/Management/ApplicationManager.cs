using GloryDay;
using GloryDay.Debug.Log;
using UnityEngine;

namespace Backend.Utility.Management
{
    public class ApplicationManager : Singleton<ApplicationManager>
    {
        private bool _isPaused;

        private ApplicationManager()
        {
            LogManager.LogProgress();

            _isPaused = false;
        }

        private void Pause_Internal()
        {
            LogManager.LogProgress();

            if (_isPaused)
            {
                LogManager.LogError("<b>Application</b> has already been paused");

                return;
            }

            Time.timeScale = 0f;

            _isPaused = true;

            LogManager.LogSuccess("<b>Application</b> is paused");
        }

        private void Play_Internal()
        {
            LogManager.LogProgress();

            if (_isPaused == false)
            {
                LogManager.LogError("<b>Application</b> is currently running");

                return;
            }

            Time.timeScale = 1f;

            _isPaused = false;

            LogManager.LogSuccess("<b>Application</b> is played");
        }

        private void Quit_Internal()
        {
            LogManager.LogProgress();

            LogManager.LogSuccess("<b>Game Application</b> is quited");

#if UNITY_EDITOR

            UnityEditor.EditorApplication.isPlaying = false;

#else

            UnityEngine.Application.Quit();

#endif
        }

        #region STATIC METHOD API

        /// <summary>
        /// Pause the running application.
        /// </summary>
        public static void Pause()
        {
            Instance.Pause_Internal();
        }

        /// <summary>
        /// Play the quiting application.
        /// </summary>
        public static void Play()
        {
            Instance.Play_Internal();
        }

        /// <summary>
        /// Quits the player application.
        /// </summary>
        public static void Quit()
        {
            Instance.Quit_Internal();
        }

        #endregion

        #region STATIC PROPERTIES API

        public static bool IsPaused => Instance._isPaused;

        #endregion
    }
}
