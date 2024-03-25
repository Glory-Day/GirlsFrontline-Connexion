using GloryDay.Log;
using GloryDay.Utility;

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

            Instance._isApplicationPaused = true;
            
            UIManager.OnEnablePauseScreen();

            LogManager.LogSuccess("<b>Application</b> is paused");
        }

        /// <summary>
        /// Run the player application.
        /// </summary>
        public static void OnApplicationPlay()
        {
            LogManager.LogProgress();

            if (Instance._isApplicationPaused == false)
            {
                LogManager.LogError("<b>Application</b> is currently running");

                return;
            }

            Instance._isApplicationPaused = false;
            
            UIManager.OnDisablePauseScreen();

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
    }
}
