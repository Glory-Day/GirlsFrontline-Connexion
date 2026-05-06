using Core.Utility.Extension;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Video;

using Console = GloryDay.Debug.Console;

namespace Core.UI.Controller.VideoPlayer
{
    public class VideoPlayerBase : MonoBehaviour
    {
        #region SERIALIZABLE FIELD API

        [SerializeField]
        private VideoClip videoClip;

        [SerializeField]
        private RenderTexture renderTexture;

        #endregion

        private AudioSource _audioSource;

        private RawImage _texture;

        // Awake is called when the script instance is being loaded
        protected virtual void Awake()
        {
            Console.LogProgress();

            _texture = gameObject.GetOrAddComponent<RawImage>();
            _texture.texture = renderTexture;

            _audioSource = gameObject.GetOrAddComponent<AudioSource>();

            VideoPlayer = gameObject.GetOrAddComponent<UnityEngine.Video.VideoPlayer>();
            VideoPlayer.targetTexture = renderTexture;
            VideoPlayer.clip = videoClip;

            IsAudioPlayOnAwake = false;
            IsVideoPlayOnAwake = false;

            Pause();
        }

        /// <summary>
        /// Initiates playback engine preparation
        /// </summary>
        public void Prepare()
        {
            Console.LogProgress();

            StartCoroutine(PrepareVideoPlayer());
        }

        private IEnumerator PrepareVideoPlayer()
        {
            OnPreparingStarted?.Invoke();

            VideoPlayer.EnableAudioTrack(0, true);
            VideoPlayer.SetTargetAudioSource(0, _audioSource);
            VideoPlayer.Prepare();

            Console.LogMessage($"{VideoPlayer.clip.name} is preparing...");

            while (VideoPlayer.isPrepared == false)
            {
                yield return null;
            }

            OnPreparingCompleted?.Invoke();

            Console.LogSuccess($"{VideoPlayer.clip.name} is prepared");
        }

        /// <summary>
        /// Start playback.
        /// </summary>
        public void Play()
        {
            Console.LogProgress();

            OnPlayingStarted?.Invoke();

            VideoPlayer.Play();
            _audioSource.Play();

            OnPlayingCompleted?.Invoke();
        }

        /// <summary>
        /// Pause playback.
        /// </summary>
        public void Pause()
        {
            Console.LogProgress();

            OnPausingStarted?.Invoke();

            VideoPlayer.Pause();
            _audioSource.Pause();

            OnPausingCompleted?.Invoke();
        }

        public event Action OnPreparingStarted;

        public event Action OnPreparingCompleted;

        public event Action OnPlayingStarted;

        public event Action OnPlayingCompleted;

        public event Action OnPausingStarted;

        public event Action OnPausingCompleted;

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
