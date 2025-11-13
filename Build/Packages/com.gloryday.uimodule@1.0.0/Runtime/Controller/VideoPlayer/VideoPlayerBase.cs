using System.Collections;
using GloryDay.Debug.Log;
using GloryDay.Debug.Extensions;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Controller.VideoPlayer
{
    public class VideoPlayerBase : MonoBehaviour
    {
        #region SERIALIZABLE FIELD API
        
        [SerializeField] private VideoClip videoClip;
        [SerializeField] private RenderTexture renderTexture;
        
        #endregion
        
        #region COMPONENT FIELD API

        private AudioSource _audioSource;
        private RawImage _texture;

        #endregion

        // Awake is called when the script instance is being loaded
        protected virtual void Awake()
        {
            LogManager.LogProgress();
            
            _texture = gameObject.GetOrAddComponent<RawImage>();
            _texture.texture = renderTexture;
            
            _audioSource = gameObject.GetOrAddComponent<AudioSource>();
            
            VideoPlayer = gameObject.GetOrAddComponent<UnityEngine.Video.VideoPlayer>();
            VideoPlayer.targetTexture = renderTexture;
            VideoPlayer.clip = videoClip;
            
            IsAudioPlayOnAwake = false;
            IsVideoPlayOnAwake = false;
            
            PauseAudio();
        }

        /// <summary>
        /// Initiates playback engine preparation
        /// </summary>
        public void Prepare()
        {
            LogManager.LogProgress();

            StartCoroutine(PrepareVideoPlayer());
        }

        private IEnumerator PrepareVideoPlayer()
        {
            VideoPlayer.EnableAudioTrack(0, true);
            VideoPlayer.SetTargetAudioSource(0, _audioSource);
            VideoPlayer.Prepare();

            LogManager.LogMessage("Video is preparing...");
            
            while (VideoPlayer.isPrepared == false)
            {
                yield return null;
            }
            
            LogManager.LogSuccess("Video is prepared");
        }
        
        /// <summary>
        /// Starts playback
        /// </summary>
        public void Play()
        {
            LogManager.LogProgress();
            
            VideoPlayer.Play();
            _audioSource.Play();
        }

        /// <summary>
        /// Pauses playing the clip
        /// </summary>
        public void PauseAudio()
        {
            LogManager.LogProgress();
            
            _audioSource.Pause();
        }
        
        public UnityEngine.Video.VideoPlayer VideoPlayer { get; protected set; }
        
        /// <summary>
        /// If set to true, the audio source will automatically start playing on awake
        /// </summary>
        protected bool IsAudioPlayOnAwake
        {
            get => _audioSource.playOnAwake;
            set => _audioSource.playOnAwake = value;
        }
        
        /// <summary>
        /// Whether the content will start playing back as soon as the component awakes
        /// </summary>
        protected bool IsVideoPlayOnAwake
        {
            get => VideoPlayer.playOnAwake;
            set => VideoPlayer.playOnAwake = value;
        }

        /// <summary>
        /// Whether the video player has successfully prepared the content to be played
        /// </summary>
        public bool IsVideoPrepared => VideoPlayer.isPrepared;

        /// <summary>
        /// Determines whether the audio source restarts from the beginning when it reaches the end of the clip
        /// </summary>
        protected bool IsAudioLoop
        {
            get => _audioSource.loop;
            set => _audioSource.loop = value;
        }
        
        /// <summary>
        /// Determines whether the video player restarts from the beginning when it reaches the end of the clip
        /// </summary>
        public bool IsVideoLoop
        {
            get => VideoPlayer.isLooping;
            set => VideoPlayer.isLooping = value;
        }

        /// <summary>
        /// The target group to which the audio source should route its signal
        /// </summary>
        protected AudioMixerGroup OutputAudioMixerGroup
        {
            get => _audioSource.outputAudioMixerGroup;
            set => _audioSource.outputAudioMixerGroup = value;
        }
        
        /// <summary>
        /// Destination for the audio embedded in the video
        /// </summary>
        protected VideoAudioOutputMode VideoAudioOutputMode
        {
            get => VideoPlayer.audioOutputMode;
            set => VideoPlayer.audioOutputMode = value;
        }
        
        public event UnityEngine.Video.VideoPlayer.EventHandler LoopPointReached
        {
            add => VideoPlayer.loopPointReached += value;
            remove => VideoPlayer.loopPointReached -= value;
        }
    }
}