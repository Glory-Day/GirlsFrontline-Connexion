#region NAMESPACE API

using UnityEngine;
using Manager;
using UI = UnityEngine.UI;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Event.Button
{
    /// <summary>
    /// Events in the <b>Main Scene</b>
    /// </summary>
    public class GameStartButtonEvent : MonoBehaviour
    {
        private UI.Button gameStartButton;

        // Start is called before the first frame update
        private void Start()
        {
            LogManager.OnDebugLog(
                typeof(GameStartButtonEvent),
                "Start()");
            
            gameStartButton = GetComponent<UI.Button>();
        }

        #region BUTTON EVENT API

        /// <summary>
        /// <see cref="UI.Button"/> event to click <see cref="gameStartButton"/> in <b>Main Scene</b>
        /// </summary>
        public void OnClicked()
        {
            LogManager.OnDebugLog(
                LabelType.Event, 
                typeof(GameStartButtonEvent),
                "<b>Game Start Button</b> is clicked");

            gameStartButton.interactable = false;

            UIManager.SetScreenTransitionDirectionToLeft();
            UIManager.OnPlayScreenTransitionAnimation();
        }
        
        #endregion
    }
}
