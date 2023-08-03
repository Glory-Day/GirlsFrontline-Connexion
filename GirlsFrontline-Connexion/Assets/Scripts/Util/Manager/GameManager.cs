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
            LogManager.OnDebugLog(
                Label.Called,
                typeof(GameManager),
                $"OnPause()");

            if (Time.timeScale < 0.5f)
            {
                LogManager.OnDebugLog(
                    Label.Error, 
                    typeof(GameManager),
                    $"<b>Game Application</b> has already been paused");

                return;
            }

            UIManager.OnEnablePauseScreen();

            Time.timeScale = 0f;

            LogManager.OnDebugLog(
                Label.Success, 
                typeof(GameManager),
                $"<b>Game Application</b> is paused");
        }

        public static void OnPlay()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(GameManager),
                $"OnPlay()");

            if (Time.timeScale > 0.5f)
            {
                LogManager.OnDebugLog(
                    Label.Error, 
                    typeof(GameManager),
                    $"<b>Game Application</b> is currently running");

                return;
            }

            UIManager.OnDisablePauseScreen();

            Time.timeScale = 1f;

            LogManager.OnDebugLog(
                Label.Success, 
                typeof(GameManager),
                $"<b>Game Application</b> is played");
        }

        public static void OnQuit()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(GameManager),
                $"OnQuit()");

            LogManager.OnDebugLog(
                Label.Success, 
                typeof(GameManager),
                $"<b>Game Application</b> is quited");

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        #endregion
    }
}
