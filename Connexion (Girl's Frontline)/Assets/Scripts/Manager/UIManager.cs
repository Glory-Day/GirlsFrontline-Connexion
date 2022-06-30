using System.Collections.Generic;
using Manager.Log;
using UnityEngine;

namespace Manager
{
    public class UIManager : Singleton<UIManager>
    {
        private List<GameObject> uiPrefabs;

        private Animation screenTransitionAnimation;

        // Screen transition animation names
        private const string LeftScreenTransitionAnimation = "Left_Screen_Transition_Animation";
        private const string RightScreenTransitionAnimation = "Right_Screen_Transition_Animation";
        
        protected UIManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        /// <summary>
        /// Instantiate Screen transition UI object
        /// </summary>
        public static void OnInstantiateScreenTransition()
        {
            LogManager.OnDebugLog(typeof(UIManager), 
                $"OnInstantiateScreenTransition()");
            
            var gameObject = Instantiate(Instance.uiPrefabs[0], Instance.transform, true);
            Instance.screenTransitionAnimation = gameObject.transform.GetChild(0).gameObject.GetComponent<Animation>();
        }

        /// <summary>
        /// Initialize UI prefabs
        /// </summary>
        public static void OnInitializeUIPrefabs()
        {
            LogManager.OnDebugLog(typeof(UIManager), 
                $"OnInitializeUIPrefabs()");

            Instance.uiPrefabs = new List<GameObject>();
        }
        
        /// <summary>
        /// Add UI prefabs in <b>List&lt;GameObject&gt; uiPrefabs</b>
        /// </summary>
        /// <param name="gameObject"> UI Prefab </param>
        public static void AddUIPrefabs(GameObject gameObject) => 
            Instance.uiPrefabs.Add(gameObject);

        /// <summary>
        /// Set screen transition animation to left
        /// </summary>
        public static void SetLeftScreenTransitionAnimation()
        {
            LogManager.OnDebugLog(typeof(UIManager), 
                $"SetLeftScreenTransitionAnimation()");
            
            Instance.screenTransitionAnimation.clip =
                Instance.screenTransitionAnimation.GetClip(LeftScreenTransitionAnimation);
        }

        /// <summary>
        /// Set screen transition animation to right
        /// </summary>
        public static void SetRightScreenTransitionAnimation()
        {
            LogManager.OnDebugLog(typeof(UIManager), 
                $"SetLeftScreenTransitionAnimation()");
            
            Instance.screenTransitionAnimation.clip =
                Instance.screenTransitionAnimation.GetClip(RightScreenTransitionAnimation);
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
    }
}
