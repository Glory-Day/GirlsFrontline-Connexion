// GENERATED AUTOMATICALLY FROM 'Assets/Input System/UI Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace UI.Utility.Input
{
    public class @UIControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @UIControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""UI Controls"",
    ""maps"": [
        {
            ""name"": ""Introduction Video"",
            ""id"": ""b26a79fe-d147-4a37-a991-a5dbd4afe259"",
            ""actions"": [
                {
                    ""name"": ""Skip"",
                    ""type"": ""Button"",
                    ""id"": ""04c293b8-57fa-463a-9a1c-0c0421317035"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1628c6c9-32bb-4cc9-8606-375c60281fc8"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Window Platform"",
                    ""action"": ""Skip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Title"",
            ""id"": ""044db425-45e5-4197-a394-a1c86b705731"",
            ""actions"": [
                {
                    ""name"": ""To Chapter Selection"",
                    ""type"": ""Button"",
                    ""id"": ""6771a31a-c0c9-42a8-b41e-5b6cfdc4dafa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ba98d5d8-30e1-4265-95bd-882d73f7883e"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Window Platform"",
                    ""action"": ""To Chapter Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Chapter Selection"",
            ""id"": ""fd5e3fa7-0181-431c-b0de-68b70ed3346e"",
            ""actions"": [
                {
                    ""name"": ""Select Next Chapter"",
                    ""type"": ""Button"",
                    ""id"": ""4603a1f8-cdcd-45e2-be04-d5f8f55d2e56"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select Previous Chapter"",
                    ""type"": ""Button"",
                    ""id"": ""6c997041-541e-439a-8feb-17119e34f98d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Return To Title"",
                    ""type"": ""Button"",
                    ""id"": ""4db22f72-b5da-4957-9faa-d3e4e0d63fee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""836bd202-75bb-47c4-b845-6cd77e32eb25"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Window Platform"",
                    ""action"": ""Return To Title"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a2515e6-8423-4e84-9956-1a2a0683b1bb"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Window Platform"",
                    ""action"": ""Select Next Chapter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55ae40a5-3e1e-4551-a3ce-796cace1f6bc"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Window Platform"",
                    ""action"": ""Select Previous Chapter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Main Interface"",
            ""id"": ""e24469ad-fcda-4a81-8644-88114c7b7553"",
            ""actions"": [
                {
                    ""name"": ""Display Skill Information"",
                    ""type"": ""Button"",
                    ""id"": ""1f6a33fb-0533-4e15-9ca3-ec62e52fec16"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Display Character Stat Point Information"",
                    ""type"": ""Button"",
                    ""id"": ""a0501f39-7329-4190-b94f-334097d93f08"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""d5bebd59-f577-49fe-beb9-cef218858417"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""fc39d9f2-f615-45e1-8ab8-a0fc2ebe52a9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""65e04fb2-9523-4fab-b84c-a14da9081a31"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4bb956b5-4ca4-4e07-96b9-94aa4336dc0a"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Window Platform"",
                    ""action"": ""Display Skill Information"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bfd39c29-7f11-4aa6-801e-e9e757923d81"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Window Platform"",
                    ""action"": ""Display Character Stat Point Information"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""112698e9-06ca-472f-b3f2-6619ce17374f"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Window Platform"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3bf7a3d-89fb-4fe9-80dc-df1e1c8fac2b"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Window Platform"",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f93deea-652a-4a8e-ab6b-2ddba09cf27d"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Window Platform"",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Victory Result"",
            ""id"": ""912ec474-4893-4a6b-b1d4-aed7165e6860"",
            ""actions"": [
                {
                    ""name"": ""Return To Title"",
                    ""type"": ""Button"",
                    ""id"": ""0c8c7593-0fc3-4217-b0d6-4140bf275fc4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c4449c7d-7831-4c1d-801a-ddee2e242de7"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Window Platform"",
                    ""action"": ""Return To Title"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Failed Result"",
            ""id"": ""1b62eadc-5fdc-42f8-aa86-4aa2bf5569c2"",
            ""actions"": [
                {
                    ""name"": ""Open Dialog Screen"",
                    ""type"": ""Button"",
                    ""id"": ""982d8211-9a54-47fa-b9fc-5bbbdb18faab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c5f9076c-2d00-4c18-b9a6-454df535c1a1"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Window Platform"",
                    ""action"": ""Open Dialog Screen"",
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
            // Introduction Video
            m_IntroductionVideo = asset.FindActionMap("Introduction Video", throwIfNotFound: true);
            m_IntroductionVideo_Skip = m_IntroductionVideo.FindAction("Skip", throwIfNotFound: true);
            // Title
            m_Title = asset.FindActionMap("Title", throwIfNotFound: true);
            m_Title_ToChapterSelection = m_Title.FindAction("To Chapter Selection", throwIfNotFound: true);
            // Chapter Selection
            m_ChapterSelection = asset.FindActionMap("Chapter Selection", throwIfNotFound: true);
            m_ChapterSelection_SelectNextChapter = m_ChapterSelection.FindAction("Select Next Chapter", throwIfNotFound: true);
            m_ChapterSelection_SelectPreviousChapter = m_ChapterSelection.FindAction("Select Previous Chapter", throwIfNotFound: true);
            m_ChapterSelection_ReturnToTitle = m_ChapterSelection.FindAction("Return To Title", throwIfNotFound: true);
            // Main Interface
            m_MainInterface = asset.FindActionMap("Main Interface", throwIfNotFound: true);
            m_MainInterface_DisplaySkillInformation = m_MainInterface.FindAction("Display Skill Information", throwIfNotFound: true);
            m_MainInterface_DisplayCharacterStatPointInformation = m_MainInterface.FindAction("Display Character Stat Point Information", throwIfNotFound: true);
            m_MainInterface_Restart = m_MainInterface.FindAction("Restart", throwIfNotFound: true);
            m_MainInterface_Pause = m_MainInterface.FindAction("Pause", throwIfNotFound: true);
            m_MainInterface_Quit = m_MainInterface.FindAction("Quit", throwIfNotFound: true);
            // Victory Result
            m_VictoryResult = asset.FindActionMap("Victory Result", throwIfNotFound: true);
            m_VictoryResult_ReturnToTitle = m_VictoryResult.FindAction("Return To Title", throwIfNotFound: true);
            // Failed Result
            m_FailedResult = asset.FindActionMap("Failed Result", throwIfNotFound: true);
            m_FailedResult_OpenDialogScreen = m_FailedResult.FindAction("Open Dialog Screen", throwIfNotFound: true);
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

        // Introduction Video
        private readonly InputActionMap m_IntroductionVideo;
        private IIntroductionVideoActions m_IntroductionVideoActionsCallbackInterface;
        private readonly InputAction m_IntroductionVideo_Skip;
        public struct IntroductionVideoActions
        {
            private @UIControls m_Wrapper;
            public IntroductionVideoActions(@UIControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Skip => m_Wrapper.m_IntroductionVideo_Skip;
            public InputActionMap Get() { return m_Wrapper.m_IntroductionVideo; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(IntroductionVideoActions set) { return set.Get(); }
            public void SetCallbacks(IIntroductionVideoActions instance)
            {
                if (m_Wrapper.m_IntroductionVideoActionsCallbackInterface != null)
                {
                    @Skip.started -= m_Wrapper.m_IntroductionVideoActionsCallbackInterface.OnSkip;
                    @Skip.performed -= m_Wrapper.m_IntroductionVideoActionsCallbackInterface.OnSkip;
                    @Skip.canceled -= m_Wrapper.m_IntroductionVideoActionsCallbackInterface.OnSkip;
                }
                m_Wrapper.m_IntroductionVideoActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Skip.started += instance.OnSkip;
                    @Skip.performed += instance.OnSkip;
                    @Skip.canceled += instance.OnSkip;
                }
            }
        }
        public IntroductionVideoActions @IntroductionVideo => new IntroductionVideoActions(this);

        // Title
        private readonly InputActionMap m_Title;
        private ITitleActions m_TitleActionsCallbackInterface;
        private readonly InputAction m_Title_ToChapterSelection;
        public struct TitleActions
        {
            private @UIControls m_Wrapper;
            public TitleActions(@UIControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @ToChapterSelection => m_Wrapper.m_Title_ToChapterSelection;
            public InputActionMap Get() { return m_Wrapper.m_Title; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(TitleActions set) { return set.Get(); }
            public void SetCallbacks(ITitleActions instance)
            {
                if (m_Wrapper.m_TitleActionsCallbackInterface != null)
                {
                    @ToChapterSelection.started -= m_Wrapper.m_TitleActionsCallbackInterface.OnToChapterSelection;
                    @ToChapterSelection.performed -= m_Wrapper.m_TitleActionsCallbackInterface.OnToChapterSelection;
                    @ToChapterSelection.canceled -= m_Wrapper.m_TitleActionsCallbackInterface.OnToChapterSelection;
                }
                m_Wrapper.m_TitleActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @ToChapterSelection.started += instance.OnToChapterSelection;
                    @ToChapterSelection.performed += instance.OnToChapterSelection;
                    @ToChapterSelection.canceled += instance.OnToChapterSelection;
                }
            }
        }
        public TitleActions @Title => new TitleActions(this);

        // Chapter Selection
        private readonly InputActionMap m_ChapterSelection;
        private IChapterSelectionActions m_ChapterSelectionActionsCallbackInterface;
        private readonly InputAction m_ChapterSelection_SelectNextChapter;
        private readonly InputAction m_ChapterSelection_SelectPreviousChapter;
        private readonly InputAction m_ChapterSelection_ReturnToTitle;
        public struct ChapterSelectionActions
        {
            private @UIControls m_Wrapper;
            public ChapterSelectionActions(@UIControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @SelectNextChapter => m_Wrapper.m_ChapterSelection_SelectNextChapter;
            public InputAction @SelectPreviousChapter => m_Wrapper.m_ChapterSelection_SelectPreviousChapter;
            public InputAction @ReturnToTitle => m_Wrapper.m_ChapterSelection_ReturnToTitle;
            public InputActionMap Get() { return m_Wrapper.m_ChapterSelection; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ChapterSelectionActions set) { return set.Get(); }
            public void SetCallbacks(IChapterSelectionActions instance)
            {
                if (m_Wrapper.m_ChapterSelectionActionsCallbackInterface != null)
                {
                    @SelectNextChapter.started -= m_Wrapper.m_ChapterSelectionActionsCallbackInterface.OnSelectNextChapter;
                    @SelectNextChapter.performed -= m_Wrapper.m_ChapterSelectionActionsCallbackInterface.OnSelectNextChapter;
                    @SelectNextChapter.canceled -= m_Wrapper.m_ChapterSelectionActionsCallbackInterface.OnSelectNextChapter;
                    @SelectPreviousChapter.started -= m_Wrapper.m_ChapterSelectionActionsCallbackInterface.OnSelectPreviousChapter;
                    @SelectPreviousChapter.performed -= m_Wrapper.m_ChapterSelectionActionsCallbackInterface.OnSelectPreviousChapter;
                    @SelectPreviousChapter.canceled -= m_Wrapper.m_ChapterSelectionActionsCallbackInterface.OnSelectPreviousChapter;
                    @ReturnToTitle.started -= m_Wrapper.m_ChapterSelectionActionsCallbackInterface.OnReturnToTitle;
                    @ReturnToTitle.performed -= m_Wrapper.m_ChapterSelectionActionsCallbackInterface.OnReturnToTitle;
                    @ReturnToTitle.canceled -= m_Wrapper.m_ChapterSelectionActionsCallbackInterface.OnReturnToTitle;
                }
                m_Wrapper.m_ChapterSelectionActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @SelectNextChapter.started += instance.OnSelectNextChapter;
                    @SelectNextChapter.performed += instance.OnSelectNextChapter;
                    @SelectNextChapter.canceled += instance.OnSelectNextChapter;
                    @SelectPreviousChapter.started += instance.OnSelectPreviousChapter;
                    @SelectPreviousChapter.performed += instance.OnSelectPreviousChapter;
                    @SelectPreviousChapter.canceled += instance.OnSelectPreviousChapter;
                    @ReturnToTitle.started += instance.OnReturnToTitle;
                    @ReturnToTitle.performed += instance.OnReturnToTitle;
                    @ReturnToTitle.canceled += instance.OnReturnToTitle;
                }
            }
        }
        public ChapterSelectionActions @ChapterSelection => new ChapterSelectionActions(this);

        // Main Interface
        private readonly InputActionMap m_MainInterface;
        private IMainInterfaceActions m_MainInterfaceActionsCallbackInterface;
        private readonly InputAction m_MainInterface_DisplaySkillInformation;
        private readonly InputAction m_MainInterface_DisplayCharacterStatPointInformation;
        private readonly InputAction m_MainInterface_Restart;
        private readonly InputAction m_MainInterface_Pause;
        private readonly InputAction m_MainInterface_Quit;
        public struct MainInterfaceActions
        {
            private @UIControls m_Wrapper;
            public MainInterfaceActions(@UIControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @DisplaySkillInformation => m_Wrapper.m_MainInterface_DisplaySkillInformation;
            public InputAction @DisplayCharacterStatPointInformation => m_Wrapper.m_MainInterface_DisplayCharacterStatPointInformation;
            public InputAction @Restart => m_Wrapper.m_MainInterface_Restart;
            public InputAction @Pause => m_Wrapper.m_MainInterface_Pause;
            public InputAction @Quit => m_Wrapper.m_MainInterface_Quit;
            public InputActionMap Get() { return m_Wrapper.m_MainInterface; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MainInterfaceActions set) { return set.Get(); }
            public void SetCallbacks(IMainInterfaceActions instance)
            {
                if (m_Wrapper.m_MainInterfaceActionsCallbackInterface != null)
                {
                    @DisplaySkillInformation.started -= m_Wrapper.m_MainInterfaceActionsCallbackInterface.OnDisplaySkillInformation;
                    @DisplaySkillInformation.performed -= m_Wrapper.m_MainInterfaceActionsCallbackInterface.OnDisplaySkillInformation;
                    @DisplaySkillInformation.canceled -= m_Wrapper.m_MainInterfaceActionsCallbackInterface.OnDisplaySkillInformation;
                    @DisplayCharacterStatPointInformation.started -= m_Wrapper.m_MainInterfaceActionsCallbackInterface.OnDisplayCharacterStatPointInformation;
                    @DisplayCharacterStatPointInformation.performed -= m_Wrapper.m_MainInterfaceActionsCallbackInterface.OnDisplayCharacterStatPointInformation;
                    @DisplayCharacterStatPointInformation.canceled -= m_Wrapper.m_MainInterfaceActionsCallbackInterface.OnDisplayCharacterStatPointInformation;
                    @Restart.started -= m_Wrapper.m_MainInterfaceActionsCallbackInterface.OnRestart;
                    @Restart.performed -= m_Wrapper.m_MainInterfaceActionsCallbackInterface.OnRestart;
                    @Restart.canceled -= m_Wrapper.m_MainInterfaceActionsCallbackInterface.OnRestart;
                    @Pause.started -= m_Wrapper.m_MainInterfaceActionsCallbackInterface.OnPause;
                    @Pause.performed -= m_Wrapper.m_MainInterfaceActionsCallbackInterface.OnPause;
                    @Pause.canceled -= m_Wrapper.m_MainInterfaceActionsCallbackInterface.OnPause;
                    @Quit.started -= m_Wrapper.m_MainInterfaceActionsCallbackInterface.OnQuit;
                    @Quit.performed -= m_Wrapper.m_MainInterfaceActionsCallbackInterface.OnQuit;
                    @Quit.canceled -= m_Wrapper.m_MainInterfaceActionsCallbackInterface.OnQuit;
                }
                m_Wrapper.m_MainInterfaceActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @DisplaySkillInformation.started += instance.OnDisplaySkillInformation;
                    @DisplaySkillInformation.performed += instance.OnDisplaySkillInformation;
                    @DisplaySkillInformation.canceled += instance.OnDisplaySkillInformation;
                    @DisplayCharacterStatPointInformation.started += instance.OnDisplayCharacterStatPointInformation;
                    @DisplayCharacterStatPointInformation.performed += instance.OnDisplayCharacterStatPointInformation;
                    @DisplayCharacterStatPointInformation.canceled += instance.OnDisplayCharacterStatPointInformation;
                    @Restart.started += instance.OnRestart;
                    @Restart.performed += instance.OnRestart;
                    @Restart.canceled += instance.OnRestart;
                    @Pause.started += instance.OnPause;
                    @Pause.performed += instance.OnPause;
                    @Pause.canceled += instance.OnPause;
                    @Quit.started += instance.OnQuit;
                    @Quit.performed += instance.OnQuit;
                    @Quit.canceled += instance.OnQuit;
                }
            }
        }
        public MainInterfaceActions @MainInterface => new MainInterfaceActions(this);

        // Victory Result
        private readonly InputActionMap m_VictoryResult;
        private IVictoryResultActions m_VictoryResultActionsCallbackInterface;
        private readonly InputAction m_VictoryResult_ReturnToTitle;
        public struct VictoryResultActions
        {
            private @UIControls m_Wrapper;
            public VictoryResultActions(@UIControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @ReturnToTitle => m_Wrapper.m_VictoryResult_ReturnToTitle;
            public InputActionMap Get() { return m_Wrapper.m_VictoryResult; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(VictoryResultActions set) { return set.Get(); }
            public void SetCallbacks(IVictoryResultActions instance)
            {
                if (m_Wrapper.m_VictoryResultActionsCallbackInterface != null)
                {
                    @ReturnToTitle.started -= m_Wrapper.m_VictoryResultActionsCallbackInterface.OnReturnToTitle;
                    @ReturnToTitle.performed -= m_Wrapper.m_VictoryResultActionsCallbackInterface.OnReturnToTitle;
                    @ReturnToTitle.canceled -= m_Wrapper.m_VictoryResultActionsCallbackInterface.OnReturnToTitle;
                }
                m_Wrapper.m_VictoryResultActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @ReturnToTitle.started += instance.OnReturnToTitle;
                    @ReturnToTitle.performed += instance.OnReturnToTitle;
                    @ReturnToTitle.canceled += instance.OnReturnToTitle;
                }
            }
        }
        public VictoryResultActions @VictoryResult => new VictoryResultActions(this);

        // Failed Result
        private readonly InputActionMap m_FailedResult;
        private IFailedResultActions m_FailedResultActionsCallbackInterface;
        private readonly InputAction m_FailedResult_OpenDialogScreen;
        public struct FailedResultActions
        {
            private @UIControls m_Wrapper;
            public FailedResultActions(@UIControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @OpenDialogScreen => m_Wrapper.m_FailedResult_OpenDialogScreen;
            public InputActionMap Get() { return m_Wrapper.m_FailedResult; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(FailedResultActions set) { return set.Get(); }
            public void SetCallbacks(IFailedResultActions instance)
            {
                if (m_Wrapper.m_FailedResultActionsCallbackInterface != null)
                {
                    @OpenDialogScreen.started -= m_Wrapper.m_FailedResultActionsCallbackInterface.OnOpenDialogScreen;
                    @OpenDialogScreen.performed -= m_Wrapper.m_FailedResultActionsCallbackInterface.OnOpenDialogScreen;
                    @OpenDialogScreen.canceled -= m_Wrapper.m_FailedResultActionsCallbackInterface.OnOpenDialogScreen;
                }
                m_Wrapper.m_FailedResultActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @OpenDialogScreen.started += instance.OnOpenDialogScreen;
                    @OpenDialogScreen.performed += instance.OnOpenDialogScreen;
                    @OpenDialogScreen.canceled += instance.OnOpenDialogScreen;
                }
            }
        }
        public FailedResultActions @FailedResult => new FailedResultActions(this);
        private int m_WindowPlatformSchemeIndex = -1;
        public InputControlScheme WindowPlatformScheme
        {
            get
            {
                if (m_WindowPlatformSchemeIndex == -1) m_WindowPlatformSchemeIndex = asset.FindControlSchemeIndex("Window Platform");
                return asset.controlSchemes[m_WindowPlatformSchemeIndex];
            }
        }
        public interface IIntroductionVideoActions
        {
            void OnSkip(InputAction.CallbackContext context);
        }
        public interface ITitleActions
        {
            void OnToChapterSelection(InputAction.CallbackContext context);
        }
        public interface IChapterSelectionActions
        {
            void OnSelectNextChapter(InputAction.CallbackContext context);
            void OnSelectPreviousChapter(InputAction.CallbackContext context);
            void OnReturnToTitle(InputAction.CallbackContext context);
        }
        public interface IMainInterfaceActions
        {
            void OnDisplaySkillInformation(InputAction.CallbackContext context);
            void OnDisplayCharacterStatPointInformation(InputAction.CallbackContext context);
            void OnRestart(InputAction.CallbackContext context);
            void OnPause(InputAction.CallbackContext context);
            void OnQuit(InputAction.CallbackContext context);
        }
        public interface IVictoryResultActions
        {
            void OnReturnToTitle(InputAction.CallbackContext context);
        }
        public interface IFailedResultActions
        {
            void OnOpenDialogScreen(InputAction.CallbackContext context);
        }
    }
}
