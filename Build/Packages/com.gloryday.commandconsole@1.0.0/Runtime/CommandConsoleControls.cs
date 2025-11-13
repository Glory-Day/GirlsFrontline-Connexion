// GENERATED AUTOMATICALLY FROM 'Assets/Input System/Command Console Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;


namespace Utility.Input
{
    public class @CommandConsoleControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @CommandConsoleControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Command Console Controls"",
    ""maps"": [
        {
            ""name"": ""Screen"",
            ""id"": ""acb03588-0dcc-4f86-a235-af01a4beb15c"",
            ""actions"": [
                {
                    ""name"": ""Toggle"",
                    ""type"": ""Button"",
                    ""id"": ""5d707ca3-4fa7-4f01-b867-1b84a31a43e5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a0861ea7-9480-4b46-9dfa-564e26c97cd2"",
                    ""path"": ""<Keyboard>/f12"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Window Platform"",
                    ""action"": ""Toggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Input Field"",
            ""id"": ""c30f05e0-254e-40eb-aca9-f0f82d27936c"",
            ""actions"": [
                {
                    ""name"": ""Input"",
                    ""type"": ""Button"",
                    ""id"": ""50f3057b-c8b4-4e1d-ab90-f825f9f1f842"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""20fa4326-4f1c-4f85-9e72-ec7461af53ed"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Window Platform"",
                    ""action"": ""Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Window Platform"",
            ""bindingGroup"": ""Window Platform"",
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
            // Screen
            m_Screen = asset.FindActionMap("Screen", throwIfNotFound: true);
            m_Screen_Toggle = m_Screen.FindAction("Toggle", throwIfNotFound: true);
            // Input Field
            m_InputField = asset.FindActionMap("Input Field", throwIfNotFound: true);
            m_InputField_Input = m_InputField.FindAction("Input", throwIfNotFound: true);
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

        // Screen
        private readonly InputActionMap m_Screen;
        private IScreenActions m_ScreenActionsCallbackInterface;
        private readonly InputAction m_Screen_Toggle;
        public struct ScreenActions
        {
            private @CommandConsoleControls m_Wrapper;
            public ScreenActions(@CommandConsoleControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Toggle => m_Wrapper.m_Screen_Toggle;
            public InputActionMap Get() { return m_Wrapper.m_Screen; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ScreenActions set) { return set.Get(); }
            public void SetCallbacks(IScreenActions instance)
            {
                if (m_Wrapper.m_ScreenActionsCallbackInterface != null)
                {
                    @Toggle.started -= m_Wrapper.m_ScreenActionsCallbackInterface.OnToggle;
                    @Toggle.performed -= m_Wrapper.m_ScreenActionsCallbackInterface.OnToggle;
                    @Toggle.canceled -= m_Wrapper.m_ScreenActionsCallbackInterface.OnToggle;
                }
                m_Wrapper.m_ScreenActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Toggle.started += instance.OnToggle;
                    @Toggle.performed += instance.OnToggle;
                    @Toggle.canceled += instance.OnToggle;
                }
            }
        }
        public ScreenActions @Screen => new ScreenActions(this);

        // Input Field
        private readonly InputActionMap m_InputField;
        private IInputFieldActions m_InputFieldActionsCallbackInterface;
        private readonly InputAction m_InputField_Input;
        public struct InputFieldActions
        {
            private @CommandConsoleControls m_Wrapper;
            public InputFieldActions(@CommandConsoleControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Input => m_Wrapper.m_InputField_Input;
            public InputActionMap Get() { return m_Wrapper.m_InputField; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(InputFieldActions set) { return set.Get(); }
            public void SetCallbacks(IInputFieldActions instance)
            {
                if (m_Wrapper.m_InputFieldActionsCallbackInterface != null)
                {
                    @Input.started -= m_Wrapper.m_InputFieldActionsCallbackInterface.OnInput;
                    @Input.performed -= m_Wrapper.m_InputFieldActionsCallbackInterface.OnInput;
                    @Input.canceled -= m_Wrapper.m_InputFieldActionsCallbackInterface.OnInput;
                }
                m_Wrapper.m_InputFieldActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Input.started += instance.OnInput;
                    @Input.performed += instance.OnInput;
                    @Input.canceled += instance.OnInput;
                }
            }
        }
        public InputFieldActions @InputField => new InputFieldActions(this);
        private int m_WindowPlatformSchemeIndex = -1;
        public InputControlScheme WindowPlatformScheme
        {
            get
            {
                if (m_WindowPlatformSchemeIndex == -1) m_WindowPlatformSchemeIndex = asset.FindControlSchemeIndex("Window Platform");
                return asset.controlSchemes[m_WindowPlatformSchemeIndex];
            }
        }
        public interface IScreenActions
        {
            void OnToggle(InputAction.CallbackContext context);
        }
        public interface IInputFieldActions
        {
            void OnInput(InputAction.CallbackContext context);
        }
    }
}
