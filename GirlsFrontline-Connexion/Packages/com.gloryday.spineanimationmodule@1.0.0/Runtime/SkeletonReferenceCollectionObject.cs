using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace GloryDay.SpineServices
{
    [CreateAssetMenu(fileName = "Skeleton Reference Asset Collection", 
                     menuName = "Scriptable Object/Spine/Skeleton Reference Asset Collection")]
    public class SkeletonReferenceCollectionObject : ScriptableObject
    {
        [SerializeField] private List<AnimationReferenceAsset> animations = new List<AnimationReferenceAsset>();
        [SerializeField] private List<EventDataReferenceAsset> events     = new List<EventDataReferenceAsset>();

        public Spine.Animation GetAnimation(int index) => animations[index].Animation;

        public EventData GetEventData(int index) => events[index].EventData;
    }
}