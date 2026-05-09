using Spine.Unity;
using UnityEngine;

#pragma warning disable CS0618 // Type or member is obsolete

namespace GloryDay.SpineServices.Editor
{
    [ExecuteInEditMode]
    public class SpineAnimationPreviewer : MonoBehaviour
    {
        #region SERIALIZABLE FIELD API

        [SerializeField] 
        private SkeletonAnimation skeletonAnimation;
        
        [Header("Track")]
        [SerializeField, SpineAnimation] 
        public string animationName;
        
        [SerializeField, Range(0f, 1f)]
        private float timeline;
        
        #endregion

        #region CONSTANT FIELD API

        private const int TrackIndex = 0;

        #endregion

        private float _step;
        private float _duration;
        private string _animationNameCache;
        
        private Spine.TrackEntry _trackEntry;

        private void OnValidate()
        {
            if (skeletonAnimation is null )
            {
                skeletonAnimation = GetComponent<SkeletonAnimation>();
            }

            if (skeletonAnimation is null)
            {
                return;
            }

            if (string.IsNullOrEmpty(animationName))
            {
                skeletonAnimation.AnimationState.ClearTracks();
                skeletonAnimation.Skeleton.SetToSetupPose();
                skeletonAnimation.Update(0);
                skeletonAnimation.LateUpdate();

                timeline = 0.0f;
                
                _duration = 0f;
                _animationNameCache = animationName;
                
                return;
            }

            if (animationName != _animationNameCache)
            {
                _trackEntry = skeletonAnimation.AnimationState.SetAnimation(TrackIndex, animationName, false);
                timeline = 0.0f;
                _duration = _trackEntry.Animation.Duration / 2;
                _step = _duration / 1000f;
                _animationNameCache = animationName;
            }

            if (_trackEntry is null)
            {
                return;
            }

            if (skeletonAnimation.state == null)
            {
                return;
            }
            
            _trackEntry.TrackTime = timeline * _step * 1000f;
            skeletonAnimation.Update(timeline * _step * 1000f);
            skeletonAnimation.LateUpdate();
            skeletonAnimation.skeleton.Update(timeline * _step * 1000f);
        }
    }
}