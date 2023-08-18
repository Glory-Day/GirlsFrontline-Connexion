using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using Utility.Command;
using Utility.Input;
using Utility.Manager;

namespace Object.UI.Console.Controller
{
    public class InputField : MonoBehaviour
    {
        #region COMPONENT FIELD API

        private TMP_InputField inputField;

        #endregion

        private ConsoleAction consoleAction;
        
        private Dictionary<string, ICommand> commands;
        private StringBuilder                commandLineBuilder;

        // Awake is called when the script instance is being loaded
        private void Awake()
        {
            LogManager.LogProgress();
            
            var component = GetComponentInParent<CommandConsole>();
            commands = component.Commands;

            consoleAction = new ConsoleAction();
        }

        // OnEnable is called when the object becomes enabled and active
        private void OnEnable()
        {
            LogManager.LogProgress();
            
            consoleAction.Enable();
        }

        // Start is called before the first frame update
        private void Start()
        {
            LogManager.LogProgress();

            inputField = GetComponent<TMP_InputField>();
            commandLineBuilder = new StringBuilder();

            consoleAction.CommandConsole.Execute.performed += Execute;
        }

        // OnDisable is called when the behaviour becomes disabled
        private void OnDisable()
        {
            LogManager.LogProgress();
            
            consoleAction.Disable();
        }

        public string[] GetInputCommands()
        {
            return Regex.Split(Regex.Replace(inputField.text, @"\n|\r", ""), @" & ");
        }

        public void SetInputFieldText(string text)
        {
            commandLineBuilder.Append(inputField.text);
            commandLineBuilder.Append(text);
            inputField.text = commandLineBuilder.ToString();
            commandLineBuilder.Clear();
        }

        private void Execute(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }
            
            var inputCommands = GetInputCommands();
            for (var i = 0; i < inputCommands.Length; i++)
            {
                var inputCommand = inputCommands[i];
                if (commands.ContainsKey(inputCommand))
                {
                    commands[inputCommand].Execute();
                }
                else
                {
                    LogManager.LogError("Invalid <b>Input Command Line</b>");
                }

                inputField.text = string.Empty;
            }
        }
    }
}