#region NAMESPACE API

using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Object.Manager;
using Util.Input;
using Util.Manager;
using Util.Manager.Log;

#endregion

namespace Object.UI.Option
{
    public class OptionScreen : MonoBehaviour
    {
        private OptionAction optionAction;
        
        private GameObject components;

        // Awake is called when the script instance is being loaded
        private void Awake()
        {
            LogManager.OnDebugLog(
                Label.Called, 
                typeof(OptionScreen), 
                "Awake()");
            
            components = transform.GetChild(0).gameObject;

            optionAction = new OptionAction();
        }

        // OnEnable is called when the object becomes enabled and active
        private void OnEnable()
        {
            LogManager.OnDebugLog(
                Label.Called, 
                typeof(OptionScreen), 
                "OnEnable()");
            
            optionAction.Enable();
        }
        
        // Start is called before the first frame update
        private void Start()
        {
            LogManager.OnDebugLog(
                Label.Called, 
                typeof(OptionScreen), 
                "Start()");
            
            optionAction.OptionScreen.Toggle.performed += Toggle;
        }

        // OnDisable is called when the behaviour becomes disabled
        private void OnDisable()
        {
            LogManager.OnDebugLog(
                Label.Called, 
                typeof(OptionScreen), 
                "OnDisable()");
            
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
                    LogManager.OnDebugLog(
                        Label.Event, 
                        typeof(OptionScreen), 
                        "<b>Input Event</b> is enabled. Option screen is toggled <b>On</b>");
                    
                    components.SetActive(false);
                    return;
                case false:
                    LogManager.OnDebugLog(
                        Label.Event, 
                        typeof(OptionScreen), 
                        "<b>Input Event</b> is enabled. Option screen is toggled <b>Off</b>");
                    
                    components.SetActive(true);
                    return;
            }
        }
    }
}
