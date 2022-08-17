#region NAMESPACE API

using UnityEngine;
using UnityEngine.Audio;

#endregion

namespace Manager.Sound
{
    public class AudioMixerData : MonoBehaviour
    {
        [Header("Master Audio Mixer")]
        [SerializeField]
        public AudioMixer masterAudioMixer;
        
        [Header("Background Audio Mixer Group")]
        [SerializeField]
        public AudioMixerGroup backgroundAudioMixerGroup;
        
        [Header("Effect Audio Mixer Group")]
        [SerializeField]
        public AudioMixerGroup effectAudioMixerGroup;
        
        [Header("Voice Audio Mixer Group")]
        [SerializeField]
        public AudioMixerGroup voiceAudioMixerGroup;
    }
}
