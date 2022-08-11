#region NAMESPACE API

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using Manager.UI.Console.Command;

#endregion

namespace Manager.UI.Console
{
    /// <summary>
    /// Command console for development <b>Game Application</b>
    /// </summary>
    /// TODO: Command consoles should not be used in the final build because it is used only for administrator
    public class CommandConsole : MonoBehaviour
    {
        #region SERIALIZABLE FIELD

        [Serializable]
        public struct CommandConsoleObject
        {
            [SerializeField]
            public GameObject recommendCommandListView;
            [SerializeField]
            public GameObject commandInputField;
        }

        [Header("# Command Console Object")]
        [SerializeField]
        public CommandConsoleObject commandConsoleObject;

        [Header("# Command Input Field Component")]
        [SerializeField]
        public TMP_InputField commandInputFieldComponent;

        [Header("# Recommend Command List Viewport Object")]
        [SerializeField]
        public GameObject recommendCommandListViewportObject;

        [Header("# Recommend Command Button Object")]
        [SerializeField]
        public GameObject recommendCommendButtonObject;

        #endregion

        private Dictionary<string, ICommand> commands;

        private List<GameObject> recommendCommandButtons;
        private List<int>        matchedRecommendCommandButtonIndexes;

        private StringBuilder commandTextBuilder;

        // Start is called before the first frame update
        private void Start()
        {
            recommendCommandButtons = new List<GameObject>();
            matchedRecommendCommandButtonIndexes = new List<int>();
            commandTextBuilder = new StringBuilder();

            // Initialize command list with command name to key value
            commands = new Dictionary<string, ICommand>
                       {
                           {CommandName.LoadAllDataCommand, new LoadAllDataCommand()},
                           {CommandName.LoadAllAssetsCommand, new LoadAllAssetsCommand()},
                           {CommandName.UnloadAllAssetsCommand, new UnloadAllAssetsCommand()},
                           {CommandName.IsAllAssetsLoadedCommand, new IsLoadedAllResourcesDoneCommand()},
                           {CommandName.ChangeBackgroundAudioClip, new ChangeBackgroundAudioClipCommand()},
                           {CommandName.InstantiateAllUIPrefabsCommand, new InstantiateAllUIPrefabsCommand()},
                           {CommandName.LoadMainScene, new LoadMainScene()},
                           {CommandName.LoadSelectionScene, new LoadSelectionScene()},
                           {CommandName.ApplicationQuit, new ApplicationQuitCommand()},
                           {CommandName.ApplicationPlay, new ApplicationPlayCommand()},
                           {CommandName.ApplicationSetUp, new ApplicationSetUpCommand()}
                       };

            // Instantiate recommend command button object to recommend command list view
            var commandsCount = commands.Count;
            var commandNames = commands.Keys.ToArray();
            for (var i = 0; i < commandsCount; i++)
            {
                var recommendCommandButton = Instantiate(
                    recommendCommendButtonObject, recommendCommandListViewportObject.transform);

                var j = i;
                recommendCommandButton.GetComponent<Button>().onClick.AddListener(
                    () => OnClickedRecommendCommandButton(commandNames[j]));
                recommendCommandButton.GetComponentInChildren<TMP_Text>().text = commandNames[i];
                recommendCommandButton.SetActive(false);

                recommendCommandButtons.Add(recommendCommandButton);
            }
        }

        // Split and replace command text with a regular expression
        private string[] GetInputCommands()
        {
            return Regex.Split(Regex.Replace(commandInputFieldComponent.text, @"\n|\r", ""), @" & ");
        }

        #region BUTTON EVENT API

        /// <summary>
        /// Event that is display recommended commands in the command console input field 
        /// </summary>
        /// <param name="clickedRecommendCommandName"> Commend name of clicked recommend button </param>
        private void OnClickedRecommendCommandButton(string clickedRecommendCommandName)
        {
            var inputCommands = GetInputCommands();
            for (var i = 0; i < inputCommands.Length - 1; i++)
            {
                commandTextBuilder.Append(inputCommands[i]);
                commandTextBuilder.Append(" & ");
            }

            commandTextBuilder.Append(clickedRecommendCommandName);

            commandInputFieldComponent.text = commandTextBuilder.ToString();
            commandTextBuilder.Clear();
        }

        #endregion

        #region INPUT EVENT API

        /// <summary>
        /// Event that is turned on and off to use <b>Command Console</b>
        /// </summary>
        public void OnToggle(InputAction.CallbackContext context)
        {
            if (!context.performed) return;

            switch (commandConsoleObject.commandInputField.activeInHierarchy)
            {
                case false:
                    LogManager.OnDebugLog("Turn on <b>Command Console</b>");

                    GameManager.OnPause();
                    commandConsoleObject.commandInputField.SetActive(true);
                    StartCoroutine(EnableRecommendCommands());
                    break;
                case true:
                    LogManager.OnDebugLog("Turn off <b>Command Console</b>");

                    GameManager.OnPlay();
                    commandInputFieldComponent.text = string.Empty;
                    commandConsoleObject.commandInputField.SetActive(false);
                    StopCoroutine(EnableRecommendCommands());
                    break;
            }
        }

        /// <summary>
        /// Event that input command with <b>Command Console</b>
        /// </summary>
        public void OnInput(InputAction.CallbackContext context)
        {
            if (!context.performed) return;

            // Get command console input text and split command if command has pipeline
            var inputCommands = GetInputCommands();

            // Execute commands sequentially
            for (var i = 0; i < inputCommands.Length; i++)
                if (commands.ContainsKey(inputCommands[i]))
                    commands[inputCommands[i]].Execute();

            // Clear input field in command console 
            commandInputFieldComponent.text = string.Empty;
        }

        #endregion

        /// <summary>
        /// Recommend command for administrator
        /// </summary>
        private IEnumerator EnableRecommendCommands()
        {
            var previewInputCommand = string.Empty;
            var commandNames = commands.Keys.ToArray();
            var commandNamesLength = commandNames.Length;

            while(true)
            {
                var inputCommands = GetInputCommands();
                var inputCommand = inputCommands[inputCommands.Length - 1];
                var inputCommandLength = inputCommand.Length;

                // Input command is empty
                if (inputCommandLength == 0)
                {
                    commandConsoleObject.recommendCommandListView.SetActive(false);

                    yield return null;

                    continue;
                }

                // Input command is the same as the previous input command
                if (!inputCommand.Equals(previewInputCommand))
                {
                    matchedRecommendCommandButtonIndexes.Clear();

                    // Disable all command buttons and find matched command in command buttons
                    for (var i = 0; i < commandNamesLength; i++)
                    {
                        recommendCommandButtons[i].SetActive(false);

                        if (commandNames[i].Length >= inputCommandLength &&
                            commandNames[i].Substring(0, inputCommandLength).Equals(inputCommand))
                            matchedRecommendCommandButtonIndexes.Add(i);
                    }

                    // Matched command button is not empty. Enable matched command button
                    if (matchedRecommendCommandButtonIndexes.Count != 0)
                    {
                        commandConsoleObject.recommendCommandListView.SetActive(true);

                        var commandButtonIndexesCount = matchedRecommendCommandButtonIndexes.Count;
                        for (var i = 0; i < commandButtonIndexesCount; i++)
                            recommendCommandButtons[matchedRecommendCommandButtonIndexes[i]].SetActive(true);
                    }
                    // Matched command button is empty
                    else if (matchedRecommendCommandButtonIndexes.Count == commandNamesLength)
                    {
                        commandConsoleObject.recommendCommandListView.SetActive(false);
                    }

                    // Save input command to preview input command
                    previewInputCommand = inputCommand;
                }

                yield return null;
            }
            // ReSharper disable once IteratorNeverReturns
        }
    }
}
