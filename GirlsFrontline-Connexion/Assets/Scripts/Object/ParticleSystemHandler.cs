using System.Collections.Generic;
using GloryDay.Log;
using UnityEngine;

namespace Object
{
    public class ParticleSystemHandler : MonoBehaviour
    {
        #region COMPONENT FIELD API

        private readonly List<ParticleSystem> _systems = new List<ParticleSystem>();

        #endregion

        private void Awake()
        {
            LogManager.LogProgress();
            
            var count = transform.childCount;
            for (var i = 0; i < count; i++)
            {
                var child = transform.GetChild(i);
                _systems.Add(child.GetComponent<ParticleSystem>());
            }
        }

        public void Emit(int index)
        {
            LogManager.LogProgress();
            
            _systems[index].Emit(1);
        }

        public void Emit(int start, int end)
        {
            LogManager.LogProgress();

            for (var i = start; i < end; i++)
            {
                _systems[i].Emit(1);
            }
        }

        public void Play(int index)
        {
            LogManager.LogProgress();
            
            _systems[index].Play();
        }

        public void Stop(int index)
        {
            LogManager.LogProgress();
            
            _systems[index].Stop();
        }

        public bool IsPlaying(int index) => _systems[index].isPlaying;
    }
}