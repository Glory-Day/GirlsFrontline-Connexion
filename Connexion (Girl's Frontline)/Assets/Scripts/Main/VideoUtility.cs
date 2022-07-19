using System.Collections;
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
        #region SERIALIZABLE FIELD

        [Header("# Skip Button")]
        [SerializeField]
        public Button skipButton;

        #endregion

        /// <summary>
        /// Video player playing introduction video
        /// </summary>
        private VideoPlayer videoPlayer;

        // Start is called before the first frame update
        private void Start()
        {
            videoPlayer = GetComponent<VideoPlayer>();
            skipButton.gameObject.SetActive(false);

            StartCoroutine(LoadAllDataAndResources());
        }

        /// <summary>
        /// Load all data and resources related running game application
        /// </summary>
        private IEnumerator LoadAllDataAndResources()
        {
            DataManager.OnInitializeAllData();
            ResourceManager.OnLoadAllResources();
            
            while (!ResourceManager.IsAllResourceLoaded()) yield return null;
            
            LogManager.OnDebugLog(LabelType.Success, typeof(VideoUtility), 
                "<b>All data and resources</b> are loaded");

            // Unset the loop of the video and set the event called at the end of the video
            videoPlayer.isLooping = false;
            videoPlayer.loopPointReached += IsOver;
            
            UIManager.OnInstantiateScreenTransition();
            
            // Activate the skip button
            skipButton.gameObject.SetActive(true);
        }

        /// <summary>
        /// Callback event at the end of the video
        /// </summary>
        /// <param name="player"> Video player in introduction video scene </param>
        private static void IsOver(VideoPlayer player)
        {
            LogManager.OnDebugLog(LabelType.Event, typeof(VideoUtility), 
                "<b>Introduction video</b> is over");
            
            SoundManager.OnInitializeBackgroundAudioMixer();
            SceneManager.OnLoadScene(SceneName.MainScene);
        }

        #region BUTTON EVENT API

        /// <summary>
        /// Button event to skip video when clicked in <b>Introduction Video Scene</b>
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
