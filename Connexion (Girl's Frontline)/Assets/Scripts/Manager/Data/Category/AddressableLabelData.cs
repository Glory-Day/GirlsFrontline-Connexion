#region NAMESPACE API

using System;

#endregion

namespace Manager.Data.Category
{
    #region ASSET LABEL DATA API

    /// <summary>
    /// Audio asset label data in <b>AddressableLabel.json</b>
    /// </summary>
    [Serializable]
    public class AudioAsset
    {
        public string[] names;
    }

    /// <summary>
    /// Prefab asset label data in <b>AddressableLabel.json</b>
    /// </summary>
    [Serializable]
    public class PrefabAsset
    {
        public string[] names;
    }

    #endregion

    /// <summary>
    /// Addressable label data in <b>AddressableLabel.json</b>
    /// </summary>
    [Serializable]
    public class AddressableLabelData
    {
        public AudioAsset  audioAsset;
        public PrefabAsset prefabAsset;
    }
}
