using System;

namespace Manager.Data.Category
{
    #region Audio API

    [Serializable]
    public class AudioMixer
    {
        public string[] names;
    }

    [Serializable]
    public class BackgroundAudioClip
    {
        public string[] names;
    }
    
    [Serializable]
    public class EffectAudioClip
    {
        public string[] names;
    }
    
    [Serializable]
    public class VoiceAudioClip
    {
        public string[] names;
    }

    #endregion

    #region PREFAB API

    [Serializable]
    public class UIPrefab
    {
        public string[] names;
    }

    #endregion

    [Serializable]
    public class ResourceInformation
    {
        public AudioMixer audioMixer;
        public BackgroundAudioClip backgroundAudioClip;
        public EffectAudioClip effectAudioClip;
        public VoiceAudioClip voiceAudioClip;
        public UIPrefab uiPrefab;
    }
}
