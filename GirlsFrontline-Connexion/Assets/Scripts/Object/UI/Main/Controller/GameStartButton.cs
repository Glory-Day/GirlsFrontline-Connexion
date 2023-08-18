using UnityEngine;
using Object.Manager;
using Utility.Manager;

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
            LogManager.LogProgress();
            
            gameStartButton = GetComponent<UnityEngine.UI.Button>();
        }

        #region BUTTON EVENT API

        public void OnClicked()
        {
            LogManager.LogMessage("<b>Game Start Button</b> is clicked");

            gameStartButton.interactable = false;

            UIManager.OnPlayScreenTransitionToLeft();
        }
        
        #endregion
    }
}
