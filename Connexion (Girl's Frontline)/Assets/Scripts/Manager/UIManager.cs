﻿#region NAMESPACE API

using System.Collections.Generic;
using UnityEngine;
using Label = Manager.Log.Label;

#endregion

namespace Manager
{
    public class UIManager : Singleton<UIManager>
    {
        #region CONSTANT FIELD API

        // Screen transition animation names
        private const string ScreenTransitionToLeftAnimation  = "Left Screen Transition Animation";
        private const string ScreenTransitionToRightAnimation = "Right Screen Transition Animation";

        #endregion

        private Dictionary<string, GameObject> uiPrefabs;
        private Animation                      screenTransitionAnimation;
        
        protected UIManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        #region INSTANTIATE METHOD API

        private void InstantiateTransitionScreenPrefab()
        {
            LogManager.OnDebugLog(
                typeof(UIManager),
                $"OnInstantiateTransitionScreenPrefab()");

            var instantiatedObject = Instantiate(uiPrefabs[DataManager.AssetData.uiPrefab.names[0]],
                transform, true);
            screenTransitionAnimation = instantiatedObject.transform.GetChild(0)
                                                          .gameObject.GetComponent<Animation>();

            LogManager.OnDebugLog(
                Label.Success, 
                typeof(UIManager),
                $"Instantiate <b>Transition Screen Prefab</b> successfully");
        }

        private void InstantiatePauseScreenPrefab()
        {
            LogManager.OnDebugLog(
                typeof(UIManager),
                $"InstantiatePauseScreenPrefab()");

            var instantiatedObject = Instantiate(uiPrefabs[DataManager.AssetData.uiPrefab.names[1]],
                transform, true);
            instantiatedObject.SetActive(false);
            uiPrefabs[DataManager.AssetData.uiPrefab.names[1]] = instantiatedObject;

            LogManager.OnDebugLog(
                Label.Success, 
                typeof(UIManager),
                $"Instantiate <b>Pause Screen Prefab</b> successfully");
        }

        private void InstantiateCommandConsolePrefab()
        {
            LogManager.OnDebugLog(
                typeof(UIManager),
                $"InstantiateCommandConsolePrefab()");
            
            var instantiatedObject = Instantiate(uiPrefabs[DataManager.AssetData.uiPrefab.names[2]],
                transform, true);
            uiPrefabs[DataManager.AssetData.uiPrefab.names[2]] = instantiatedObject;
            
            LogManager.OnDebugLog(
                Label.Success, 
                typeof(UIManager),
                $"Instantiate <b>Command Console Prefab</b> successfully");
        }

        #endregion

        #region STATIC METHOD API

        public static void OnInitialize()
        {
            LogManager.OnDebugLog(
                typeof(UIManager),
                $"OnInitialize()");

            Instance.uiPrefabs = new Dictionary<string, GameObject>();
        }

        public static void OnInstantiateAllUIPrefabs()
        {
            LogManager.OnDebugLog(
                typeof(UIManager),
                $"OnInstantiateAllUIPrefabs()");

            Instance.InstantiateTransitionScreenPrefab();
            Instance.InstantiatePauseScreenPrefab();
            Instance.InstantiateCommandConsolePrefab();

            LogManager.OnDebugLog(
                Label.Success, 
                typeof(DataManager),
                "<b>All UI Prefabs</b> are instantiated successfully");
        }
        
        public static void SetScreenTransitionDirectionToLeft()
        {
            LogManager.OnDebugLog(
                typeof(UIManager),
                $"SetScreenTransitionDirectionToLeft()");

            Instance.screenTransitionAnimation.clip =
                Instance.screenTransitionAnimation.GetClip(ScreenTransitionToLeftAnimation);
        }

        public static void SetScreenTransitionDirectionToRight()
        {
            LogManager.OnDebugLog(
                typeof(UIManager),
                $"SetScreenTransitionDirectionToRight()");

            Instance.screenTransitionAnimation.clip =
                Instance.screenTransitionAnimation.GetClip(ScreenTransitionToRightAnimation);
        }

        public static void OnPlayScreenTransitionAnimation()
        {
            LogManager.OnDebugLog(
                typeof(UIManager),
                $"OnPlayScreenTransitionAnimation()");

            Instance.screenTransitionAnimation.Play();

            LogManager.OnDebugLog(
                Label.Event, 
                typeof(UIManager),
                $"Play <b>{Instance.screenTransitionAnimation.clip.name}</b>");
        }

        public static void OnEnablePauseScreen()
        {
            Instance.uiPrefabs?[DataManager.AssetData.uiPrefab.names[1]].SetActive(true);
        }

        public static void OnDisablePauseScreen()
        {
            Instance.uiPrefabs?[DataManager.AssetData.uiPrefab.names[1]].SetActive(false);
        }

        #endregion

        #region STATIC PROPERTIES API

        public static Dictionary<string, GameObject> UIPrefabs => Instance.uiPrefabs;

        #endregion
    }
}
