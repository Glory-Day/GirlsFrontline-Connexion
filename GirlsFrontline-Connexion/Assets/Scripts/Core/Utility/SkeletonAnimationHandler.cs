using System;
using System.Collections.Generic;
using GloryDay.Debug;
using Spine;
using Spine.Unity;
using UnityEngine;
using AnimationState = Spine.AnimationState;

using Console = GloryDay.Debug.Console;

namespace GloryDay.SpineServices
{
    public class SkeletonAnimationHandler : MonoBehaviour
    {
        #region SERIALIZABLE FIELD API

        [SerializeField] 
        private SkeletonReferenceCollectionObject skeletonReferenceCollection;

        #endregion
        
        private SkeletonAnimation _skeletonAnimation;
        private SkeletonData _skeletonData;
        private AnimationState _animationState;

        private readonly List<AnimationState.TrackEntryEventDelegate> _events = 
            new List<AnimationState.TrackEntryEventDelegate>();
        private readonly Dictionary<AnimationEventType, List<AnimationState.TrackEntryDelegate>> _listeners =
            new Dictionary<AnimationEventType, List<AnimationState.TrackEntryDelegate>>
            {
                { AnimationEventType.Start, new List<AnimationState.TrackEntryDelegate>() },
                { AnimationEventType.Interrupt, new List<AnimationState.TrackEntryDelegate>() },
                { AnimationEventType.Complete, new List<AnimationState.TrackEntryDelegate>() },
                { AnimationEventType.Dispose, new List<AnimationState.TrackEntryDelegate>() },
                { AnimationEventType.End, new List<AnimationState.TrackEntryDelegate>() }
            };

        private bool _isInitialized;
        
        private float _trackTime;

        private void Awake()
        {
            Console.LogProgress();
            
            if (_isInitialized)
            {
                return;
            }
            
            Initialize();
        }

        public void Initialize()
        {
            Console.LogProgress();
            
            _skeletonAnimation = GetComponent<SkeletonAnimation>();
            _skeletonData = _skeletonAnimation.SkeletonDataAsset.GetSkeletonData(true);
            _animationState = _skeletonAnimation.AnimationState;
            
            _isInitialized = true;
        }

        public void ResetPose()
        {
            Console.LogProgress();
            
            _animationState.ClearTracks();
            Skeleton.SetToSetupPose();
        }

        /// <summary>
        /// Reset the alpha value of skeleton.
        /// </summary>
        public void ResetSkeletonAlpha()
        {
            Skeleton.A = 1f;
        }

        /// <summary>
        /// Plays the current animation for a track, discarding any queued animations.
        /// If the formerly current track entry was never applied to a skeleton, it is replaced.
        /// </summary>
        /// <param name="animationIndex"> Index number of animation in spine skeleton. </param>
        /// <param name="trackIndex"> Index number of animation track in spine skeleton. </param>
        /// <param name="isLoop">
        /// If true, the animation will repeat.
        /// If false it will not, instead its last frame is applied if played beyond its duration.
        /// In either case <see cref="TrackEntry.TrackEnd"/> determines when the track is cleared.
        /// </param>
        /// <returns>
        /// A track entry to allow further customization of animation playback.
        /// References to the track entry must not be kept after the <see cref="AnimationState.Dispose"/> event occurs.
        /// </returns>
        public TrackEntry Play(int animationIndex, int trackIndex = 0, bool isLoop = false)
        {
            var spineAnimation = skeletonReferenceCollection.GetAnimation(animationIndex);
            
            return Play(spineAnimation, trackIndex, isLoop);
        }

        /// <summary>
        /// Plays the current animation for a track, discarding any queued animations.
        /// If the formerly current track entry was never applied to a skeleton, it is replaced.
        /// </summary>
        /// <param name="spineAnimation"> animation in <see cref="AnimationState"/>. </param>
        /// <param name="trackIndex"> Index number of animation track in spine skeleton. </param>
        /// <param name="isLoop">
        /// If true, the animation will repeat.
        /// If false it will not, instead its last frame is applied if played beyond its duration.
        /// In either case <see cref="TrackEntry.TrackEnd"/> determines when the track is cleared.
        /// </param>
        /// <returns>
        /// A track entry to allow further customization of animation playback.
        /// References to the track entry must not be kept after the <see cref="AnimationState.Dispose"/> event occurs.
        /// </returns>
        private TrackEntry Play(Spine.Animation spineAnimation, int trackIndex = 0, bool isLoop = false)
        {
            TrackEntry trackEntry;

            try
            {
                if (HasAnimation(spineAnimation.Name) == false)
                {
                    throw new IndexOutOfRangeException(
                        "Spine animation state doesn't have a given animation name");
                }
                
                trackEntry = _animationState.SetAnimation(trackIndex, spineAnimation, isLoop);
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.LogError(exception.Message);

                trackEntry = null;
            }

            return trackEntry;
        }
        
        public TrackEntry AddAnimation(int animationIndex, 
                                       int trackIndex = 0, bool isLoop = false, float delay = 0.5f)
        {
            var spineAnimation = skeletonReferenceCollection.GetAnimation(animationIndex);

            return AddAnimation(spineAnimation, trackIndex, isLoop, delay);
        }

        private TrackEntry AddAnimation(Spine.Animation spineAnimation, 
                                        int trackIndex = 0, bool isLoop = false, float delay = 0.5f)
        {
            TrackEntry trackEntry;

            try
            {
                if (HasAnimation(spineAnimation.Name) == false)
                {
                    throw new IndexOutOfRangeException(
                        "Spine animation state doesn't have a given animation name");
                }

                trackEntry = _animationState.AddAnimation(trackIndex, spineAnimation, isLoop, delay);
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.LogError(exception.Message);

                trackEntry = null;
            }

            return trackEntry;
        }

        public void AddListener(AnimationEventType type, AnimationState.TrackEntryDelegate callback)
        {
            try
            {
                switch (type)
                {
                    case AnimationEventType.Start:
                        _animationState.Start += callback;
                        break;
                    case AnimationEventType.Interrupt:
                        _animationState.Interrupt += callback;
                        break;
                    case AnimationEventType.Complete:
                        _animationState.Complete += callback;
                        break;
                    case AnimationEventType.Dispose:
                        _animationState.Dispose += callback;
                        break;
                    case AnimationEventType.End:
                        _animationState.End += callback;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(
                            nameof(type), type, "Unsupported spine animation event argument.");
                }
                
                _listeners[type].Add(callback);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Console.LogError(exception.Message);
            }
        }
        
        public void AddEventListener(AnimationState.TrackEntryEventDelegate callback)
        {
            _animationState.Event += callback;
            _events.Add(callback);
        }
        
        public void RemoveListener(AnimationEventType type, AnimationState.TrackEntryDelegate callback)
        {
            try
            {
                switch (type)
                {
                    case AnimationEventType.Start:
                        _animationState.Start -= callback;
                        break;
                    case AnimationEventType.Interrupt:
                        _animationState.Interrupt -= callback;
                        break;
                    case AnimationEventType.Complete:
                        _animationState.Complete -= callback;
                        break;
                    case AnimationEventType.Dispose:
                        _animationState.Dispose -= callback;
                        break;
                    case AnimationEventType.End:
                        _animationState.End -= callback;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(
                            nameof(type), type, "Unsupported spine animation event argument.");
                }
                
                _listeners[type].Remove(callback);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Console.LogError(exception.Message);
            }
        }

        public void RemoveEventListener(AnimationState.TrackEntryEventDelegate callback)
        {
            _animationState.Event -= callback;
            _events.Remove(callback);
        }
        
        public void RemoveAllListeners(AnimationEventType type)
        {
            int count;
            switch (type)
            {
                case AnimationEventType.Start:
                {
                    count = _listeners[AnimationEventType.Start].Count;
                    
                    for (var i = 0; i < count; i++)
                    {
                        _animationState.Start -= _listeners[AnimationEventType.Start][i];
                    }
                    
                    break;
                }
                case AnimationEventType.Interrupt:
                {
                    count = _listeners[AnimationEventType.Interrupt].Count;
                    
                    for (var i = 0; i < count; i++)
                    {
                        _animationState.Interrupt -= _listeners[AnimationEventType.Interrupt][i];
                    }
                    
                    break;
                }
                case AnimationEventType.Complete:
                {
                    count = _listeners[AnimationEventType.Complete].Count;
                    
                    for (var i = 0; i < count; i++)
                    {
                        _animationState.Complete -= _listeners[AnimationEventType.Complete][i];
                    }
                    
                    break;
                }
                case AnimationEventType.Dispose:
                {
                    count = _listeners[AnimationEventType.Dispose].Count;
                    
                    for (var i = 0; i < count; i++)
                    {
                        _animationState.Dispose -= _listeners[AnimationEventType.Dispose][i];
                    }
                    
                    break;
                }
                case AnimationEventType.End:
                {
                    count = _listeners[AnimationEventType.End].Count;
                    
                    for (var i = 0; i < count; i++)
                    {
                        _animationState.End -= _listeners[AnimationEventType.End][i];
                    }
                    
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(type), type, "Unsupported spine animation event argument.");
            }
            
            _listeners[type].Clear();
        }

        public void RemoveAllEventListener()
        {
            var count = _events.Count;
            for (var i = 0; i < count; i++)
            {
                _animationState.Event -= _events[i];
            }
            
            _events.Clear();
        }

        private bool HasAnimation(string animationName) => _skeletonData.FindAnimation(animationName) is null == false;
        
        public bool IsPlaying(int animationIndex, int trackIndex) =>
            IsPlaying(skeletonReferenceCollection.GetAnimation(animationIndex), trackIndex);
        
        public bool IsPlaying(Spine.Animation spineAnimation, int trackIndex) =>
            _animationState.GetCurrent(trackIndex).Animation == spineAnimation;
        
        /// <param name="trackIndex"> Index number of animation track in spine skeleton. </param>
        /// <returns> Animation currently playing on the track. </returns>
        public Spine.Animation GetCurrentAnimation(int trackIndex) => _animationState.GetCurrent(trackIndex)?.Animation;
        
        public EventData GetEventData(int index) => skeletonReferenceCollection.GetEventData(index);

        public Skeleton Skeleton => _skeletonAnimation.Skeleton;
    }
}