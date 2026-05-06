using System.Collections.Generic;
using Core.Object.Map;
using GloryDay.Debug;
using UnityEngine;

namespace Core.Object.Map
{
    public class BackgroundAnimation : MonoBehaviour
    {
        private readonly List<IUVAnimation> _animations = new List<IUVAnimation>();

        private void Awake()
        {
            var count = transform.childCount;
            for (var i = 0; i < count; i++)
            {
                var component = transform.GetChild(i).GetComponent<StandardAlphaMaskAnimation>();
                
                _animations.Add(component);
            }
        }

        /// <summary>
        /// Play an animation of the map's background image.
        /// </summary>
        public void Play()
        {
            Console.LogProgress();

            var count = _animations.Count;
            for (var i = 0; i < count; i++)
            {
                _animations[i].Play();
            }
        }

        /// <summary>
        /// Pause an animation of the map's background image.
        /// </summary>
        public void Pause()
        {
            Console.LogProgress();
            
            var count = _animations.Count;
            for (var i = 0; i < count; i++)
            {
                _animations[i].Pause();
            }
        }

        /// <summary>
        /// Stop an animation of the map's background image.
        /// </summary>
        public void Stop()
        {
            Console.LogProgress();
            
            var count = _animations.Count;
            for (var i = 0; i < count; i++)
            {
                _animations[i].Stop();
            }
        }
    }
}