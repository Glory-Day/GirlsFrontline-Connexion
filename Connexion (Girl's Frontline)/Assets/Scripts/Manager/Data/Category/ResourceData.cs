using System;

namespace Manager.Data.Category
{
    #region AUDIO DATA API

    /// <summary>
    /// Audio mixer data in <b>ResourceData</b> Json file
    /// </summary>
    [Serializable]
    public class AudioMixer
    {
        public string[] names;
    }

    /// <summary>
    /// Background audio clip data in <b>ResourceData</b> Json file
    /// </summary>
    [Serializable]
    public class BackgroundAudioClip
    {
        public string[] names;
    }
    
    /// <summary>
    /// Effect audio clip data in <b>ResourceData</b> Json file
    /// </summary>
    [Serializable]
    public class EffectAudioClip
    {
        public string[] names;
    }
    
    /// <summary>
    /// Video audio clip data in <b>ResourceData</b> Json file
    /// </summary>
    [Serializable]
    public class VoiceAudioClip
    {
        public string[] names;
    }

    #endregion

    #region PREFAB DATA API

    /// <summary>
    /// UI prefab data in <b>ResourceData</b> Json file
    /// </summary>
    [Serializable]
    public class UIPrefab
    {
        public string[] names;
    }

    #endregion

    /// <summary>
    /// Resource data in <b>ResourceData</b> Json file
    /// </summary>
    [Serializable]
    public class ResourceData
    {
        public AudioMixer audioMixer;
        public BackgroundAudioClip backgroundAudioClip;
        public EffectAudioClip effectAudioClip;
        public VoiceAudioClip voiceAudioClip;
        public UIPrefab uiPrefab;
    }
}
