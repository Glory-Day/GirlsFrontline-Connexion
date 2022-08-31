#region NAMESPACE API

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Manager;
using Object.UI.Console.Command;
using Label = Manager.Log.LogLabel.Label;

#endregion

namespace Object.UI.Console
{
    public class CommandConsole : MonoBehaviour
    {
        #region SERIALIZABLE FIELD

        [Serializable]
        public struct RecommendListView
        {
            public GameObject viewportLayoutGroup;
            public GameObject group;
        }
        
        [Serializable]
        public struct InputField
        {
            public TMP_InputField component;
            public GameObject     inputFieldLayoutGroup;
        }

        [Header("# Recommend List View Object")]
        [SerializeField]
        public RecommendListView recommendListView;

        [Header("# Recommend Button Object")]
        [SerializeField]
        public GameObject recommendButton;

        [Header("# Input Field")]
        [SerializeField]
        public InputField inputField;

        #endregion

        private Dictionary<string, ICommand> commands;
        private string[]                     commandNames;
        private List<GameObject>             recommendButtons;
        private List<int>                    matchedCommandNameIndexes;
        private StringBuilder                commandLineBuilder;

        private void Start()
        {
            recommendButtons = new List<GameObject>();
            matchedCommandNameIndexes = new List<int>();
            commandLineBuilder = new StringBuilder();

            commandNames = CommandName.Names;
            var commandList = new ICommand[]
                              {
                                  new LoadAllDataCommand(),               new LoadAllAssetsCommand(),
                                  new UnloadAllAssetsCommand(),           new IsLoadedAllAssetsDoneCommand(),
                                  new ChangeBackgroundAudioClipCommand(), new InstantiateAllUIPrefabsCommand(),
                                  new LoadMainScene(),                    new LoadSelectionScene(),
                                  new ApplicationQuitCommand(),           new ApplicationPlayCommand(),
                                  new ApplicationSetUpCommand()
                              };

            commands = new Dictionary<string, ICommand>();
            for (var i = 0; i < CommandNamesLength; i++)
            {
                var instantiated = Instantiate(recommendButton, recommendListView.group.transform);

                var j = i;
                instantiated.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnClicked(commandNames[j]));
                instantiated.GetComponentInChildren<TMP_Text>().text = commandNames[i];
                instantiated.SetActive(false);
                
                recommendButtons.Add(instantiated);
                commands.Add(commandNames[i], commandList[i]);
            }
        }

        private void ResetMatchedCommandNameIndexes()
        {
            matchedCommandNameIndexes.Clear();
            
            var lastInputCommand = InputCommands.Last();
            var lastInputCommandLength = lastInputCommand.Length;
            for (var i = 0; i < CommandNamesLength; i++)
            {
                if (lastInputCommandLength != 0 &&
                    commandNames[i].Length >= lastInputCommandLength &&
                    commandNames[i].Substring(0, lastInputCommandLength).Equals(lastInputCommand))
                {
                    matchedCommandNameIndexes.Add(i);
                }
            }
        }

        #region BUTTON EVENT API

        private void OnClicked(string commandName)
        {
            commandLineBuilder.Append(inputField.component.text);
            
            var index = InputCommands.Last().Length;
            var commandNameLength = commandName.Length;
            for (var i = index; i < commandNameLength; i++)
            {
                commandLineBuilder.Append(commandName[i]);
            }

            inputField.component.text = commandLineBuilder.ToString();
            commandLineBuilder.Clear();
        }

        #endregion

        #region INPUT EVENT API

        public void OnToggle(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }

            switch (inputField.inputFieldLayoutGroup.activeInHierarchy)
            {
                case true:
                    LogManager.OnDebugLog(
                        "Turn off <b>Command Console</b>");
                    
                    GameManager.OnPlay();
                    inputField.inputFieldLayoutGroup.SetActive(false);
                    break;
                case false:
                    LogManager.OnDebugLog(
                        "Turn on <b>Command Console</b>");
                    
                    GameManager.OnPause();
                    inputField.inputFieldLayoutGroup.SetActive(true);
                    break;
            }
        }

        public void OnInput(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }

            var inputCommands = InputCommands;
            var inputCommandsLength = inputCommands.Length;
            for (var i = 0; i < inputCommandsLength; i++)
            {
                if (commands.ContainsKey(inputCommands[i]))
                {
                    commands[inputCommands[i]].Execute();
                }
                else
                {
                    LogManager.OnDebugLog(
                        Label.Error,
                        typeof(CommandConsole),
                        "<b>Input Command</b> is wrong");
                }
            }

            inputField.component.text = string.Empty;
        }

        public void OnValueChanged()
        {
            ResetMatchedCommandNameIndexes();

            var matchedCommandNameIndexesCount = matchedCommandNameIndexes.Count;
            if (matchedCommandNameIndexesCount == 0)
            {
                recommendListView.viewportLayoutGroup.SetActive(false);
            }
            else
            {
                recommendListView.viewportLayoutGroup.SetActive(true);
                for (var i = 0; i < CommandNamesLength; i++)
                {
                    recommendButtons[i].SetActive(matchedCommandNameIndexes.Contains(i));
                }
            }
        }

        #endregion

        private int CommandNamesLength => commandNames.Length;
        
        private string[] InputCommands => 
            Regex.Split(Regex.Replace(inputField.component.text, @"\n|\r", ""), @" & ");
    }
}
