﻿using UnityEngine;
using UnityEngine.Video;
using Utility.Manager;

namespace UI.Video
{
    public class SkippableVideoPlayer : MonoBehaviour
    {
        #region ENUMURATED TYPE API

        private enum ChildrenIndex
        {
            VideoPlayer = 1,
            SkipButton = 2
        }
        
        #endregion

        #region COMPONENT FIELD API

        protected VideoPlayer videoPlayer;

        #endregion
        
        protected GameObject skipButton;
        
        // Start is called before the first frame update
        protected virtual void Start()
        {
            LogManager.LogProgress();
            
            // Initialize component and child game object
            videoPlayer = transform.GetChild((int)ChildrenIndex.VideoPlayer).GetComponent<VideoPlayer>();
            skipButton = transform.GetChild((int)ChildrenIndex.SkipButton).gameObject;
            skipButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OnSkipped);
        }
        
        #region BUTTON EVENT API

        /// <summary>
        /// Invoke when skip a video that plays in <see cref="VideoPlayer"/>
        /// </summary>
        public void OnSkipped()
        {
            LogManager.LogMessage("<b>Video</b> is skipped");

            SceneManager.OnLoadNextScene();
        }

        #endregion
    }
}
