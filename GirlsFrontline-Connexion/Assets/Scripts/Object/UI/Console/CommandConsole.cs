using System;
using System.Collections.Generic;
using System.Linq;
using Object.Manager;
using UnityEngine;
using UnityEngine.InputSystem;
using Util.Command;
using Util.Input;
using Util.Manager;
using Util.Log;


namespace Object.UI.Console
{
    public class CommandConsole : MonoBehaviour
    {
        #region SERIALIZABLE FIELD API

        [Header("# Input Field Layout Group Object")]
        [SerializeField]
        private GameObject inputFieldLayoutGroup;

        #endregion
        
        #region CONSTANT FIELD API

        private const string LoadAllDataCommand             = "OnLoadAllData";
        private const string ChangeBackgroundAudioClip      = "OnChangeBackgroundAudioClip --CurrentScene";
        private const string InstantiateAllUIPrefabsCommand = "OnInstantiateAllUIPrefabs";
        private const string LoadMainScene                  = "OnLoadScene --Name Main";
        private const string ApplicationQuit                = "OnApplicationQuit";
        private const string ApplicationPlay                = "OnApplicationPlay";

        #endregion

        private ConsoleAction consoleAction;
        
        // Awake is called when the script instance is being loaded 
        private void Awake()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(CommandConsole), 
                "Awake()");
            
            Commands = new Dictionary<string, ICommand>
                       {
                           { LoadAllDataCommand,             new LoadAllDataCommand() },
                           { ChangeBackgroundAudioClip,      new ChangeBackgroundAudioClipCommand() },
                           { InstantiateAllUIPrefabsCommand, new InstantiateAllUIPrefabsCommand() },
                           { LoadMainScene,                  new LoadMainScene() },
                           { ApplicationQuit,                new ApplicationQuitCommand() },
                           { ApplicationPlay,                new ApplicationPlayCommand() }
                       };

            consoleAction = new ConsoleAction();
        }

        // OnEnable is called when the object becomes enabled and active
        private void OnEnable()
        {
            LogManager.OnDebugLog(
                Label.Called, 
                typeof(CommandConsole), 
                "OnEnable()");
            
            consoleAction.Enable();
        }

        // Start is called before the first frame update
        private void Start()
        {
            consoleAction.CommandConsole.Toggle.performed += Toggle;
        }

        // OnDisable is called when the behaviour becomes disabled
        private void OnDisable()
        {
            LogManager.OnDebugLog(
                Label.Called, 
                typeof(CommandConsole), 
                "OnDisable()");
            
            consoleAction.Disable();
        }

        private void Toggle(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }
            
            switch (inputFieldLayoutGroup.activeInHierarchy)
            {
                case true:
                    LogManager.OnDebugLog(
                        "Turn off <b>Command Console</b>");
                    
                    GameManager.OnPlay(); 
                    inputFieldLayoutGroup.SetActive(false);
                    break;
                case false:
                    LogManager.OnDebugLog(
                        "Turn on <b>Command Console</b>");
                    
                    GameManager.OnPause();
                    inputFieldLayoutGroup.SetActive(true);
                    break;
            }
        }

        #region PROPERTIES API

        public Dictionary<string, ICommand> Commands { get; private set; }

        public string[] CommandNames => Commands.Keys.ToArray();

        #endregion
    }
}
