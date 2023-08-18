// GENERATED AUTOMATICALLY FROM 'Assets/Input System/UI/Console Action.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Utility.Input
{
    public class @ConsoleAction : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @ConsoleAction()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Console Action"",
    ""maps"": [
        {
            ""name"": ""Command Console"",
            ""id"": ""fe1534c6-314e-448d-8f0a-8b29de7cafd5"",
            ""actions"": [
                {
                    ""name"": ""Toggle"",
                    ""type"": ""Button"",
                    ""id"": ""bcf4520e-833a-4184-9238-78bcfc10ecb6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Execute"",
                    ""type"": ""Button"",
                    ""id"": ""a5eaf18b-0e38-46e2-ba94-2dc836c31e7b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""54cb008b-8fba-43d2-98a0-c188b868e858"",
                    ""path"": ""<Keyboard>/f12"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Toggle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c12e6dce-1b08-446b-9971-abe2dd7876c1"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Execute"",
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
            // Command Console
            m_CommandConsole = asset.FindActionMap("Command Console", throwIfNotFound: true);
            m_CommandConsole_Toggle = m_CommandConsole.FindAction("Toggle", throwIfNotFound: true);
            m_CommandConsole_Execute = m_CommandConsole.FindAction("Execute", throwIfNotFound: true);
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

        // Command Console
        private readonly InputActionMap m_CommandConsole;
        private ICommandConsoleActions m_CommandConsoleActionsCallbackInterface;
        private readonly InputAction m_CommandConsole_Toggle;
        private readonly InputAction m_CommandConsole_Execute;
        public struct CommandConsoleActions
        {
            private @ConsoleAction m_Wrapper;
            public CommandConsoleActions(@ConsoleAction wrapper) { m_Wrapper = wrapper; }
            public InputAction @Toggle => m_Wrapper.m_CommandConsole_Toggle;
            public InputAction @Execute => m_Wrapper.m_CommandConsole_Execute;
            public InputActionMap Get() { return m_Wrapper.m_CommandConsole; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CommandConsoleActions set) { return set.Get(); }
            public void SetCallbacks(ICommandConsoleActions instance)
            {
                if (m_Wrapper.m_CommandConsoleActionsCallbackInterface != null)
                {
                    @Toggle.started -= m_Wrapper.m_CommandConsoleActionsCallbackInterface.OnToggle;
                    @Toggle.performed -= m_Wrapper.m_CommandConsoleActionsCallbackInterface.OnToggle;
                    @Toggle.canceled -= m_Wrapper.m_CommandConsoleActionsCallbackInterface.OnToggle;
                    @Execute.started -= m_Wrapper.m_CommandConsoleActionsCallbackInterface.OnExecute;
                    @Execute.performed -= m_Wrapper.m_CommandConsoleActionsCallbackInterface.OnExecute;
                    @Execute.canceled -= m_Wrapper.m_CommandConsoleActionsCallbackInterface.OnExecute;
                }
                m_Wrapper.m_CommandConsoleActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Toggle.started += instance.OnToggle;
                    @Toggle.performed += instance.OnToggle;
                    @Toggle.canceled += instance.OnToggle;
                    @Execute.started += instance.OnExecute;
                    @Execute.performed += instance.OnExecute;
                    @Execute.canceled += instance.OnExecute;
                }
            }
        }
        public CommandConsoleActions @CommandConsole => new CommandConsoleActions(this);
        private int m_KeyboardSchemeIndex = -1;
        public InputControlScheme KeyboardScheme
        {
            get
            {
                if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
                return asset.controlSchemes[m_KeyboardSchemeIndex];
            }
        }
        public interface ICommandConsoleActions
        {
            void OnToggle(InputAction.CallbackContext context);
            void OnExecute(InputAction.CallbackContext context);
        }
    }
}
