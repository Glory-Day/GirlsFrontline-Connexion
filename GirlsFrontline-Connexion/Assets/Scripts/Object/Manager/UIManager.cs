using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using Object.UI;
using Utility.Manager;

namespace Object.Manager
{
    public class UIManager : Singleton<UIManager>
    {
        private Dictionary<string, GameObject> uiPrefabs;
        
        protected UIManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }
        
        // Start is called before the first frame update
        private void Start()
        {
            LogManager.LogProgress();

            Instance.uiPrefabs = new Dictionary<string, GameObject>();
        }

        #region INSTANTIATE METHOD API

        private void InstantiateTransitionScreenPrefab()
        {
            LogManager.LogProgress();

            var instantiatedObject = Instantiate(AssetManager.PrefabReference.UI[DataManager.PrefabData.UI.TransitionScreen],
                transform, true);
            
            var component = instantiatedObject.GetComponent<TransitionScreen>();
            SetTransitionDirectionToLeft = component.SetTransitionDirectionToLeft;
            SetTransitionDirectionToRight = component.SetTransitionDirectionToRight;
            PlayScreenTransition = component.PlayScreenTransition;
            
            LogManager.LogSuccess("<b>Transition Screen Prefab</b> is instantiated");
        }

        private void InstantiatePauseScreenPrefab()
        {
            LogManager.LogProgress();

            var instantiatedObject = Instantiate(AssetManager.PrefabReference.UI[DataManager.PrefabData.UI.PauseScreen],
                transform, true);
            instantiatedObject.SetActive(false);
            AssetManager.PrefabReference.UI[DataManager.PrefabData.UI.PauseScreen] = instantiatedObject;

            LogManager.LogSuccess("<b>Pause Screen Prefab</b> is instantiated");
        }

        private void InstantiateCommandConsolePrefab()
        {
            LogManager.LogProgress();
            
            var instantiatedObject = Instantiate(AssetManager.PrefabReference.UI[DataManager.PrefabData.UI.CommandConsole],
                transform, true);
            AssetManager.PrefabReference.UI[DataManager.PrefabData.UI.CommandConsole] = instantiatedObject;
            
            LogManager.LogSuccess("<b>Command Console Prefab</b> is instantiated");
        }

        private void InstantiateOptionScreenPrefab()
        {
            LogManager.LogProgress();

            var instantiatedObject = Instantiate(AssetManager.PrefabReference.UI[DataManager.PrefabData.UI.OptionScreen],
                transform, true);
            AssetManager.PrefabReference.UI[DataManager.PrefabData.UI.OptionScreen] = instantiatedObject;
            
            LogManager.LogSuccess("<b>Option Screen Prefab</b> is instantiated");
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
            LogManager.LogProgress();

            Instance.InstantiateTransitionScreenPrefab();
            Instance.InstantiatePauseScreenPrefab();
            Instance.InstantiateCommandConsolePrefab();
            Instance.InstantiateOptionScreenPrefab();

            LogManager.LogSuccess("<b>All UI Prefabs</b> are instantiated");
        }

        public static void OnEnablePauseScreen()
        {
            AssetManager.PrefabReference.UI?[DataManager.PrefabData.UI.PauseScreen].SetActive(true);
        }

        public static void OnDisablePauseScreen()
        {
            AssetManager.PrefabReference.UI?[DataManager.PrefabData.UI.PauseScreen].SetActive(false);
        }
        
        public static void OnPlayScreenTransitionToLeft()
        {
            LogManager.LogProgress();
            
            Instance.SetTransitionDirectionToLeft.Invoke();
            Instance.PlayScreenTransition.Invoke();
        }

        public static void OnPlayScreenTransitionToRight()
        {
            LogManager.LogProgress();
            
            Instance.SetTransitionDirectionToRight.Invoke();
            Instance.PlayScreenTransition.Invoke();
        }

        #endregion

        #region STATIC PROPERTIES API
        
        public static Dictionary<string, GameObject> UIPrefabs => AssetManager.PrefabReference.UI;

        public static GameObject PauseScreen
        {
            get => AssetManager.PrefabReference.UI[DataManager.PrefabData.UI.PauseScreen];
            set => AssetManager.PrefabReference.UI[DataManager.PrefabData.UI.PauseScreen] = value;
        }

        #endregion
    }
}
