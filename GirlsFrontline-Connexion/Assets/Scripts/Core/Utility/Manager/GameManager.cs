using GloryDay.Debug;
using GloryDay.Utility;
using UnityEngine;

namespace Core.Utility.Manager
{
    public class GameManager : Singleton<GameManager>
    {
        private bool _isApplicationPaused;

        private GameManager()
        {
            Console.LogProgress();

            _isApplicationPaused = false;
        }

        #region STATIC METHOD API

        /// <summary>
        /// Pause the running application.
        /// </summary>
        public static void OnApplicationPause()
        {
            Console.LogProgress();

            if (Instance._isApplicationPaused)
            {
                Console.LogError("<b>Application</b> has already been paused");

                return;
            }

            Time.timeScale = 0f;

            Instance._isApplicationPaused = true;

            Console.LogSuccess("<b>Application</b> is paused");
        }

        /// <summary>
        /// Play the quiting application.
        /// </summary>
        public static void OnApplicationPlay()
        {
            Console.LogProgress();

            if (Instance._isApplicationPaused == false)
            {
                Console.LogError("<b>Application</b> is currently running");

                return;
            }

            Time.timeScale = 1f;

            Instance._isApplicationPaused = false;

            Console.LogSuccess("<b>Application</b> is played");
        }

        /// <summary>
        /// Quits the player application.
        /// </summary>
        public static void OnApplicationQuit()
        {
            Console.LogProgress();

            Console.LogSuccess("<b>Game Application</b> is quited");

#if UNITY_EDITOR

            UnityEditor.EditorApplication.isPlaying = false;

#else

            UnityEngine.Application.Quit();

#endif
        }

        #endregion

        #region STATIC PROPERTIES API

        public static bool IsApplicationPaused => Instance._isApplicationPaused;

        #endregion
    }
}
