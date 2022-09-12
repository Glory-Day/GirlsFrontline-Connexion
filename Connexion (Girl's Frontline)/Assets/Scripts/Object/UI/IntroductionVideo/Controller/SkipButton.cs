#region NAMESPACE API

using UnityEngine;
using Manager;
using Label = Manager.Log.Label;

#endregion

namespace Object.UI.IntroductionVideo.Controller
{
    public class SkipButton : MonoBehaviour
    {
        #region BUTTON EVENT API

        public void OnClicked()
        {
            LogManager.OnDebugLog(
                Label.Event,
                typeof(SkipButton),
                "<b>Skip Button</b> is clicked");
            
            SceneManager.OnLoadSceneByLabel(Manager.Scene.Label.Main);
        }

        #endregion
    }
}
