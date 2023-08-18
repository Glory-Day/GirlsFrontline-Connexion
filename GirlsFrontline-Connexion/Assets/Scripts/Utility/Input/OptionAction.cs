// GENERATED AUTOMATICALLY FROM 'Assets/Input System/UI/Option Action.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Utility.Input
{
    public class @OptionAction : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @OptionAction()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Option Action"",
    ""maps"": [
        {
            ""name"": ""Option Screen"",
            ""id"": ""f2995e39-78d9-4bfa-b1de-377c13767952"",
            ""actions"": [
                {
                    ""name"": ""Toggle"",
                    ""type"": ""Button"",
                    ""id"": ""bdec946a-8bc3-450b-ab5e-6ec787ffb615"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""34900641-f654-4f42-81f3-54b18fe01cb7"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Toggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Option Screen
            m_OptionScreen = asset.FindActionMap("Option Screen", throwIfNotFound: true);
            m_OptionScreen_Toggle = m_OptionScreen.FindAction("Toggle", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // Option Screen
        private readonly InputActionMap m_OptionScreen;
        private IOptionScreenActions m_OptionScreenActionsCallbackInterface;
        private readonly InputAction m_OptionScreen_Toggle;
        public struct OptionScreenActions
        {
            private @OptionAction m_Wrapper;
            public OptionScreenActions(@OptionAction wrapper) { m_Wrapper = wrapper; }
            public InputAction @Toggle => m_Wrapper.m_OptionScreen_Toggle;
            public InputActionMap Get() { return m_Wrapper.m_OptionScreen; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(OptionScreenActions set) { return set.Get(); }
            public void SetCallbacks(IOptionScreenActions instance)
            {
                if (m_Wrapper.m_OptionScreenActionsCallbackInterface != null)
                {
                    @Toggle.started -= m_Wrapper.m_OptionScreenActionsCallbackInterface.OnToggle;
                    @Toggle.performed -= m_Wrapper.m_OptionScreenActionsCallbackInterface.OnToggle;
                    @Toggle.canceled -= m_Wrapper.m_OptionScreenActionsCallbackInterface.OnToggle;
                }
                m_Wrapper.m_OptionScreenActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Toggle.started += instance.OnToggle;
                    @Toggle.performed += instance.OnToggle;
                    @Toggle.canceled += instance.OnToggle;
                }
            }
        }
        public OptionScreenActions @OptionScreen => new OptionScreenActions(this);
        private int m_KeyboardSchemeIndex = -1;
        public InputControlScheme KeyboardScheme
        {
            get
            {
                if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
                return asset.controlSchemes[m_KeyboardSchemeIndex];
            }
        }
        public interface IOptionScreenActions
        {
            void OnToggle(InputAction.CallbackContext context);
        }
    }
}
