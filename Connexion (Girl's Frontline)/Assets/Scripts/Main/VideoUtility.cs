using System.Collections;
using System.Collections.Generic;
using Manager.Resource;
using UnityEngine;
using UnityEngine.Video;

namespace Main
{
    public class VideoUtility : MonoBehaviour
    {
        private VideoPlayer videoPlayer;
        
        // Start is called before the first frame update
        private void Start()
        {
            videoPlayer = GetComponent<VideoPlayer>();
            
            ResourceManager.OnInitializeAudioAssets();
        }

        // Update is called once per frame
        private void Update()
        {
        
        }
    }
}
