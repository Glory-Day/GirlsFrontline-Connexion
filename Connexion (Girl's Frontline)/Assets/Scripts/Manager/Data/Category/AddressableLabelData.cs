#region NAMESPACE API

using System;

#endregion

namespace Manager.Data.Category
{
    #region DATA CLASS API

    [Serializable]
    public class AudioAsset
    {
        public string[] labels;
    }

    [Serializable]
    public class PrefabAsset
    {
        public string[] labels;
    }

    #endregion

    [Serializable]
    public class AddressableLabelData
    {
        public AudioAsset  audioAsset;
        public PrefabAsset prefabAsset;
    }
}
