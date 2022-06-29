using System;

using LabelType = Manager.Log.Label.LabelType;

namespace Manager
{
    /// <summary>
    /// Manager that manages the entire scene used in the game
    /// </summary>
    public class SceneManager : Singleton<SceneManager>
    {
        /// <summary>
        /// Enum type for select scene
        /// </summary>
        public enum SceneName
        {
            MainScene = 0,
            SelectionScene
        }
        
        protected SceneManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        #region STATIC API

        /// <summary>
        /// Load scene with scene name
        /// </summary>
        /// <param name="name"> Name of scene </param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void OnLoadScene(SceneName name)
        {
            LogManager.OnDebugLog(typeof(SceneManager), 
                $"OnLoadScene()");

            switch (name)
            {
                case SceneName.MainScene:
                    UnityEngine.SceneManagement.SceneManager.LoadScene(DataManager.SceneInformation.names[0]);
                    SoundManager.OnChangeBackgroundAudioClip(SceneName.MainScene);
                    
                    LogManager.OnDebugLog(LabelType.Success, typeof(SceneManager),
                        $"<b>{DataManager.SceneInformation.names[0]}</b> is loaded");
                    break;
                case SceneName.SelectionScene:
                    UnityEngine.SceneManagement.SceneManager.LoadScene(DataManager.SceneInformation.names[1]);
                    SoundManager.OnChangeBackgroundAudioClip(SceneName.SelectionScene);
                    
                    LogManager.OnDebugLog(LabelType.Success, typeof(SceneManager),
                        $"<b>{DataManager.SceneInformation.names[1]}</b> is loaded");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(name), name, null);
            }
        }

        #endregion
    }
}
