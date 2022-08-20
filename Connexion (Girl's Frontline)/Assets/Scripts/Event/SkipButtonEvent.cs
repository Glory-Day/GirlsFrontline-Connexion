#region NAMESPACE API

using UnityEngine;
using Manager;
using UI = UnityEngine.UI;
using LabelType = Manager.Log.Label.LabelType;
using SceneName = Manager.SceneManager.SceneName;

#endregion

namespace Event.Button
{
    public class SkipButtonEvent : MonoBehaviour
    {
        #region BUTTON EVENT API

        /// <summary>
        /// <see cref="UI.Button"/> event to skip video when clicked button in <b>Introduction Video Scene</b>
        /// </summary>
        public void OnClicked()
        {
            LogManager.OnDebugLog(
                LabelType.Event,
                typeof(SkipButtonEvent),
                "<b>Skip Button</b> is clicked");
            
            SceneManager.OnLoadSceneByName(SceneName.MainScene);
        }

        #endregion
    }
}
