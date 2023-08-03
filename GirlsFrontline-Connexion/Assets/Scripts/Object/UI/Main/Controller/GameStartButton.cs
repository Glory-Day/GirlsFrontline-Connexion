using UnityEngine;
using Object.Manager;
using Util.Manager;
using Util.Log;

namespace Object.UI.Main.Controller
{
    public class GameStartButton : MonoBehaviour
    {
        #region COMPONENT API

        private UnityEngine.UI.Button gameStartButton;

        #endregion

        // Start is called before the first frame update
        private void Start()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(GameStartButton),
                "Start()");
            
            gameStartButton = GetComponent<UnityEngine.UI.Button>();
        }

        #region BUTTON EVENT API

        public void OnClicked()
        {
            LogManager.OnDebugLog(
                Label.Event, 
                typeof(GameStartButton),
                "<b>Game Start Button</b> is clicked");

            gameStartButton.interactable = false;

            UIManager.OnPlayScreenTransitionToLeft();
        }
        
        #endregion
    }
}
