using System.Collections;
using Object.Manager;
using Utility.Manager;

namespace UI.Video
{
    public class IntroductionVideoPlayer : SkippableVideoPlayer
    {
        protected override void Start()
        {
            base.Start();
         
            LogManager.LogProgress();
            
            skipButton.SetActive(false);
            
            StartCoroutine(Loading());
        }
        
        private IEnumerator Loading()
        {
            LogManager.LogProgress();
            
            AssetManager.OnLoadAllAssets();

            LogManager.LogMessage("<b>Waiting All Assets</b> is loaded");

            while(!AssetManager.CheckAllAssetsLoaded())
            {
                yield return null;
            }
            
            DataManager.OnLoadAllData();

            LogManager.LogSuccess("<b>All Data And Assets</b> are loaded");

            // Unset the loop of the video and set the event called at the end of the video
            videoPlayer.isLooping = false;
            videoPlayer.loopPointReached += delegate { OnSkipped(); };
            
            UIManager.OnInstantiateAllUIPrefabs();

            // Activate the skip button
            skipButton.SetActive(true);
        }
    }
}
