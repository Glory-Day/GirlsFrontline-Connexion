using System;

using LabelType = Manager.Log.Console.Label.LabelType;

namespace Manager
{
    /// <summary>
    /// Manager that manages the entire scene used in the game
    /// </summary>
    public class SceneManager : Singleton<SceneManager>
    {
        // Enum type for select scene
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

        public static void OnLoadScene(SceneName name)
        {
#if UNITY_EDITOR

            LogManager.OnDebugLog(
                typeof(SceneManager), 
                $"Called OnLoadScene()");

#endif
            
            switch (name)
            {
                case SceneName.MainScene:
                    
#if UNITY_EDITOR

                    LogManager.OnDebugLog(
                        LabelType.Success,
                        typeof(SceneManager),
                        $"{DataManager.SceneInformation.names[0]} is loaded completely");

#endif
                    
                    UnityEngine.SceneManagement.SceneManager.LoadScene(DataManager.SceneInformation.names[0]);
                    break;
                case SceneName.SelectionScene:
                    
#if UNITY_EDITOR

                    LogManager.OnDebugLog(
                        LabelType.Success,
                        typeof(SceneManager),
                        $"{DataManager.SceneInformation.names[1]} is loaded completely");

#endif
                    
                    UnityEngine.SceneManagement.SceneManager.LoadScene(DataManager.SceneInformation.names[1]);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(name), name, null);
            }
        }

        #endregion
    }
}
