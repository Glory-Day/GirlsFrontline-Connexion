#region NAMESPACE API

using System;

#endregion

namespace Manager.Data.Category
{
    #region ASSET LABEL DATA API

    /// <summary>
    /// Audio asset label data format in <see cref="AddressableLabelData"/>
    /// </summary>
    [Serializable]
    public class AudioAsset
    {
        public string[] labels;
    }

    /// <summary>
    /// Prefab asset label data format in <see cref="AddressableLabelData"/>
    /// </summary>
    [Serializable]
    public class PrefabAsset
    {
        public string[] labels;
    }

    #endregion

    /// <summary>
    /// <b>Data Format</b> in <b>AddressableLabel.json</b>
    /// </summary>
    [Serializable]
    public class AddressableLabelData
    {
        public AudioAsset  audioAsset;
        public PrefabAsset prefabAsset;
    }
}
