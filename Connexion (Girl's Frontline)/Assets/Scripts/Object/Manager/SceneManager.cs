#region NAMESPACE API

using System;
using Util.Manager;
using Util.Manager.Log;

#endregion

namespace Object.Manager
{
    public class SceneManager : Singleton<SceneManager>
    {
        protected SceneManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        #region STATIC METHOD API

        public static void OnLoadSceneByLabel(Util.Manager.Scene.Label label)
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(SceneManager),
                $"OnLoadSceneByName()");

            switch (label)
            {
                case Util.Manager.Scene.Label.Main:
                    UnityEngine.SceneManagement.SceneManager.LoadScene(DataManager.SceneData.scenes[0].name);
                    SoundManager.OnChangeBackgroundAudioClip(Util.Manager.Scene.Label.Main);

                    LogManager.OnDebugLog(
                        Label.Success, 
                        typeof(SceneManager),
                        $"<b>{DataManager.SceneData.scenes[0].name}</b> is loaded");
                    break;
                case Util.Manager.Scene.Label.Selection:
                    UnityEngine.SceneManagement.SceneManager.LoadScene(DataManager.SceneData.scenes[1].name);
                    SoundManager.OnChangeBackgroundAudioClip(Util.Manager.Scene.Label.Selection);

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
