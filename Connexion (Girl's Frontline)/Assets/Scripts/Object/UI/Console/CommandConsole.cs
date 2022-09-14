#region NAMESPACE API

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Util.Command;
using Util.Manager;
using Util.Manager.Log;

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
        private const string ChangeBackgroundAudioClip      = "OnChangeBackgroundAudioClip --CurrentScene";
        private const string InstantiateAllUIPrefabsCommand = "OnInstantiateAllUIPrefabs";
        private const string LoadMainScene                  = "OnLoadScene --Name Main";
        private const string ApplicationQuit                = "OnApplicationQuit";
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
                           { LoadAllDataCommand,             new LoadAllDataCommand() },
                           { ChangeBackgroundAudioClip,      new ChangeBackgroundAudioClipCommand() },
                           { InstantiateAllUIPrefabsCommand, new InstantiateAllUIPrefabsCommand() },
                           { LoadMainScene,                  new LoadMainScene() },
                           { ApplicationQuit,                new ApplicationQuitCommand() },
                           { ApplicationPlay,                new ApplicationPlayCommand() }
                       };
        }

        #region INPUT EVENT API

        public void OnToggle()
        {
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
