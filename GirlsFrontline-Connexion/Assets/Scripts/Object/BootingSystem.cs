using System.Collections;
using GloryDay.Log;
using UI.Controller.Button;
using UI.Controller.VideoPlayer;
using UnityEngine;
using Utility.Manager;

namespace Object
{
    public class BootingSystem : MonoBehaviour
    {
        private IntroductionVideoPlayer _videoPlayer;
        private SkipVideoButton _button;
        
        private void Awake()
        {
            LogManager.LogProgress();

            // Initialize video player for playing introduction video.
            _videoPlayer = FindObjectOfType<IntroductionVideoPlayer>();
            
            // Initialize button to skip video.
            _button = FindObjectOfType<SkipVideoButton>();
            _button.gameObject.SetActive(false);
        }

        private void Start()
        {
            LogManager.LogProgress();
            
            // Set the video to loop. 
            _videoPlayer.IsVideoLoop = true;
            
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
            
            // Set volume values and whether to mute in user data.
            var sound = DataManager.UserData.Sound;
            SoundManager.SetBackgroundAudioVolume(sound[0].Volume);
            SoundManager.SetEffectAudioVolume(sound[1].Volume);
            SoundManager.SetVoiceAudioVolume(sound[2].Volume);
            SoundManager.IsBackgroundAudioMute = sound[0].IsMute;
            SoundManager.IsEffectAudioMute = sound[1].IsMute;
            SoundManager.IsVoiceAudioMute = sound[2].IsMute;
            
            LogManager.LogSuccess("<b>Sound Settings</b> is completed.");
            
            // Prepare to play the introduction video.
            _videoPlayer.Prepare();
            while (_videoPlayer.IsVideoPrepared == false)
            {
                yield return null;
            }
            
            LogManager.LogSuccess("<b>Introduction Video</b> is prepared.");
            
            // Play the introduction video when it's prepared done.
            _videoPlayer.Play();
            
            LogManager.LogMessage("<b>All Assets, Data, and Game Objects</b> are loading...");
            
            // Load all resources used by the application.
            ResourceManager.OnLoadAllResources();
            while (ResourceManager.IsAllResourcesLoadedDone == false)
            {
                yield return null;
            }
            
            // Load all data and instantiate all user interface game objects used by the application.
            DataManager.OnLoadAllData();

            LogManager.LogSuccess("<b>All Data, Assets and Game Objects</b> are loaded done.");
            
            ObjectManager.OnSpawn(ResourceManager.UIResource.TransitionScreen).SetActive(true);
            ObjectManager.OnSpawn(ResourceManager.UIResource.OptionScreen).SetActive(true);
            ObjectManager.OnSpawn(ResourceManager.UIResource.PauseScreen).SetActive(true);
            
            LogManager.LogSuccess("<b>All UI Game Objects</b> are instantiated completely.");
            
            // Unset the loop of the video and set the event called at the end of the video.
            _videoPlayer.IsVideoLoop = false;
            _videoPlayer.LoopPointReached += delegate { _button.OnClick.Invoke(); };

            // Activate the skip button
            _button.gameObject.SetActive(true);
        }
    }
}
