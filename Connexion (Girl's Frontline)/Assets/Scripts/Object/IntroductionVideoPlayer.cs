#region NAMESPACE API

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Manager;
using LabelType = Manager.Log.Label.LabelType;
using SceneName = Manager.SceneManager.SceneName;

#endregion

namespace Object
{
    /// <summary>
    /// Controls the <see cref="VideoPlayer"/> in <b>Introduction Video Scene</b>
    /// </summary>
    public class IntroductionVideoPlayer : MonoBehaviour
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
            LogManager.OnDebugLog(
                typeof(IntroductionVideoPlayer),
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

            LogManager.OnDebugLog(
                LabelType.Event, 
                typeof(IntroductionVideoPlayer),
                $"<b>Waiting All Assets</b> is loaded");

            while(!AssetManager.IsLoadedAllAssetsDone()) yield return null;

            LogManager.OnDebugLog(
                LabelType.Success, 
                typeof(IntroductionVideoPlayer),
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
            LogManager.OnDebugLog(
                LabelType.Event, 
                typeof(IntroductionVideoPlayer),
                "<b>Introduction Video</b> is over");
            
            SceneManager.OnLoadSceneByName(SceneName.MainScene);
        }
    }
}
