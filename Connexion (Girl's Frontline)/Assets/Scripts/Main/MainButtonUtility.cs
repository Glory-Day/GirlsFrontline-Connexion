using Manager;
using Manager.Log;
using UnityEngine;

namespace Main
{
    public class MainButtonUtility : MonoBehaviour
    {
        /// <summary>
        /// Button event to click <b>Game Start Button</b> in <b>Main Scene</b>
        /// </summary>
        public void OnClickedGameStartButton()
        {
            LogManager.OnDebugLog(Label.LabelType.Event, typeof(MainButtonUtility), 
                "<b>Game Start Button</b> is clicked");
            
            UIManager.SetLeftScreenTransitionAnimation();
            UIManager.OnPlayScreenTransitionAnimation();
        }
    }
}
