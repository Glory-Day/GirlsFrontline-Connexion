using System.Collections;
using Object.Manager;
using Util.Asset;
using Util.Manager;
using Util.Log;

namespace UI.Video
{
    public class IntroductionVideoPlayer : SkippableVideoPlayer
    {
        private AssetLoader assetLoader;
        
        protected override void Start()
        {
            base.Start();
         
            LogManager.OnDebugLog(
                Label.Called,
                typeof(IntroductionVideoPlayer),
                $"Start()");
            
            skipButton.SetActive(false);
            
            assetLoader = new AssetLoader();
            
            StartCoroutine(Loading());
        }
        
        private IEnumerator Loading()
        {
            LogManager.OnDebugLog(
                Label.Called, 
                typeof(IntroductionVideoPlayer),
                $"Loading()");
            
            DataManager.OnLoadAllData();
            assetLoader.LoadAllAssets();

            LogManager.OnDebugLog(
                Label.Event, 
                typeof(SkippableVideoPlayer),
                $"<b>Waiting All Assets</b> is loaded");

            while(!assetLoader.IsLoadedAllAssetsDone())
            {
                yield return null;
            }

            LogManager.OnDebugLog(
                Label.Success,
                typeof(SkippableVideoPlayer),
                "<b>All Data And Assets</b> are loaded");

            // Unset the loop of the video and set the event called at the end of the video
            videoPlayer.isLooping = false;
            videoPlayer.loopPointReached += delegate { OnSkipped(); };
            
            UIManager.OnInstantiateAllUIPrefabs();

            // Activate the skip button
            skipButton.SetActive(true);
        }
    }
}
