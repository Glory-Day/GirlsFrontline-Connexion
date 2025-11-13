using System;
using System.Reflection;
using GloryDay.Debug.Log;
using GloryDay.UI.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GloryDay.UI
{
    public abstract class PopUpScreenBase : ScreenBase
    {
        private InputActionAsset _inputActionAsset;
        
        private InputAction _inputActionCallback;
        private string      _inputActionCallbackName;
        
        protected GameObject ScreenObject;
        
        protected AudioClip OpenPopUpSound;
        protected AudioClip ClosePopUpSound;
        
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();
            
            _inputActionAsset = new UIControls().Asset;
        }

        protected void OnEnable()
        {
            _inputActionCallback.Enable();
            _inputActionCallback.performed += Toggle;
        }

        protected virtual void Start()
        {
            LogManager.LogProgress();
            
            ScreenObject = transform.GetChild(0).gameObject;
            ScreenObject.SetActive(false);
            
            Type = ScreenType.PopUp;
        }

        protected void OnDisable()
        {
            _inputActionCallback.performed -= Toggle;
            _inputActionCallback.Disable();
        }

        protected abstract void Toggle(InputAction.CallbackContext context);

        protected void SetInputAction(string keyword)
        {
            LogManager.LogProgress();

            // Create input binding
            var controlScheme = _inputActionAsset.controlSchemes[0];
            var deviceRequirement = controlScheme.deviceRequirements[0];
            var controlPath = $"{deviceRequirement.controlPath}/{keyword}";
            var bindingGroup = controlScheme.bindingGroup;
            var inputBinding = new InputBinding(controlPath, _inputActionCallbackName, bindingGroup);
            
            // Get pop up screen input action map in asset
            var inputActionMap = _inputActionAsset.actionMaps[0];
            
            // Add input action and input binding
            _inputActionCallback = inputActionMap.AddAction(_inputActionCallbackName, InputActionType.Button);
            _inputActionCallback.AddBinding(inputBinding);
        }
        
        protected void SetInputActionCallbackName(Type type, string callbackName)
        {
            LogManager.LogProgress();
            
            try
            {
                var methodInfo = type.GetMethod(callbackName, BindingFlags.NonPublic | BindingFlags.Instance);
                if (methodInfo == null)
                {
                    throw new Exception("Unable to find input action callback with that name in class");
                }
            
                _inputActionCallbackName = $"{callbackName}-{methodInfo.GetHashCode()}";
            }
            catch (Exception exception)
            {
                LogManager.LogError(exception.Message);
            }
        }
    }
}