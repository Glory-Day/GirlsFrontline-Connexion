using System.Collections;
using GloryDay.Log;
using UI.Controller.Button;
using UI.Controller.VideoPlayer;
using UnityEngine;
using Utility.Manager;
using Utility.Manager.UI;

namespace Object
{
    public class BootManager : MonoBehaviour
    {
        private SkippableVideoPlayer _videoPlayer;
        private IntroductionVideoSkipButton      _button;
        
        // Start is called before the first frame update.
        private void Start()
        {
            LogManager.LogProgress();

            // Find video player object and button object.
            _videoPlayer = FindObjectOfType<SkippableVideoPlayer>();
            _button = FindObjectOfType<IntroductionVideoSkipButton>();
            
            _videoPlayer.IsVideoLoop = true;
            _button.gameObject.SetActive(false);

            StartCoroutine(Booting());
        }
        
        /// <summary>
        /// Booting all assets, data, and objects for running application.
        /// </summary>
        private IEnumerator Booting()
        {
            LogManager.LogProgress();
            
            // Initialize user data stored in the local repository.
            DataManager.OnLoadUserData();
            SoundManager.OnInitializeSoundSettings();
            SoundManager.OnInitializeAudioSources();
            
            // Prepare to play the introduction video.
            _videoPlayer.Prepare();
            while (_videoPlayer.IsVideoPrepared == false)
            {
                yield return null;
            }
            
            // Play the introduction video when it's prepared done.
            _videoPlayer.Play();
            
            LogManager.LogMessage("<b>All Assets, Data, and Objects</b> are loading...");
            
            // Load all resources used by the application.
            ResourceManager.OnLoadAllResources();
            while (ResourceManager.IsAllResourcesLoadedDone == false)
            {
                yield return null;
            }
            
            // Load all data and instantiate all user interface game objects used by the application.
            DataManager.OnLoadAllData();
            UIManager.OnInstantiateAllUIObjects();

            LogManager.LogSuccess("<b>All Data, Assets and Objects</b> are loaded done");

            // Unset the loop of the video and set the event called at the end of the video.
            _videoPlayer.IsVideoLoop = false;
            _videoPlayer.VideoPlayer.loopPointReached += delegate { _button.OnClick.Invoke(); };

            // Activate the skip button
            _button.gameObject.SetActive(true);
        }

        /// <summary>
        /// Reboot all assets and data, objects to initialize the application.
        /// </summary>
        public static void Reboot()
        {
            LogManager.LogProgress();
            LogManager.LogMessage("<b>All Assets, Data and Objects</b> are reloading...");
            
            // Reset user data to initial values and load game start scene.
            DataManager.OnResetUserData();
            SceneManager.OnLoadSceneByIndex(1, TransitionMode.Slide);
            
            LogManager.LogSuccess("<b>All Data, Assets and Objects</b> are reloaded done");
        }
    }
}
