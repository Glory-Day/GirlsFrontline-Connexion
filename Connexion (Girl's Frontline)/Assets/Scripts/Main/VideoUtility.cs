using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

using Manager;

using LabelType = Manager.Log.Console.Label.LabelType;
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

            DataManager.OnInitializeSceneInformationData();
            ResourceManager.OnInitializeAudioAssets();
        }

        // Update is called once per frame
        private void Update()
        {
            if (!videoPlayer.isLooping || !ResourceManager.IsAudioAssetsLoaded()) return;

            LogManager.OnDebugLog(LabelType.Success, typeof(VideoUtility), 
                "All audio assets are loaded");

            // Unset the loop of the video and set the method called at the end of the video
            videoPlayer.isLooping = false;
            videoPlayer.loopPointReached += IsVideoOver;
            
            // Activate the skip button
            skipButton.interactable = true;
        }
        
        /// <summary>
        /// Callback at the end of the video
        /// </summary>
        /// <param name="player"> video player in introduction video scene </param>
        private static void IsVideoOver(VideoPlayer player)
        {
            LogManager.OnDebugLog(LabelType.Event, typeof(VideoUtility), 
                "<b>Introduction video</b> is over");
            
            SceneManager.OnLoadScene(SceneName.MainScene);
        }

        #region BUTTON API

        /// <summary>
        /// Button event to skip video when clicked
        /// </summary>
        public void OnClickedSkipButton()
        {
            SceneManager.OnLoadScene(SceneName.MainScene);
        }

        #endregion
    }
}
