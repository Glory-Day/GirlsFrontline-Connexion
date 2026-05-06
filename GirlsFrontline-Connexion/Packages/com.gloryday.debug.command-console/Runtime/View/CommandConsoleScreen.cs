using UnityEngine;
using UnityEngine.InputSystem;

namespace GloryDay.Debug
{
    public class CommandConsoleScreen : MonoBehaviour
    {
        #region INPUT SYSTEM API

        // private CommandConsoleControls.ScreenActions _controls;

        #endregion

        private GameObject _commandConsoleScreen;

        public void Awake()
        {
            Console.LogProgress();

            // _controls = new CommandConsoleControls.ScreenActions();
        }

        public void OnEnable()
        {
            Console.LogProgress();

            // _controls.Enable();
            // _controls.Toggle.performed += Toggle;
        }

        public void Start()
        {
            Console.LogProgress();

            _commandConsoleScreen = transform.GetChild(0).gameObject;
        }

        public void OnDisable()
        {
            Console.LogProgress();

            // _controls.Toggle.performed -= Toggle;
            // _controls.Disable();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="context"> Information provided to action callbacks about what triggered an action </param>
        private void Toggle(InputAction.CallbackContext context)
        {
            if (context.performed == false)
            {
                return;
            }

            var isActive = _commandConsoleScreen.activeInHierarchy;
            if (isActive)
            {
                Console.LogAsAdministrator("Turn off <b>Command Console</b>");

                _commandConsoleScreen.SetActive(false);
            }
            else
            {
                Console.LogAsAdministrator("Turn on <b>Command Console</b>");

                _commandConsoleScreen.SetActive(true);
            }
        }
    }
}
