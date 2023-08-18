using System;
using Object.Manager;
using Utility.Manager.Scene;

namespace Utility.Manager
{
    public class SceneManager : Singleton<SceneManager>
    {
        #region STATIC METHOD API

        public static void OnLoadSceneByLabel(Label label)
        {
            LogManager.LogProgress();

            switch (label)
            {
                case Scene.Label.Main:
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Main Scene");
                    SoundManager.OnChangeBackgroundAudioClip(Scene.Label.Main);

                    LogManager.LogSuccess("<b>Main Scene</b> is loaded");
                    break;
                case Scene.Label.Selection:
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Selection Scene");
                    SoundManager.OnChangeBackgroundAudioClip(Scene.Label.Selection);

                    LogManager.LogSuccess("<b>Selection Scene</b> is loaded");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(label), label, null);
            }
        }

        #endregion

        #region STATIC PROPERTIES API

        public static Label CurrentSceneLabel =>
            (Label)UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

        #endregion
    }
}
