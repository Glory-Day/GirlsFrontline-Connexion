#region NAMESPACE API

using System;
using Label = Manager.Log.Label;

#endregion

namespace Manager
{
    public class SceneManager : Singleton<SceneManager>
    {
        protected SceneManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        #region STATIC METHOD API

        public static void OnLoadSceneByLabel(Scene.Label label)
        {
            LogManager.OnDebugLog(
                typeof(SceneManager),
                $"OnLoadSceneByName()");

            switch (label)
            {
                case Scene.Label.Main:
                    UnityEngine.SceneManagement.SceneManager.LoadScene(DataManager.SceneData.scenes[0].name);
                    SoundManager.OnChangeBackgroundAudioClip(Scene.Label.Main);

                    LogManager.OnDebugLog(
                        Label.Success, 
                        typeof(SceneManager),
                        $"<b>{DataManager.SceneData.scenes[0].name}</b> is loaded successfully");
                    break;
                case Scene.Label.Selection:
                    UnityEngine.SceneManagement.SceneManager.LoadScene(DataManager.SceneData.scenes[1].name);
                    SoundManager.OnChangeBackgroundAudioClip(Scene.Label.Selection);

                    LogManager.OnDebugLog(
                        Label.Success, 
                        typeof(SceneManager),
                        $"<b>{DataManager.SceneData.scenes[1].name}</b> is loaded successfully");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(label), label, null);
            }
        }

        #endregion

        #region STATIC PROPERTIES API

        public static Scene.Label CurrentSceneLabel =>
            (Scene.Label)UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

        #endregion
    }
}
