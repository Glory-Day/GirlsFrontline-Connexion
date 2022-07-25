using System.Collections.Generic;

using UnityEngine;

using Manager.Log;

namespace Manager
{
    /// <summary>
    /// Manager that manages UI in the game
    /// </summary>
    public class UIManager : Singleton<UIManager>
    {
        private Dictionary<string, GameObject> uiPrefabs;

        private Animation screenTransitionAnimation;

        #region ANIMATION NAME API

        // Screen transition animation names
        private const string ScreenTransitionToLeftAnimation = "Screen_Transition_To_Left_Animation";
        private const string ScreenTransitionToRightAnimation = "Screen_Transition_To_Right_Animation";

        #endregion

        protected UIManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        public static void OnInstantiateAllUIPrefabs()
        {
            LogManager.OnDebugLog(typeof(UIManager), 
                $"OnInstantiateAllUIPrefabs()");
            
            InstantiateTransitionScreenPrefab();
            InstantiatePauseScreenPrefabs();
            
            LogManager.OnDebugLog(Label.LabelType.Success, typeof(DataManager), 
                "<b>All UI Prefabs</b> are instantiated");
        }

        /// <summary>
        /// Instantiate Transition Screen UI object
        /// </summary>
        private static void InstantiateTransitionScreenPrefab()
        {
            LogManager.OnDebugLog(Label.LabelType.Event,typeof(UIManager), 
                $"Instantiate <b>Transition Screen Prefab</b>");
            
            var gameObject = Instantiate(Instance.uiPrefabs[DataManager.ResourceData.uiPrefab.names[0]],
                Instance.transform, true);
            Instance.screenTransitionAnimation = gameObject.transform.GetChild(0).gameObject.GetComponent<Animation>();
            
            LogManager.OnDebugLog(Label.LabelType.Success,typeof(UIManager), 
                $"Instantiate <b>Transition Screen Prefab</b> completely");
        }

        private static void InstantiatePauseScreenPrefabs()
        {
            LogManager.OnDebugLog(Label.LabelType.Event,typeof(UIManager), 
                    $"Instantiate <b>Pause Screen Prefab</b>");
            
            var gameObject = Instantiate(Instance.uiPrefabs[DataManager.ResourceData.uiPrefab.names[1]], 
                Instance.transform, true);
            gameObject.SetActive(false);
            Instance.uiPrefabs[DataManager.ResourceData.uiPrefab.names[1]] = gameObject;

            LogManager.OnDebugLog(Label.LabelType.Success,typeof(UIManager), 
                $"Instantiate <b>Pause Screen Prefab</b> completely");
        }

        /// <summary>
        /// Initialize UI prefabs
        /// </summary>
        public static void OnInitializeUIPrefabs()
        {
            LogManager.OnDebugLog(typeof(UIManager), 
                $"OnInitializeUIPrefabs()");

            Instance.uiPrefabs = new Dictionary<string, GameObject>();
        }
        
        /// <summary>
        /// Add UI prefabs in <b>List&lt;GameObject&gt; uiPrefabs</b>
        /// </summary>
        /// <param name="key"> <b>string</b> type key value </param>
        /// <param name="gameObject"> UI Prefab </param>
        public static void AddUIPrefabs(string key, GameObject gameObject) => 
            Instance.uiPrefabs.Add(key, gameObject);

        /// <summary>
        /// Set screen transition animation to <b>LeftScreenTransitionAnimation</b>
        /// </summary>
        public static void SetScreenTransitionDirectionToLeft()
        {
            LogManager.OnDebugLog(typeof(UIManager), 
                $"SetScreenTransitionDirectionToLeft()");
            
            Instance.screenTransitionAnimation.clip =
                Instance.screenTransitionAnimation.GetClip(ScreenTransitionToLeftAnimation);
        }

        /// <summary>
        /// Set screen transition animation to <b>RightScreenTransitionAnimation</b>
        /// </summary>
        public static void SetScreenTransitionDirectionToRight()
        {
            LogManager.OnDebugLog(typeof(UIManager), 
                $"SetScreenTransitionDirectionToRight()");
            
            Instance.screenTransitionAnimation.clip =
                Instance.screenTransitionAnimation.GetClip(ScreenTransitionToRightAnimation);
        }

        /// <summary>
        /// Play screen transition animation to set
        /// </summary>
        public static void OnPlayScreenTransitionAnimation()
        {
            LogManager.OnDebugLog(Label.LabelType.Event,typeof(UIManager), 
                $"Play <b>{Instance.screenTransitionAnimation.clip.name}</b>");
            
            Instance.screenTransitionAnimation.Play();
        }

        public static void OnEnablePauseScreen() =>
            Instance.uiPrefabs[DataManager.ResourceData.uiPrefab.names[1]].SetActive(true);
        
        public static void OnDisablePauseScreen() =>
            Instance.uiPrefabs[DataManager.ResourceData.uiPrefab.names[1]].SetActive(false);

        public static Transform GetTransform() => Instance.transform;
    }
}
