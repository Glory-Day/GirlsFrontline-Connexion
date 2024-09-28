// GENERATED AUTOMATICALLY FROM 'Assets/Input System/Player Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Object.Character
{
    public class @PlayerControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""900fe1c0-2642-4f9e-865e-b62a895f9aae"",
            ""actions"": [
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""bf8d63fa-1f3b-4200-8db4-ae028460e5da"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""6b2b33c3-86a0-4a3a-854a-0f45a42b2dfe"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use Skill 01"",
                    ""type"": ""Button"",
                    ""id"": ""c8a3c63b-af50-4dee-8d9e-151fed545361"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use Skill 02"",
                    ""type"": ""Button"",
                    ""id"": ""01b348cc-3f22-42f0-9d72-f5b910dd9f28"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use Skill 03"",
                    ""type"": ""Button"",
                    ""id"": ""19cc2b48-b3ee-4825-b0fe-a9d46f7aa491"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7f29249e-de3b-4314-b2c3-4f3b5a2ab69d"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Window Platform"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""a4da967c-8bca-4f18-9174-676727dbce71"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""08ab8172-ae37-453b-8d5b-6f380460be12"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Window Platform"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""77070e01-8ad1-45a7-947b-882d54338f8b"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Window Platform"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5d368414-bab4-4987-83ec-9c8a8e7f1a88"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Window Platform"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9658dfb2-3f92-4c8b-aa72-a69f25185cee"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Window Platform"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""51ec86e3-2833-44a2-83ab-e1fd32b17589"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Window Platform"",
                    ""action"": ""Use Skill 01"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8acf7208-9eba-422d-8f78-869607786102"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Window Platform"",
                    ""action"": ""Use Skill 02"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""203e3caf-ff6f-4ac2-81d7-a9ec48f681c0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Window Platform"",
                    ""action"": ""Use Skill 03"",
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
            ""devices"": []
        }
    ]
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_Attack = m_Player.FindAction("Attack", throwIfNotFound: true);
            m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
            m_Player_UseSkill01 = m_Player.FindAction("Use Skill 01", throwIfNotFound: true);
            m_Player_UseSkill02 = m_Player.FindAction("Use Skill 02", throwIfNotFound: true);
            m_Player_UseSkill03 = m_Player.FindAction("Use Skill 03", throwIfNotFound: true);
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

        // Player
        private readonly InputActionMap m_Player;
        private IPlayerActions m_PlayerActionsCallbackInterface;
        private readonly InputAction m_Player_Attack;
        private readonly InputAction m_Player_Move;
        private readonly InputAction m_Player_UseSkill01;
        private readonly InputAction m_Player_UseSkill02;
        private readonly InputAction m_Player_UseSkill03;
        public struct PlayerActions
        {
            private @PlayerControls m_Wrapper;
            public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Attack => m_Wrapper.m_Player_Attack;
            public InputAction @Move => m_Wrapper.m_Player_Move;
            public InputAction @UseSkill01 => m_Wrapper.m_Player_UseSkill01;
            public InputAction @UseSkill02 => m_Wrapper.m_Player_UseSkill02;
            public InputAction @UseSkill03 => m_Wrapper.m_Player_UseSkill03;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @Attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                    @Attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                    @Attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                    @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @UseSkill01.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseSkill01;
                    @UseSkill01.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseSkill01;
                    @UseSkill01.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseSkill01;
                    @UseSkill02.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseSkill02;
                    @UseSkill02.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseSkill02;
                    @UseSkill02.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseSkill02;
                    @UseSkill03.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseSkill03;
                    @UseSkill03.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseSkill03;
                    @UseSkill03.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseSkill03;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Attack.started += instance.OnAttack;
                    @Attack.performed += instance.OnAttack;
                    @Attack.canceled += instance.OnAttack;
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @UseSkill01.started += instance.OnUseSkill01;
                    @UseSkill01.performed += instance.OnUseSkill01;
                    @UseSkill01.canceled += instance.OnUseSkill01;
                    @UseSkill02.started += instance.OnUseSkill02;
                    @UseSkill02.performed += instance.OnUseSkill02;
                    @UseSkill02.canceled += instance.OnUseSkill02;
                    @UseSkill03.started += instance.OnUseSkill03;
                    @UseSkill03.performed += instance.OnUseSkill03;
                    @UseSkill03.canceled += instance.OnUseSkill03;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);
        private int m_WindowPlatformSchemeIndex = -1;
        public InputControlScheme WindowPlatformScheme
        {
            get
            {
                if (m_WindowPlatformSchemeIndex == -1) m_WindowPlatformSchemeIndex = asset.FindControlSchemeIndex("Window Platform");
                return asset.controlSchemes[m_WindowPlatformSchemeIndex];
            }
        }
        public interface IPlayerActions
        {
            void OnAttack(InputAction.CallbackContext context);
            void OnMove(InputAction.CallbackContext context);
            void OnUseSkill01(InputAction.CallbackContext context);
            void OnUseSkill02(InputAction.CallbackContext context);
            void OnUseSkill03(InputAction.CallbackContext context);
        }
    }
}
