#region NAMESPACE API

using System;

#endregion

namespace Manager.Data.Category
{
    #region DATA API

    /// <summary>
    /// Data format of audio asset label in <see cref="AddressableLabelData"/>
    /// </summary>
    [Serializable]
    public class AudioAsset
    {
        public string[] labels;
    }

    /// <summary>
    /// Data format of prefab asset label in <see cref="AddressableLabelData"/>
    /// </summary>
    [Serializable]
    public class PrefabAsset
    {
        public string[] labels;
    }

    #endregion

    /// <summary>
    /// Data format in <see cref="AddressableLabelData"/> Json file
    /// </summary>
    [Serializable]
    public class AddressableLabelData
    {
        public AudioAsset  audioAsset;
        public PrefabAsset prefabAsset;
    }
}
