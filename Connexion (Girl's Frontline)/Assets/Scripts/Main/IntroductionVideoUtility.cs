#region NAMESPACE API

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Manager;
using LabelType = Manager.Log.Label.LabelType;
using SceneName = Manager.SceneManager.SceneName;

#endregion

namespace Main
{
    /// <summary>
    /// Controls the video player in <b>Introduction Video Scene</b>
    /// </summary>
    public class IntroductionVideoUtility : MonoBehaviour
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
            
            LogManager.OnInitializeLogBuilders();

            StartCoroutine(LoadAllDataAndResources());
        }

        /// <summary>
        /// Load all data and resources related running <b>Game Application</b>
        /// </summary>
        private IEnumerator LoadAllDataAndResources()
        {
            DataManager.OnLoadAllData();
            AssetManager.OnLoadAllResources();

            LogManager.OnDebugLog(LabelType.Event, typeof(IntroductionVideoUtility),
                $"<b>Waiting All Resources</b> is loaded");

            while(!AssetManager.IsLoadedAllAssetsDone()) yield return null;

            LogManager.OnDebugLog(LabelType.Success, typeof(IntroductionVideoUtility),
                "<b>All Data And Resources</b> are loaded successfully");

            // Unset the loop of the video and set the event called at the end of the video
            videoPlayer.isLooping = false;
            videoPlayer.loopPointReached += IsOver;

            UIManager.OnInstantiateAllUIPrefabs();

            // Activate the skip button
            skipButton.gameObject.SetActive(true);
        }

        /// <summary>
        /// Callback event at the end of the video
        /// </summary>
        /// <param name="player"> Video player in <b>Introduction Video Scene</b> </param>
        private static void IsOver(VideoPlayer player)
        {
            LogManager.OnDebugLog(LabelType.Event, typeof(IntroductionVideoUtility),
                "<b>Introduction Video</b> is over");

            SoundManager.OnInitializeBackgroundAudioMixer();
            SceneManager.OnLoadSceneByName(SceneName.MainScene);
        }

        #region BUTTON EVENT API

        /// <summary>
        /// Button event to skip video when clicked in <b>Introduction Video Scene</b>
        /// </summary>
        public void OnClickedSkipButton()
        {
            LogManager.OnDebugLog(LabelType.Event, typeof(IntroductionVideoUtility),
                "<b>Skip Button</b> is clicked");

            SoundManager.OnInitializeBackgroundAudioMixer();
            SceneManager.OnLoadSceneByName(SceneName.MainScene);
        }

        #endregion
    }
}
