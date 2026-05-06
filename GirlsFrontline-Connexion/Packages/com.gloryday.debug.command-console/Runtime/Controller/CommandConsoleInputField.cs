using System;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

namespace GloryDay.Debug
{
    public class CommandConsoleInputField : MonoBehaviour
    {
        #region COMPONENT FIELD API

        private TMP_InputField _tmpInputField;

        [Header("# Scroll View GameObject")]
        public GameObject scrollView;

        #endregion

        #region INPUT SYSTEM API

        // private CommandConsoleControls.InputFieldActions _controls;

        #endregion

        private StringBuilder _stringBuilder;

        private CommandLineButtonList _commandLineButtonList;
        private CommandExecutioner _commandExecutioner;

        // Awake is called when the script instance is being loaded
        private void Awake()
        {
            Console.LogProgress();

            _tmpInputField = GetComponent<TMP_InputField>();

            // _controls = new CommandConsoleControls.InputFieldActions();
        }

        private void OnEnable()
        {
            Console.LogProgress();

            // _controls.Enable();
            // _controls.Input.performed += Input;
        }

        // Start is called before the first frame update
        private void Start()
        {
            Console.LogProgress();

            var childTransform = scrollView.transform.GetChild(0).GetChild(0);
            _commandLineButtonList = new CommandLineButtonList(childTransform);
            //TODO: You must fix it. Get the command button resource and put it in the parameter.
            // _commandLineButtonList.Instantiate(InputCommandLine);
            _commandExecutioner = new CommandExecutioner();

            _stringBuilder = new StringBuilder();

            scrollView.SetActive(false);
        }

        private void OnDisable()
        {
            Console.LogProgress();

            // _controls.Input.performed -= Input;
            // _controls.Disable();
        }

        /// <summary>
        ///
        /// </summary>
        public void UpdateScrollView()
        {
            // Get text in input field of command console
            var commandLine = _tmpInputField.text;

            // Check input field of command console is empty
            if (commandLine.Length == 0)
            {
                scrollView.SetActive(false);
                return;
            }

            commandLine = GetLastCommandLine(commandLine);

            var count = 0;
            for (var i = 0; i < _commandLineButtonList.Count; i++)
            {
                var key = _commandLineButtonList.Keys[i];
                var substring = commandLine.Length <= key.Length ? key.Substring(0, commandLine.Length) : key;
                if (commandLine.Equals(substring))
                {
                    _commandLineButtonList[key].SetActive(true);
                    count++;
                }
                else
                {
                    _commandLineButtonList[key].SetActive(false);
                }
            }

            scrollView.SetActive(count > 0);
        }

        /// <returns>
        /// The last command line from the entire input command line
        /// </returns>
        /// <param name="commandLine"> Full input command line </param>
        private string GetLastCommandLine(string commandLine)
        {
            // Split command line to pipeline
            var commandLines = commandLine.Split(Separator.Pipeline, StringSplitOptions.RemoveEmptyEntries);

            var length = commandLines.Length;
            for (var i = 0; i < length; i++)
            {
                commandLines[i] = commandLines[i].Trim();
            }

            // Save the remainder of the command lines in order
            _stringBuilder.Clear();
            for (var i = 0; i < length - 1; i++)
            {
                _stringBuilder.Append(commandLines[i]);
                _stringBuilder.Append(" | ");
            }

            return commandLines[length - 1];
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="commandLine"></param>
        private void InputCommandLine(string commandLine)
        {
            _stringBuilder.Append(commandLine);

            commandLine = _stringBuilder.ToString();
            InputField = commandLine;

            _stringBuilder.Clear();
        }

        /// <summary>
        /// Called when an input event for an administrator command occurs
        /// </summary>
        /// <param name="context"> Information provided to action callbacks about what triggered an action </param>
        private void Input(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }

            _commandExecutioner.Receive(InputField);
            _commandExecutioner.Execute();

            _tmpInputField.text = string.Empty;
        }

        private string InputField
        {
            get => _tmpInputField.text;
            set => _tmpInputField.text = value;
        }
    }
}
