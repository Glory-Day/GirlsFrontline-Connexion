using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

using Manager;

using LabelType = Manager.Log.Label.LabelType;
using SceneName = Manager.SceneManager.SceneName;

namespace Main
{
    /// <summary>
    /// Controls the video player in introduction video scene
    /// </summary>
    public class VideoUtility : MonoBehaviour
    {
        /// <summary>
        /// Button to skip the video player
        /// </summary>
        [Header("# Skip Button")]
        [SerializeField]
        public Button skipButton;

        private VideoPlayer videoPlayer;

        // Start is called before the first frame update
        private void Start()
        {
            videoPlayer = GetComponent<VideoPlayer>();
            skipButton.gameObject.SetActive(false);

            DataManager.OnInitializeSceneInformationData();
            DataManager.OnInitializeAddressableLabelData();
            
            ResourceManager.OnInitializeAudioAssets();
            ResourceManager.OnInitializePrefabAssets();
        }

        // Update is called once per frame
        private void Update()
        {
            if (!ResourceManager.IsAllResourceLoaded()) return;
            if (!videoPlayer.isLooping) return;

            LogManager.OnDebugLog(LabelType.Success, typeof(VideoUtility), 
                "<b>All asset resources</b> are loaded");

            // Unset the loop of the video and set the method called at the end of the video
            videoPlayer.isLooping = false;
            videoPlayer.loopPointReached += IsVideoOver;
            
            UIManager.OnInstantiateScreenTransition();
            
            // Activate the skip button
            skipButton.gameObject.SetActive(true);
        }
        
        /// <summary>
        /// Callback at the end of the video
        /// </summary>
        /// <param name="player"> video player in introduction video scene </param>
        private static void IsVideoOver(VideoPlayer player)
        {
            LogManager.OnDebugLog(LabelType.Event, typeof(VideoUtility), 
                "<b>Introduction video</b> is over");
            
            SoundManager.OnInitializeBackgroundAudioMixer();
            SceneManager.OnLoadScene(SceneName.MainScene);
        }

        #region BUTTON API

        /// <summary>
        /// Button event to skip video when clicked
        /// </summary>
        public void OnClickedSkipButton()
        {
            LogManager.OnDebugLog(LabelType.Event, typeof(VideoUtility), 
                "<b>Skip button</b> is clicked");

            SoundManager.OnInitializeBackgroundAudioMixer();
            SceneManager.OnLoadScene(SceneName.MainScene);
        }

        #endregion
    }
}
