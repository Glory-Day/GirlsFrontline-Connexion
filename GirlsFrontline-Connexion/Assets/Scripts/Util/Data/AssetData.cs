#region NAMESPACE API

using System;

#endregion

namespace Util.Data
{
    #region DATA CLASS API

    [Serializable]
    public class BackgroundAudioClip
    {
        public string[] names;

        #region PROPERTIES API

        public string[] Names => names;

        #endregion
    }

    [Serializable]
    public class EffectAudioClip
    {
        public string[] names;

        #region PROPERTIES API

        public string[] Names => names;

        #endregion
    }

    [Serializable]
    public class VoiceAudioClip
    {
        public string[] names;

        #region PROPERTIES API

        public string[] Names => names;

        #endregion
    }

    [Serializable]
    public class UIPrefab
    {
        public string[] names;

        #region PROPERTIES API

        public string[] Names => names;

        #endregion
    }

    #endregion

    [Serializable]
    public class AssetData
    {
        public BackgroundAudioClip backgroundAudioClip;
        public EffectAudioClip     effectAudioClip;
        public VoiceAudioClip      voiceAudioClip;
        public UIPrefab            uiPrefab;

        #region PROPERTIES API

        public BackgroundAudioClip BackgroundAudioClip => backgroundAudioClip;

        public EffectAudioClip EffectAudioClip => effectAudioClip;

        public VoiceAudioClip VoiceAudioClip => voiceAudioClip;

        public UIPrefab UIPrefab => uiPrefab;

        #endregion
    }
}
