// GENERATED AUTOMATICALLY FROM 'Assets/Input System/Main Interface Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace UI.Utility.Input
{
    public class @MainInterfaceControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @MainInterfaceControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Main Interface Controls"",
    ""maps"": [
        {
            ""name"": ""Information Display"",
            ""id"": ""ad8b20ae-f0b3-4832-8e7f-83a040025a83"",
            ""actions"": [
                {
                    ""name"": ""Display Skill Information"",
                    ""type"": ""Button"",
                    ""id"": ""58882f9f-3151-498c-918d-10e8df8a2788"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Display Character Stat Point Information"",
                    ""type"": ""Button"",
                    ""id"": ""5bb7c706-9425-4182-a815-552fbd18e73f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0b8d658f-1ecb-4d22-8fe9-293e6e7da3b9"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Window Platform"",
                    ""action"": ""Display Skill Information"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e00dc5f7-5f30-4a13-8928-954256bccabd"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Window Platform"",
                    ""action"": ""Display Character Stat Point Information"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Pause Button"",
            ""id"": ""448e4283-80f2-4400-80a1-0a6fe6c5a75e"",
            ""actions"": [
                {
                    ""name"": ""Toggle"",
                    ""type"": ""Button"",
                    ""id"": ""aca5d531-59a2-4150-8075-7231a6f5d3cc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7eca0bdd-a779-4d91-abb7-96a0aba60979"",
                    ""path"": ""<Keyboard>/q"",
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
            ""name"": ""Quit Button"",
            ""id"": ""a65afd21-8549-47e4-b6b3-820e2a4d41b5"",
            ""actions"": [
                {
                    ""name"": ""Toggle"",
                    ""type"": ""Button"",
                    ""id"": ""9005d84f-8771-497f-96cb-2bda50f58235"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0b4a2dab-863d-401f-a2de-254b3d638bec"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Window Platform"",
                    ""action"": ""Toggle"",
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
            // Information Display
            m_InformationDisplay = asset.FindActionMap("Information Display", throwIfNotFound: true);
            m_InformationDisplay_DisplaySkillInformation = m_InformationDisplay.FindAction("Display Skill Information", throwIfNotFound: true);
            m_InformationDisplay_DisplayCharacterStatPointInformation = m_InformationDisplay.FindAction("Display Character Stat Point Information", throwIfNotFound: true);
            // Pause Button
            m_PauseButton = asset.FindActionMap("Pause Button", throwIfNotFound: true);
            m_PauseButton_Toggle = m_PauseButton.FindAction("Toggle", throwIfNotFound: true);
            // Quit Button
            m_QuitButton = asset.FindActionMap("Quit Button", throwIfNotFound: true);
            m_QuitButton_Toggle = m_QuitButton.FindAction("Toggle", throwIfNotFound: true);
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

        // Information Display
        private readonly InputActionMap m_InformationDisplay;
        private IInformationDisplayActions m_InformationDisplayActionsCallbackInterface;
        private readonly InputAction m_InformationDisplay_DisplaySkillInformation;
        private readonly InputAction m_InformationDisplay_DisplayCharacterStatPointInformation;
        public struct InformationDisplayActions
        {
            private @MainInterfaceControls m_Wrapper;
            public InformationDisplayActions(@MainInterfaceControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @DisplaySkillInformation => m_Wrapper.m_InformationDisplay_DisplaySkillInformation;
            public InputAction @DisplayCharacterStatPointInformation => m_Wrapper.m_InformationDisplay_DisplayCharacterStatPointInformation;
            public InputActionMap Get() { return m_Wrapper.m_InformationDisplay; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(InformationDisplayActions set) { return set.Get(); }
            public void SetCallbacks(IInformationDisplayActions instance)
            {
                if (m_Wrapper.m_InformationDisplayActionsCallbackInterface != null)
                {
                    @DisplaySkillInformation.started -= m_Wrapper.m_InformationDisplayActionsCallbackInterface.OnDisplaySkillInformation;
                    @DisplaySkillInformation.performed -= m_Wrapper.m_InformationDisplayActionsCallbackInterface.OnDisplaySkillInformation;
                    @DisplaySkillInformation.canceled -= m_Wrapper.m_InformationDisplayActionsCallbackInterface.OnDisplaySkillInformation;
                    @DisplayCharacterStatPointInformation.started -= m_Wrapper.m_InformationDisplayActionsCallbackInterface.OnDisplayCharacterStatPointInformation;
                    @DisplayCharacterStatPointInformation.performed -= m_Wrapper.m_InformationDisplayActionsCallbackInterface.OnDisplayCharacterStatPointInformation;
                    @DisplayCharacterStatPointInformation.canceled -= m_Wrapper.m_InformationDisplayActionsCallbackInterface.OnDisplayCharacterStatPointInformation;
                }
                m_Wrapper.m_InformationDisplayActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @DisplaySkillInformation.started += instance.OnDisplaySkillInformation;
                    @DisplaySkillInformation.performed += instance.OnDisplaySkillInformation;
                    @DisplaySkillInformation.canceled += instance.OnDisplaySkillInformation;
                    @DisplayCharacterStatPointInformation.started += instance.OnDisplayCharacterStatPointInformation;
                    @DisplayCharacterStatPointInformation.performed += instance.OnDisplayCharacterStatPointInformation;
                    @DisplayCharacterStatPointInformation.canceled += instance.OnDisplayCharacterStatPointInformation;
                }
            }
        }
        public InformationDisplayActions @InformationDisplay => new InformationDisplayActions(this);

        // Pause Button
        private readonly InputActionMap m_PauseButton;
        private IPauseButtonActions m_PauseButtonActionsCallbackInterface;
        private readonly InputAction m_PauseButton_Toggle;
        public struct PauseButtonActions
        {
            private @MainInterfaceControls m_Wrapper;
            public PauseButtonActions(@MainInterfaceControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Toggle => m_Wrapper.m_PauseButton_Toggle;
            public InputActionMap Get() { return m_Wrapper.m_PauseButton; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PauseButtonActions set) { return set.Get(); }
            public void SetCallbacks(IPauseButtonActions instance)
            {
                if (m_Wrapper.m_PauseButtonActionsCallbackInterface != null)
                {
                    @Toggle.started -= m_Wrapper.m_PauseButtonActionsCallbackInterface.OnToggle;
                    @Toggle.performed -= m_Wrapper.m_PauseButtonActionsCallbackInterface.OnToggle;
                    @Toggle.canceled -= m_Wrapper.m_PauseButtonActionsCallbackInterface.OnToggle;
                }
                m_Wrapper.m_PauseButtonActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Toggle.started += instance.OnToggle;
                    @Toggle.performed += instance.OnToggle;
                    @Toggle.canceled += instance.OnToggle;
                }
            }
        }
        public PauseButtonActions @PauseButton => new PauseButtonActions(this);

        // Quit Button
        private readonly InputActionMap m_QuitButton;
        private IQuitButtonActions m_QuitButtonActionsCallbackInterface;
        private readonly InputAction m_QuitButton_Toggle;
        public struct QuitButtonActions
        {
            private @MainInterfaceControls m_Wrapper;
            public QuitButtonActions(@MainInterfaceControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Toggle => m_Wrapper.m_QuitButton_Toggle;
            public InputActionMap Get() { return m_Wrapper.m_QuitButton; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(QuitButtonActions set) { return set.Get(); }
            public void SetCallbacks(IQuitButtonActions instance)
            {
                if (m_Wrapper.m_QuitButtonActionsCallbackInterface != null)
                {
                    @Toggle.started -= m_Wrapper.m_QuitButtonActionsCallbackInterface.OnToggle;
                    @Toggle.performed -= m_Wrapper.m_QuitButtonActionsCallbackInterface.OnToggle;
                    @Toggle.canceled -= m_Wrapper.m_QuitButtonActionsCallbackInterface.OnToggle;
                }
                m_Wrapper.m_QuitButtonActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Toggle.started += instance.OnToggle;
                    @Toggle.performed += instance.OnToggle;
                    @Toggle.canceled += instance.OnToggle;
                }
            }
        }
        public QuitButtonActions @QuitButton => new QuitButtonActions(this);
        private int m_WindowPlatformSchemeIndex = -1;
        public InputControlScheme WindowPlatformScheme
        {
            get
            {
                if (m_WindowPlatformSchemeIndex == -1) m_WindowPlatformSchemeIndex = asset.FindControlSchemeIndex("Window Platform");
                return asset.controlSchemes[m_WindowPlatformSchemeIndex];
            }
        }
        public interface IInformationDisplayActions
        {
            void OnDisplaySkillInformation(InputAction.CallbackContext context);
            void OnDisplayCharacterStatPointInformation(InputAction.CallbackContext context);
        }
        public interface IPauseButtonActions
        {
            void OnToggle(InputAction.CallbackContext context);
        }
        public interface IQuitButtonActions
        {
            void OnToggle(InputAction.CallbackContext context);
        }
    }
}
