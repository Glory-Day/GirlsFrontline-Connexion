#region NAMESPACE API

using System;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Manager
{
    /// <summary>
    /// Manager that manages <b>Scene</b> used in <b>Game Application</b>
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
        /// Load scene by <see cref="SceneName"/>
        /// </summary>
        /// <param name="name"> Name of scene </param>
        /// <exception cref="ArgumentOutOfRangeException"> Out of range in <see cref="SceneName"/> </exception>
        public static void OnLoadSceneByName(SceneName name)
        {
            LogManager.OnDebugLog(typeof(SceneManager),
                $"OnLoadSceneByName()");

            switch (name)
            {
                case SceneName.MainScene:
                    UnityEngine.SceneManagement.SceneManager.LoadScene(DataManager.SceneData.scenes[0].name);
                    SoundManager.OnChangeBackgroundAudioClip(SceneName.MainScene);

                    LogManager.OnDebugLog(LabelType.Success, typeof(SceneManager),
                        $"<b>{DataManager.SceneData.scenes[0].name}</b> is loaded successfully");
                    break;
                case SceneName.SelectionScene:
                    UnityEngine.SceneManagement.SceneManager.LoadScene(DataManager.SceneData.scenes[1].name);
                    SoundManager.OnChangeBackgroundAudioClip(SceneName.SelectionScene);

                    LogManager.OnDebugLog(LabelType.Success, typeof(SceneManager),
                        $"<b>{DataManager.SceneData.scenes[1].name}</b> is loaded successfully");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(name), name, null);
            }
        }

        /// <summary>
        /// Get the currently active current <see cref="SceneName"/>
        /// </summary>
        public static SceneName CurrentSceneName =>
            (SceneName)UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

        #endregion

    }
}
