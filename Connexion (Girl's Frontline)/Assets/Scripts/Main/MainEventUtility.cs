using UnityEngine;

using Manager;
using Manager.Log;

namespace Main
{
    /// <summary>
    /// Events in the <b>Main Scene</b>
    /// </summary>
    public class MainEventUtility : MonoBehaviour
    {
        #region BUTTON EVENT API

        /// <summary>
        /// Button event to click <b>Game Start Button</b> in <b>Main Scene</b>
        /// </summary>
        public void OnClickedGameStartButton()
        {
            LogManager.OnDebugLog(Label.LabelType.Event, typeof(MainEventUtility), 
                "<b>Game Start Button</b> is clicked");
            
            UIManager.SetLeftScreenTransitionAnimation();
            UIManager.OnPlayScreenTransitionAnimation();
        }

        #endregion
    }
}
