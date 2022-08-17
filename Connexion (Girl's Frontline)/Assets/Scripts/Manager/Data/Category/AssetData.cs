#region NAMESPACE API

using System;
using UnityEngine;

#endregion

namespace Manager.Data.Category
{
    #region DATA API

    /// <summary>
    /// Data format of background <see cref="AudioClip"/> asset in <see cref="AssetData"/>
    /// </summary>
    [Serializable]
    public class BackgroundAudioClip
    {
        public string[] names;
    }

    /// <summary>
    /// Data format of effect <see cref="AudioClip"/> asset in <see cref="AssetData"/>
    /// </summary>
    [Serializable]
    public class EffectAudioClip
    {
        public string[] names;
    }

    /// <summary>
    /// Data format of voice <see cref="AudioClip"/> asset in <see cref="AssetData"/>
    /// </summary>
    [Serializable]
    public class VoiceAudioClip
    {
        public string[] names;
    }

    /// <summary>
    /// Data Format of UI prefab asset in <see cref="AssetData"/>
    /// </summary>
    [Serializable]
    public class UIPrefab
    {
        public string[] names;
    }

    #endregion

    /// <summary>
    /// Data format in <see cref="AssetData"/> Json file
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
