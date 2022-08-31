#region NAMESPACE API

using UnityEngine;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Manager
{
    public class GameManager : Singleton<GameManager>
    {
        protected GameManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        public static void OnPause()
        {
            LogManager.OnDebugLog(typeof(GameManager),
                $"OnPause()");

            if (Time.timeScale < 0.5f)
            {
                LogManager.OnDebugLog(
                    LabelType.Error, 
                    typeof(GameManager),
                    $"<b>Game Application</b> has already been paused");

                return;
            }

            UIManager.OnEnablePauseScreen();

            Time.timeScale = 0f;

            LogManager.OnDebugLog(
                LabelType.Success, 
                typeof(GameManager),
                $"<b>Game Application</b> pauses successfully");
        }

        public static void OnPlay()
        {
            LogManager.OnDebugLog(typeof(GameManager),
                $"OnPlay()");

            if (Time.timeScale > 0.5f)
            {
                LogManager.OnDebugLog(
                    LabelType.Error, 
                    typeof(GameManager),
                    $"<b>Game Application</b> is currently running");

                return;
            }

            UIManager.OnDisablePauseScreen();

            Time.timeScale = 1f;

            LogManager.OnDebugLog(
                LabelType.Success, 
                typeof(GameManager),
                $"<b>Game Application</b> plays successfully");
        }

        public static void OnQuit()
        {
            LogManager.OnDebugLog(typeof(GameManager),
                $"OnQuit()");

            LogManager.OnDebugLog(
                LabelType.Success, 
                typeof(GameManager),
                $"<b>Game Application</b> is quited successfully");

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
