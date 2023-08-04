using UnityEngine;

using Object.Manager;
using Util.Log;

namespace Util.Manager
{
    public static class GameManager
    {
        #region STATIC METHOD API

        public static void OnPause()
        {
            LogManager.LogCalled();

            if (Time.timeScale < 0.5f)
            {
                LogManager.LogError("<b>Game Application</b> has already been paused");

                return;
            }

            UIManager.OnEnablePauseScreen();

            Time.timeScale = 0f;

            LogManager.LogSuccess($"<b>Game Application</b> is paused");
        }

        public static void OnPlay()
        {
            LogManager.LogCalled();

            if (Time.timeScale > 0.5f)
            {
                LogManager.LogError("<b>Game Application</b> is currently running");

                return;
            }

            UIManager.OnDisablePauseScreen();

            Time.timeScale = 1f;

            LogManager.LogSuccess("<b>Game Application</b> is played");
        }

        public static void OnQuit()
        {
            LogManager.LogCalled();

            LogManager.LogSuccess("<b>Game Application</b> is quited");

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        #endregion
    }
}
