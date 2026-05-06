using System.Collections.Generic;
using GloryDay.Debug;
using UnityEngine;

namespace Core.Object
{
    public class ParticleSystemHandler : MonoBehaviour
    {
        #region COMPONENT FIELD API

        private readonly List<ParticleSystem> _systems = new List<ParticleSystem>();

        #endregion

        private void Awake()
        {
            Console.LogProgress();

            var count = transform.childCount;
            for (var i = 0; i < count; i++)
            {
                var child = transform.GetChild(i);
                _systems.Add(child.GetComponent<ParticleSystem>());
            }
        }

        public void Emit(int index)
        {
            Console.LogProgress();

            _systems[index].Emit(1);
        }

        public void Emit(int start, int end)
        {
            Console.LogProgress();

            for (var i = start; i < end; i++)
            {
                _systems[i].Emit(1);
            }
        }

        public void Play(int index)
        {
            Console.LogProgress();

            _systems[index].Play();
        }

        public void Stop(int index)
        {
            Console.LogProgress();

            _systems[index].Stop();
        }

        public bool IsPlaying(int index) => _systems[index].isPlaying;
    }
}
