#region NAMESPACE API

using System;
using UnityEngine;

#endregion

namespace Manager.Data.Category
{
    #region DATA API

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

    [Serializable]
    public class UIPrefab
    {
        public string[] names;
    }

    #endregion

    [Serializable]
    public class AssetData
    {
        public BackgroundAudioClip backgroundAudioClip;
        public EffectAudioClip     effectAudioClip;
        public VoiceAudioClip      voiceAudioClip;
        public UIPrefab            uiPrefab;
    }
}
