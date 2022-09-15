#region NAMESPACE API

using System;
using System.Collections.Generic;
using UnityEngine;
using Object.UI;
using Util.Manager;
using Util.Manager.Log;

#endregion

namespace Object.Manager
{
    public class UIManager : Singleton<UIManager>
    {
        private Dictionary<string, GameObject> uiPrefabs;
        
        protected UIManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }
        
        private void Start()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(UIManager),
                $"Start()");

            Instance.uiPrefabs = new Dictionary<string, GameObject>();
        }

        #region INSTANTIATE METHOD API

        private void InstantiateTransitionScreenPrefab()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(UIManager),
                $"OnInstantiateTransitionScreenPrefab()");

            var instantiatedObject = Instantiate(uiPrefabs[DataManager.AssetData.uiPrefab.names[0]],
                transform, true);
            
            var component = instantiatedObject.GetComponent<TransitionScreen>();
            SetTransitionDirectionToLeft = component.SetTransitionDirectionToLeft;
            SetTransitionDirectionToRight = component.SetTransitionDirectionToRight;
            PlayScreenTransition = component.PlayScreenTransition;
            
            LogManager.OnDebugLog(
                Label.Success, 
                typeof(UIManager),
                $"<b>Transition Screen Prefab</b> is instantiated");
        }

        private void InstantiatePauseScreenPrefab()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(UIManager),
                $"InstantiatePauseScreenPrefab()");

            var instantiatedObject = Instantiate(uiPrefabs[DataManager.AssetData.uiPrefab.names[1]],
                transform, true);
            instantiatedObject.SetActive(false);
            uiPrefabs[DataManager.AssetData.uiPrefab.names[1]] = instantiatedObject;

            LogManager.OnDebugLog(
                Label.Success, 
                typeof(UIManager),
                $"<b>Pause Screen Prefab</b> is instantiated");
        }

        private void InstantiateCommandConsolePrefab()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(UIManager),
                $"InstantiateCommandConsolePrefab()");
            
            var instantiatedObject = Instantiate(uiPrefabs[DataManager.AssetData.uiPrefab.names[2]],
                transform, true);
            uiPrefabs[DataManager.AssetData.uiPrefab.names[2]] = instantiatedObject;
            
            LogManager.OnDebugLog(
                Label.Success, 
                typeof(UIManager),
                $"<b>Command Console Prefab</b> is instantiated");
        }

        private void InstantiateOptionScreenPrefab()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(UIManager),
                "InstantiateOptionScreenPrefab()");

            var instantiatedObject = Instantiate(uiPrefabs[DataManager.AssetData.uiPrefab.names[3]],
                transform, true);
            uiPrefabs[DataManager.AssetData.uiPrefab.names[3]] = instantiatedObject;
            
            LogManager.OnDebugLog(
                Label.Success, 
                typeof(UIManager),
                $"<b>Option Screen Prefab</b> is instantiated");
        }

        #endregion

        #region CALLBACK API

        private event Action SetTransitionDirectionToLeft;
        private event Action SetTransitionDirectionToRight;
        private event Action PlayScreenTransition;

        #endregion

        #region STATIC METHOD API

        public static void OnInstantiateAllUIPrefabs()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(UIManager),
                $"OnInstantiateAllUIPrefabs()");

            Instance.InstantiateTransitionScreenPrefab();
            Instance.InstantiatePauseScreenPrefab();
            Instance.InstantiateCommandConsolePrefab();
            Instance.InstantiateOptionScreenPrefab();

            LogManager.OnDebugLog(
                Label.Success, 
                typeof(DataManager),
                "<b>All UI Prefabs</b> are instantiated");
        }

        public static void OnEnablePauseScreen()
        {
            Instance.uiPrefabs?[DataManager.AssetData.uiPrefab.names[1]].SetActive(true);
        }

        public static void OnDisablePauseScreen()
        {
            Instance.uiPrefabs?[DataManager.AssetData.uiPrefab.names[1]].SetActive(false);
        }
        
        public static void OnPlayScreenTransitionToLeft()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(UIManager),
                "OnPlayScreenTransitionToLeft()");
            
            Instance.SetTransitionDirectionToLeft.Invoke();
            Instance.PlayScreenTransition.Invoke();
        }

        public static void OnPlayScreenTransitionToRight()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(UIManager),
                "OnPlayScreenTransitionToRight()");
            
            Instance.SetTransitionDirectionToRight.Invoke();
            Instance.PlayScreenTransition.Invoke();
        }

        #endregion

        #region STATIC PROPERTIES API

        public static Dictionary<string, GameObject> UIPrefabs => Instance.uiPrefabs;

        public static GameObject PauseScreen
        {
            get => Instance.uiPrefabs[DataManager.AssetData.uiPrefab.names[1]];
            set => Instance.uiPrefabs[DataManager.AssetData.uiPrefab.names[1]] = value;
        }

        #endregion
    }
}
