#region NAMESPACE API

using UnityEngine;
using UnityEngine.UI;

using Manager;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Main
{
    /// <summary>
    /// Events in the <b>Main Scene</b>
    /// </summary>
    public class MainEventUtility : MonoBehaviour
    {
        #region SERIALIZABLE FIELD

        [Header("# Game Start Button")]
        [SerializeField]
        public Button gameStartButton;

        #endregion
        
        #region BUTTON EVENT API

        /// <summary>
        /// Button event to click <b>Game Start Button</b> in <b>Main Scene</b>
        /// </summary>
        public void OnClickedGameStartButton()
        {
            LogManager.OnDebugLog(LabelType.Event, typeof(MainEventUtility), 
                "<b>Game Start Button</b> is clicked");

            gameStartButton.interactable = false;
            
            UIManager.SetScreenTransitionDirectionToLeft();
            UIManager.OnPlayScreenTransitionAnimation();
        }

        #endregion
    }
}
