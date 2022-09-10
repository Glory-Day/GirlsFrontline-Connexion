#region NAMESPACE API

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using Manager;
using Util.Command;
using Label = Manager.Log.Label;

#endregion

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
        private const string LoadAllAssetsCommand           = "OnLoadAllAssets";
        private const string UnloadAllAssetsCommand         = "OnUnloadAllAssets";
        private const string IsAllAssetsLoadedCommand       = "IsLoadedAllAssetsDone";
        private const string ChangeBackgroundAudioClip      = "OnChangeBackgroundAudioClip --CurrentScene";
        private const string InstantiateAllUIPrefabsCommand = "OnInstantiateAllUIPrefabs";
        private const string LoadMainScene                  = "OnLoadScene --Name Main";
        private const string LoadSelectionScene             = "OnLoadScene --Name Selection";
        private const string ApplicationQuit                = "OnApplicationQuit";
        private const string ApplicationSetUp               = "OnApplicationSetUp";
        private const string ApplicationPlay                = "OnApplicationPlay";

        #endregion

        // Awake is called when the script instance is being loaded 
        private void Awake()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(CommandConsole), 
                "Awake()");
            
            Commands = new Dictionary<string, ICommand>
                       {
                           { LoadAllAssetsCommand,           new LoadAllAssetsCommand() },
                           { LoadAllDataCommand,             new LoadAllDataCommand() },
                           { UnloadAllAssetsCommand,         new UnloadAllAssetsCommand() },
                           { IsAllAssetsLoadedCommand,       new IsLoadedAllAssetsDoneCommand() },
                           { ChangeBackgroundAudioClip,      new ChangeBackgroundAudioClipCommand() },
                           { InstantiateAllUIPrefabsCommand, new InstantiateAllUIPrefabsCommand() },
                           { LoadMainScene,                  new LoadMainScene() },
                           { LoadSelectionScene,             new LoadSelectionScene() },
                           { ApplicationQuit,                new ApplicationQuitCommand() },
                           { ApplicationPlay,                new ApplicationPlayCommand() },
                           { ApplicationSetUp,               new ApplicationSetUpCommand() }
                       };
        }

        #region INPUT EVENT API

        public void OnToggle(InputAction.CallbackContext context)
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

        #endregion
        
        #region PROPERTIES API

        public Dictionary<string, ICommand> Commands { get; private set; }

        public string[] CommandNames => Commands.Keys.ToArray();

        #endregion
    }
}
