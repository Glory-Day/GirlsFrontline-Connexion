#region NAMESPACE API

using System;

#endregion

namespace Manager.Data.Category
{
    #region AUDIO ASSET DATA API

    /// <summary>
    /// Background audio clip asset data format in <see cref="AssetData"/>
    /// </summary>
    [Serializable]
    public class BackgroundAudioClip
    {
        public string[] names;
    }

    /// <summary>
    /// Effect audio clip asset data format in <see cref="AssetData"/>
    /// </summary>
    [Serializable]
    public class EffectAudioClip
    {
        public string[] names;
    }

    /// <summary>
    /// Video audio clip asset data format in <see cref="AssetData"/>
    /// </summary>
    [Serializable]
    public class VoiceAudioClip
    {
        public string[] names;
    }

    #endregion

    #region PREFAB ASSET DATA API

    /// <summary>
    /// UI prefab asset data format in <see cref="AssetData"/>
    /// </summary>
    [Serializable]
    public class UIPrefab
    {
        public string[] names;
    }

    #endregion

    /// <summary>
    /// <b>Data Format</b> in <b>AssetData.json</b>
    /// </summary>
    [Serializable]
    public class AssetData
    {
        public BackgroundAudioClip backgroundAudioClip;
        public EffectAudioClip     effectAudioClip;
        public VoiceAudioClip      voiceAudioClip;
        public UIPrefab            uiPrefab;
    }
}
