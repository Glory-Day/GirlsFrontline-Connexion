#region NAMESPACE API

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Manager;
using LabelType = Manager.Log.Label.LabelType;
using SceneName = Manager.SceneManager.SceneName;

#endregion

namespace Scene
{
    /// <summary>
    /// Controls the <see cref="VideoPlayer"/> in <b>Introduction Video Scene</b>
    /// </summary>
    public class IntroductionVideoUtility : MonoBehaviour
    {
        #region SERIALIZABLE FIELD

        [Header("# Skip Button")]
        [SerializeField]
        public Button skipButton;

        #endregion

        /// <summary>
        /// <see cref="VideoPlayer"/> playing introduction video
        /// </summary>
        private VideoPlayer videoPlayer;

        // Start is called before the first frame update
        private void Start()
        {
            LogManager.OnDebugLog(typeof(IntroductionVideoUtility),
                $"Start()");
            
            videoPlayer = GetComponent<VideoPlayer>();
            skipButton.gameObject.SetActive(false);

            StartCoroutine(LoadAllDataAndAssets());
        }

        /// <summary>
        /// Load all data and assets related running <b>Game Application</b>
        /// </summary>
        private IEnumerator LoadAllDataAndAssets()
        {
            DataManager.OnLoadAllData();
            AssetManager.OnLoadAllAssets();

            LogManager.OnDebugLog(LabelType.Event, typeof(IntroductionVideoUtility),
                $"<b>Waiting All Assets</b> is loaded");

            while(!AssetManager.IsLoadedAllAssetsDone()) yield return null;

            LogManager.OnDebugLog(LabelType.Success, typeof(IntroductionVideoUtility),
                "<b>All Data And Assets</b> are loaded successfully");

            // Unset the loop of the video and set the event called at the end of the video
            videoPlayer.isLooping = false;
            videoPlayer.loopPointReached += IsOver;
            
            UIManager.OnInstantiateAllUIPrefabs();

            // Activate the skip button
            skipButton.gameObject.SetActive(true);
        }

        /// <summary>
        /// <see cref="VideoPlayer"/> event at the end of the video
        /// </summary>
        /// <param name="player"> <see cref="VideoPlayer"/> in <b>Introduction Video Scene</b> </param>
        private static void IsOver(VideoPlayer player)
        {
            LogManager.OnDebugLog(LabelType.Event, typeof(IntroductionVideoUtility),
                "<b>Introduction Video</b> is over");
            
            SceneManager.OnLoadSceneByName(SceneName.MainScene);
        }

        #region BUTTON EVENT API

        /// <summary>
        /// <see cref="Button"/> event to skip video
        /// when clicked <see cref="skipButton"/> in <b>Introduction Video Scene</b>
        /// </summary>
        public void OnClickedSkipButton()
        {
            LogManager.OnDebugLog(LabelType.Event, typeof(IntroductionVideoUtility),
                "<b>Skip Button</b> is clicked");
            
            SceneManager.OnLoadSceneByName(SceneName.MainScene);
        }

        #endregion
    }
}
