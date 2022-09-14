#region NAMESPACE API

using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;
using Util.Command;
using Util.Manager;
using Util.Manager.Log;

#endregion

namespace Object.UI.Console.Controller
{
    public class InputField : MonoBehaviour
    {
        #region COMPONENT FIELD API

        private TMP_InputField inputField;

        #endregion

        private Dictionary<string, ICommand> commands;
        private StringBuilder                commandLineBuilder;

        // Awake is called when the script instance is being loaded
        private void Awake()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(InputField),
                "Awake()");
            
            var component = GetComponentInParent<CommandConsole>();
            commands = component.Commands;
        }

        // Start is called before the first frame update
        private void Start()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(InputField),
                "Start()");

            inputField = GetComponent<TMP_InputField>();
            commandLineBuilder = new StringBuilder();
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

        #region INPUT EVENT API
        
        public void OnExecute()
        {
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
                    LogManager.OnDebugLog(
                        Label.Error,
                        typeof(CommandConsole),
                        "Invalid <b>Input Command Line</b>");
                }

                inputField.text = string.Empty;
            }
        }
        
        #endregion
    }
}