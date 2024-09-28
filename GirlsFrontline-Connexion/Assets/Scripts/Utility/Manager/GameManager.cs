using GloryDay.Log;
using GloryDay.Utility;
using UnityEngine;

namespace Utility.Manager
{
    public class GameManager : Singleton<GameManager>
    {
        private bool _isApplicationPaused;

        private GameManager()
        {
            LogManager.LogProgress();
            
            _isApplicationPaused = false;
        }
        
        #region STATIC METHOD API
        
        /// <summary>
        /// Pause the running application.
        /// </summary>
        public static void OnApplicationPause()
        {
            LogManager.LogProgress();

            if (Instance._isApplicationPaused)
            {
                LogManager.LogError("<b>Application</b> has already been paused");

                return;
            }

            Time.timeScale = 0f;
            
            Instance._isApplicationPaused = true;

            LogManager.LogSuccess("<b>Application</b> is paused");
        }

        /// <summary>
        /// Play the quiting application.
        /// </summary>
        public static void OnApplicationPlay()
        {
            LogManager.LogProgress();

            if (Instance._isApplicationPaused == false)
            {
                LogManager.LogError("<b>Application</b> is currently running");

                return;
            }

            Time.timeScale = 1f;
            
            Instance._isApplicationPaused = false;

            LogManager.LogSuccess("<b>Application</b> is played");
        }

        /// <summary>
        /// Quits the player application.
        /// </summary>
        public static void OnApplicationQuit()
        {
            LogManager.LogProgress();

            LogManager.LogSuccess("<b>Game Application</b> is quited");

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
