using GloryDay.Debug.Log;
using Utility.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Library.UI.CommandConsole.View
{
    public class CommandConsoleScreen : MonoBehaviour
    {
        #region INPUT SYSTEM API

        private CommandConsoleControls.ScreenActions _controls;

        #endregion
        
        private GameObject _commandConsoleScreen;
        
        public void Awake()
        {
            LogManager.LogProgress();

            _controls = new CommandConsoleControls.ScreenActions();
        }

        public void OnEnable()
        {
            LogManager.LogProgress();
            
            _controls.Enable();
            _controls.Toggle.performed += Toggle;
        }
        
        public void Start()
        {
            LogManager.LogProgress();

            _commandConsoleScreen = transform.GetChild(0).gameObject;
        }

        public void OnDisable()
        {
            LogManager.LogProgress();
            
            _controls.Toggle.performed -= Toggle;
            _controls.Disable();
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
                LogManager.LogAsAdministrator("Turn off <b>Command Console</b>");

                _commandConsoleScreen.SetActive(false);
            }
            else
            {
                LogManager.LogAsAdministrator("Turn on <b>Command Console</b>");

                _commandConsoleScreen.SetActive(true);
            }
        }
    }
}
