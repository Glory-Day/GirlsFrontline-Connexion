#region NAMESPACE API

using UnityEngine;
using Object.Manager;
using Util.Manager;
using Util.Manager.Log;

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
            
            SceneManager.OnLoadSceneByLabel(Util.Manager.Scene.Label.Main);
        }

        #endregion
    }
}
