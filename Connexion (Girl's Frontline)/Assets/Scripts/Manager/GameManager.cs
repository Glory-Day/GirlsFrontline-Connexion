using System;
using UnityEngine;

using Manager.Log;

namespace Manager
{
    /// <summary>
    /// Manager that manage the game applications
    /// </summary>
    public class GameManager : Singleton<GameManager>
    {
        protected GameManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        /// <summary>
        /// Pause the game application
        /// </summary>
        public static void OnPause()
        {
            LogManager.OnDebugLog(typeof(GameManager), 
                $"OnPause()");

            if (Time.timeScale < 0.5f)
            {
                LogManager.OnDebugLog(Label.LabelType.Warning, typeof(GameManager), 
                    $"The game application has already been paused");

                return;
            }

            UIManager.OnEnablePauseScreen();
            
            Time.timeScale = 0f;

            LogManager.OnDebugLog(Label.LabelType.Success, typeof(GameManager), 
                $"The game application pauses completely");
        }

        /// <summary>
        /// Play the game application
        /// </summary>
        public static void OnPlay()
        {
            LogManager.OnDebugLog(typeof(GameManager), 
                $"OnPlay()");

            if (Time.timeScale > 0.5f)
            {
                LogManager.OnDebugLog(Label.LabelType.Warning, typeof(GameManager), 
                    $"The game application is currently running");

                return;
            }

            UIManager.OnDisablePauseScreen();
            
            Time.timeScale = 1f;

            LogManager.OnDebugLog(Label.LabelType.Success, typeof(GameManager), 
                $"The game application plays completely");
        }
    }
}
