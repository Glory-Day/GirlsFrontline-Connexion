using System;
using Object.Manager;
using Util.Log;

namespace Util.Manager
{
    public class SceneManager : Singleton<SceneManager>
    {
        #region STATIC METHOD API

        public static void OnLoadSceneByLabel(Util.Manager.Scene.Label label)
        {
            LogManager.OnDebugLog(
                Label.Called,
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
                        $"<b>{DataManager.SceneData.scenes[0].name}</b> is loaded");
                    break;
                case Scene.Label.Selection:
                    UnityEngine.SceneManagement.SceneManager.LoadScene(DataManager.SceneData.scenes[1].name);
                    SoundManager.OnChangeBackgroundAudioClip(Scene.Label.Selection);

                    LogManager.OnDebugLog(
                        Label.Success, 
                        typeof(SceneManager),
                        $"<b>{DataManager.SceneData.scenes[1].name}</b> is loaded");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(label), label, null);
            }
        }

        #endregion

        #region STATIC PROPERTIES API

        public static Util.Manager.Scene.Label CurrentSceneLabel =>
            (Util.Manager.Scene.Label)UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

        #endregion
    }
}
