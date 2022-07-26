#region NAMESPACE API

using System.Collections.Generic;
using System.Text.RegularExpressions;

using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

using Manager;
using LabelType = Manager.Log.Label.LabelType;

using UI.Console.Command;
using UI.Console.Command.Data;
using UI.Console.Command.Resource;
using UI.Console.Command.Sound;
using UI.Console.Command.UI;
using UI.Console.Command.Util;

#endregion

namespace UI.Console
{
    /// <summary>
    /// Command console for development <b>Game Application</b>
    /// </summary>
    /// TODO: Command consoles should not be used in the final build because it is used only for development
    public class CommandConsole : MonoBehaviour
    {
        #region SERIALIZABLE FIELD

        [Header("# Command Console GameObject")]
        [SerializeField] 
        public GameObject commandConsoleInputFieldObject;

        [Header("# Command Console Input Field Component")] 
        [SerializeField]
        public TMP_InputField commandConsoleInputField;

        #endregion

        private Dictionary<string, ICommand> commands;
        
        /// <summary>
        /// Check <b>Command Console</b> is enabled
        /// </summary>
        private bool isCommandConsoleEnabled;

        // Awake is called when the script instance is being loaded
        private void Awake()
        {
            transform.SetParent(UIManager.GetTransform());
            commandConsoleInputFieldObject.SetActive(false);
            isCommandConsoleEnabled = false;
        }

        // Start is called before the first frame update
        private void Start()
        {
            commands = new Dictionary<string, ICommand>
            {
                { CommandName.LoadAllDataCommand, new LoadAllDataCommand() },
                { CommandName.LoadAllResourcesCommand, new LoadAllResourceCommand() },
                { CommandName.UnloadAllResourcesCommand, new UnloadAllResourceCommand() },
                { CommandName.IsAllResourcesLoadedCommand, new IsLoadedAllResourcesDoneCommand() },
                { CommandName.InitializeBackgroundAudioMixer, new InitializeBackgroundAudioMixerCommand() },
                { CommandName.ChangeBackgroundAudioClip, new ChangeBackgroundAudioClipCommand() },
                { CommandName.InstantiateAllUIPrefabsCommand, new InstantiateAllUIPrefabsCommand() },
                { CommandName.ApplicationQuit, new ApplicationQuitCommand() }
            };
        }

        #region INPUT EVENT API

        /// <summary>
        /// Event that is turned on and off to use <b>Command Console</b>
        /// </summary>
        public void OnToggle(InputAction.CallbackContext context)
        {
            if (!context.performed) return;

            switch (isCommandConsoleEnabled)
            {
                case false:
                    LogManager.OnDebugLog(LabelType.Event, typeof(CommandConsole), 
                        $"Turn on <b>Command Console</b>");
                    
                    GameManager.OnPause();
                    commandConsoleInputFieldObject.SetActive(true);
                    isCommandConsoleEnabled = true;
                    break;
                case true:
                    LogManager.OnDebugLog(LabelType.Event, typeof(CommandConsole), 
                        $"Turn off <b>Command Console</b>");
                    
                    GameManager.OnPlay();
                    commandConsoleInputFieldObject.SetActive(false);
                    isCommandConsoleEnabled = false;
                    break;
            }
        }

        /// <summary>
        /// Event that input command with <b>Command Console</b>
        /// </summary>
        public void OnInput(InputAction.CallbackContext context)
        {
            if (!context.performed) return;

            // Get command console input text and clear input field in command console
            var inputCommand = commandConsoleInputField.text;
            inputCommand = Regex.Replace(inputCommand, @"\n|\r", "");
            commandConsoleInputField.text = string.Empty;
            
            // Split command if command has pipeline
            var inputCommands = Regex.Split(inputCommand, @" & ");
            var lenght = inputCommands.Length;

            // Execute commands sequentially
            for (var i = 0; i < lenght; i++)
            {
                if (!string.IsNullOrEmpty(inputCommands[i]))
                {
                    commands[inputCommands[i]].Execute();
                }
            }
        }

        #endregion
    }
}
