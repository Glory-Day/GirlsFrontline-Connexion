using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Object.Manager;
using Util.Input;
using Util.Manager;
using Util.Log;

namespace Object.UI.Option
{
    public class OptionScreen : MonoBehaviour
    {
        private OptionAction optionAction;
        
        private GameObject components;

        // Awake is called when the script instance is being loaded
        private void Awake()
        {
            LogManager.LogCalled();
            
            components = transform.GetChild(0).gameObject;

            optionAction = new OptionAction();
        }

        // OnEnable is called when the object becomes enabled and active
        private void OnEnable()
        {
            LogManager.LogCalled();
            
            optionAction.Enable();
        }
        
        // Start is called before the first frame update
        private void Start()
        {
            LogManager.LogCalled();
            
            optionAction.OptionScreen.Toggle.performed += Toggle;
        }

        // OnDisable is called when the behaviour becomes disabled
        private void OnDisable()
        {
            LogManager.LogCalled();
            
            optionAction.Disable();
        }

        private void Toggle(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }
            
            switch (components.activeInHierarchy)
            {
                case true:
                    LogManager.LogMessage("<b>Input Event</b> is enabled. Option screen is toggled <b>On</b>");
                    
                    components.SetActive(false);
                    return;
                case false:
                    LogManager.LogMessage("<b>Input Event</b> is enabled. Option screen is toggled <b>Off</b>");
                    
                    components.SetActive(true);
                    return;
            }
        }
    }
}
