#region NAMESPACE API

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Manager;

#endregion

namespace Object.UI.Console.Component
{
    public class Viewport : MonoBehaviour
    {
        #region SERIALIZABLE FIELD API

        [Header("# Recommend Button Prefab")]
        [SerializeField]
        private GameObject recommendButton;

        [Header("# Recommend Layout Group Transform")]
        [SerializeField]
        private Transform recommendLayoutGroupTransform;

        #endregion

        private GameObject screen;
        
        private string[]      commandNames;
        private GameObject[]  recommendButtons;
        private List<int>     matchedRecommendButtonIndexes;

        // Awake is called when the script instance is being loaded
        private void Awake()
        {
            LogManager.OnDebugLog(
                typeof(Viewport),
                "Awake()");
            
            Initialize();
            
            var root = transform.parent;
            var component1 = root.GetComponentInChildren<InputField>();
            GetInputCommandsCallBack = component1.GetInputCommands;
            
            // Initialize recommend buttons
            for (var i = 0; i < commandNames.Length; i++)
            {
                var instantiatedRecommendButton = Instantiate(recommendButton, recommendLayoutGroupTransform);
                var component2 = instantiatedRecommendButton.GetComponent<RecommendButton>();
                component2.CommandName = commandNames[i];
                component2.GetInputCommandsCallBack += component1.GetInputCommands;
                component2.SetInputFieldTextCallBack += component1.SetInputFieldText;
                instantiatedRecommendButton.SetActive(false);

                recommendButtons[i] = instantiatedRecommendButton;
            }
            
            screen = transform.GetChild(0).gameObject;
            screen.SetActive(false);
            component1.transform.parent.gameObject.SetActive(false);
        }

        private void Initialize()
        {
            LogManager.OnDebugLog(
                typeof(Viewport),
                "Initialize()");

            var component = GetComponentInParent<CommandConsole>();
            commandNames = component.CommandNames;
            recommendButtons = new GameObject[commandNames.Length];
            matchedRecommendButtonIndexes = new List<int>();
        }

        private void ResetMatchedRecommendButtonIndexes()
        {
            if (GetInputCommandsCallBack == null)
            {
                return;
            }
            
            matchedRecommendButtonIndexes.Clear();

            var lastInputCommand = GetInputCommandsCallBack.Invoke().Last();
            var lastInputCommandLength = lastInputCommand.Length;

            for (var i = 0; i < commandNames.Length; i++)
            {
                if (lastInputCommandLength != 0 && 
                    commandNames[i].Length >= lastInputCommandLength &&
                    commandNames[i].Substring(0, lastInputCommandLength).Equals(lastInputCommand))
                {
                    matchedRecommendButtonIndexes.Add(i);
                }
            }
        }

        private void UpdateViewport()
        {
            ResetMatchedRecommendButtonIndexes();

            if (matchedRecommendButtonIndexes.Count == 0)
            {
                screen.SetActive(false);
            }
            else
            {
                screen.SetActive(true);

                for (var i = 0; i < commandNames.Length; i++)
                {
                    recommendButtons[i].SetActive(matchedRecommendButtonIndexes.Contains(i));
                }
            }
        }

        #region INPUT EVENT API

        public void OnValueChanged()
        {
            UpdateViewport();
        }

        #endregion
        
        #region CALLBACK API

        private event Func<IEnumerable<string>> GetInputCommandsCallBack;

        #endregion
    }
}
