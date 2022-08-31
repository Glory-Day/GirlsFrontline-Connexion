#region NAMESPACE API

using UnityEngine;
using Manager;
using LabelType = Manager.Log.Label.LabelType;
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
                LabelType.Event,
                typeof(SkipButton),
                "<b>Skip Button</b> is clicked");
            
            SceneManager.OnLoadSceneByName(SceneName.MainScene);
        }

        #endregion
    }
}
