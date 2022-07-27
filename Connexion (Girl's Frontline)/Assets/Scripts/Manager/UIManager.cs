#region NAMESPACE API

using System.Collections.Generic;

using UnityEngine;

using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Manager
{
    /// <summary>
    /// Manager that manages UI in <b>Game Application</b>
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

        /// <summary>
        /// Instantiate all UI prefabs
        /// </summary>
        public static void OnInstantiateAllUIPrefabs()
        {
            LogManager.OnDebugLog(typeof(UIManager), 
                $"OnInstantiateAllUIPrefabs()");
            
            InstantiateTransitionScreenPrefab();
            InstantiatePauseScreenPrefabs();
            
            LogManager.OnDebugLog(LabelType.Success, typeof(DataManager), 
                "<b>All UI Prefabs</b> are instantiated successfully");
        }

        /// <summary>
        /// Instantiate <b>Transition Screen</b>
        /// </summary>
        private static void InstantiateTransitionScreenPrefab()
        {
            LogManager.OnDebugLog(typeof(UIManager), 
                $"OnInstantiateTransitionScreenPrefab()");
            
            var gameObject = Instantiate(Instance.uiPrefabs[DataManager.ResourceData.uiPrefab.names[0]],
                Instance.transform, true);
            Instance.screenTransitionAnimation = gameObject.transform.GetChild(0).gameObject.GetComponent<Animation>();
            
            LogManager.OnDebugLog(LabelType.Success,typeof(UIManager), 
                $"Instantiate <b>Transition Screen Prefab</b> successfully");
        }

        /// <summary>
        /// Instantiate <b>Pause Screen</b>
        /// </summary>
        private static void InstantiatePauseScreenPrefabs()
        {
            LogManager.OnDebugLog(typeof(UIManager), 
                    $"InstantiatePauseScreenPrefabs()");
            
            var gameObject = Instantiate(Instance.uiPrefabs[DataManager.ResourceData.uiPrefab.names[1]], 
                Instance.transform, true);
            gameObject.SetActive(false);
            Instance.uiPrefabs[DataManager.ResourceData.uiPrefab.names[1]] = gameObject;

            LogManager.OnDebugLog(LabelType.Success,typeof(UIManager), 
                $"Instantiate <b>Pause Screen Prefab</b> successfully");
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
        /// Add UI prefabs in <b>List&lt;GameObject&gt;</b>
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
        /// Play screen transition animation
        /// </summary>
        public static void OnPlayScreenTransitionAnimation()
        {
            LogManager.OnDebugLog(typeof(UIManager), 
                $"OnPlayScreenTransitionAnimation()</b>");
            
            Instance.screenTransitionAnimation.Play();
            
            LogManager.OnDebugLog(LabelType.Event,typeof(UIManager), 
                $"Play <b>{Instance.screenTransitionAnimation.clip.name}</b>");
        }

        /// <summary>
        /// Enable <b>Pause Screen</b> for pause <b>Game Application</b>
        /// </summary>
        public static void OnEnablePauseScreen() =>
            Instance.uiPrefabs?[DataManager.ResourceData.uiPrefab.names[1]].SetActive(true);

        /// <summary>
        /// Disable <b>Pause Screen</b>
        /// </summary>
        public static void OnDisablePauseScreen() => 
            Instance.uiPrefabs?[DataManager.ResourceData.uiPrefab.names[1]].SetActive(false);

        /// <summary>
        /// Get Transform of <b>UIManager</b>
        /// </summary>
        /// <returns> Transform of <b>UIManager</b> </returns>
        public static Transform GetTransform() => Instance.transform;
    }
}
