#region NAMESPACE API

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Manager;
using Label = Manager.Log.Label;

#endregion

namespace Object.UI.Console.Component
{
    public class Viewport : MonoBehaviour
    {
        #region SERIALIZABLE FIELD API

        [Header("# Recommend Button Prefab")]
        [SerializeField]
        private GameObject recommendButton;

        #endregion
        
        private string[]      commandNames;
        private GameObject[]  recommendButtons;
        private List<int>     matchedRecommendButtonIndexes;

        private void Awake()
        {
            LogManager.OnDebugLog(
                typeof(Viewport),
                "Awake()");
            
            Initialize();

            var root = transform.parent.parent;
            var component1 = root.GetComponentInChildren<InputField>();
            GetInputCommandsCallBack = component1.GetInputCommands;
            
            for (var i = 0; i < commandNames.Length; i++)
            {
                var instantiatedRecommendButton = Instantiate(recommendButton, transform.GetChild(0));
                var component2 = instantiatedRecommendButton.GetComponent<RecommendButton>();
                component2.CommandName = commandNames[i];
                component2.GetInputCommandsCallBack += component1.GetInputCommands;
                component2.SetInputFieldTextCallBack += component1.SetInputFieldText;
                instantiatedRecommendButton.SetActive(false);

                recommendButtons[i] = instantiatedRecommendButton;
            }
            
            component1.transform.parent.gameObject.SetActive(false);
            gameObject.SetActive(false);
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
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);

                for (var i = 0; i < commandNames.Length; i++)
                {
                    recommendButtons[i].SetActive(matchedRecommendButtonIndexes.Contains(i));
                }
            }
        }
        
        #region CALLBACK API

        private event Func<IEnumerable<string>> GetInputCommandsCallBack;

        #endregion

        #region INPUT EVENT API

        public void OnValueChanged()
        {
            UpdateViewport();
        }

        #endregion
    }
}
