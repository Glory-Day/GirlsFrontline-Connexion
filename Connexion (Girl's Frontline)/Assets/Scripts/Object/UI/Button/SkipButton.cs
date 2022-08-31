#region NAMESPACE API

using UnityEngine;
using Manager;
using Label = Manager.Log.LogLabel.Label;
using SceneName = Manager.SceneManager.SceneName;

#endregion

namespace Object.UI.Button
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
            
            SceneManager.OnLoadSceneByName(SceneName.MainScene);
        }

        #endregion
    }
}
