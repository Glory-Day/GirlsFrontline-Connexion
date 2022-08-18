#region NAMESPACE API

using System;
using UnityEngine;
using UnityEngine.Audio;

#endregion

namespace Manager.Sound
{
    public class AudioMixerGroupData : MonoBehaviour
    {
        [Header("Master Audio Mixer Group")]
        [SerializeField]
        private AudioMixerGroup master;
        
        [Header("Background Audio Mixer Group")]
        [SerializeField]
        private AudioMixerGroup background;
        
        [Header("Effect Audio Mixer Group")]
        [SerializeField]
        private AudioMixerGroup effect;
        
        [Header("Voice Audio Mixer Group")]
        [SerializeField]
        private AudioMixerGroup voice;

        public AudioMixerGroup Master => master;

        public AudioMixerGroup Background => background;

        public AudioMixerGroup Effect => effect;

        public AudioMixerGroup Voice => voice;
    }
}
