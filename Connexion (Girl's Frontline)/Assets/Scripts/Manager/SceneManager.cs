#region NAMESPACE API

using System;

using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Manager
{
    /// <summary>
    /// Manager that manages the entire scene used in <b>Game Application</b>
    /// </summary>
    public class SceneManager : Singleton<SceneManager>
    {
        /// <summary>
        /// Enum type for select scene
        /// </summary>
        public enum SceneName
        {
            MainScene = 1,
            SelectionScene
        }
        
        protected SceneManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        #region LOAD API

        /// <summary>
        /// Load scene by scene name
        /// </summary>
        /// <param name="name"> Name of scene </param>
        /// <exception cref="ArgumentOutOfRangeException"> Out of range in <b>SceneName</b> </exception>
        public static void OnLoadSceneByName(SceneName name)
        {
            LogManager.OnDebugLog(typeof(SceneManager), 
                $"OnLoadSceneByName()");

            switch (name)
            {
                case SceneName.MainScene:
                    UnityEngine.SceneManagement.SceneManager.LoadScene(DataManager.SceneData.names[0]);
                    SoundManager.OnChangeBackgroundAudioClip(SceneName.MainScene);
                    
                    LogManager.OnDebugLog(LabelType.Success, typeof(SceneManager),
                        $"<b>{DataManager.SceneData.names[0]}</b> is loaded successfully");
                    break;
                case SceneName.SelectionScene:
                    UnityEngine.SceneManagement.SceneManager.LoadScene(DataManager.SceneData.names[1]);
                    SoundManager.OnChangeBackgroundAudioClip(SceneName.SelectionScene);
                    
                    LogManager.OnDebugLog(LabelType.Success, typeof(SceneManager),
                        $"<b>{DataManager.SceneData.names[1]}</b> is loaded successfully");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(name), name, null);
            }
        }

        /// <summary>
        /// Get the currently active current scene name
        /// </summary>
        public static SceneName CurrentSceneName => 
            (SceneName)UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

        #endregion

    }
}
