#region NAMESPACE API

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Manager;
using Label = Manager.Log.Label;

#endregion

namespace Object.UI
{
    public class IntroductionVideoPlayer : MonoBehaviour
    {
        #region SERIALIZABLE FIELD API

        [Header("# Skip Button")]
        [SerializeField]
        public Button skipButton;

        #endregion

        #region COMPONENT FIELD API

        private VideoPlayer videoPlayer;

        #endregion

        // Start is called before the first frame update
        private void Start()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(IntroductionVideoPlayer),
                $"Start()");
            
            videoPlayer = GetComponent<VideoPlayer>();
            skipButton.gameObject.SetActive(false);

            StartCoroutine(LoadAllDataAndAssets());
        }
        
        private IEnumerator LoadAllDataAndAssets()
        {
            DataManager.OnLoadAllData();
            AssetManager.OnLoadAllAssets();

            LogManager.OnDebugLog(
                Label.Event, 
                typeof(IntroductionVideoPlayer),
                $"<b>Waiting All Assets</b> is loaded");

            while(!AssetManager.IsLoadedAllAssetsDone()) yield return null;

            LogManager.OnDebugLog(
                Label.Success, 
                typeof(IntroductionVideoPlayer),
                "<b>All Data And Assets</b> are loaded");

            // Unset the loop of the video and set the event called at the end of the video
            videoPlayer.isLooping = false;
            videoPlayer.loopPointReached += IsOver;
            
            UIManager.OnInstantiateAllUIPrefabs();

            // Activate the skip button
            skipButton.gameObject.SetActive(true);
        }

        /// <summary>
        /// <see cref="VideoPlayer"/> event called at the end of the video
        /// </summary>
        /// <param name="player"> <see cref="VideoPlayer"/> in <b>Introduction Video Scene</b> </param>
        private static void IsOver(VideoPlayer player)
        {
            LogManager.OnDebugLog(
                Label.Event,
                typeof(IntroductionVideoPlayer),
                "<b>Introduction Video</b> is over");
            
            SceneManager.OnLoadSceneByLabel(Manager.Scene.Label.Main);
        }
    }
}
