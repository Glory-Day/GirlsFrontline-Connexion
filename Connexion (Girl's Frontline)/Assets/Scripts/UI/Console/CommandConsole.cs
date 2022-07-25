using UnityEngine;

using Manager;
using UnityEngine.InputSystem;

namespace UI.Console
{
    /// <summary>
    /// Command console for development game application
    /// </summary>
    /// TODO: Command consoles should not be used in the final build because it is used only for development
    public class CommandConsole : MonoBehaviour
    {
        [Header("# Command Console Components")]
        [SerializeField] 
        public GameObject commandInputField;

        private bool isConsoleEnabled;

        // Awake is called when the script instance is being loaded
        private void Awake()
        {
            transform.SetParent(UIManager.GetTransform());
            commandInputField.SetActive(false);
            isConsoleEnabled = false;
        }

        public void OnToggle(InputAction.CallbackContext context)
        {
            if (!context.performed) return;

            switch (isConsoleEnabled)
            {
                case false:
                    GameManager.OnPause();
                    commandInputField.SetActive(true);
                    isConsoleEnabled = true;
                    break;
                case true:
                    GameManager.OnPlay();
                    commandInputField.SetActive(false);
                    isConsoleEnabled = false;
                    break;
            }
        }
    }
}
