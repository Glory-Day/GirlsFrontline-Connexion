#region NAMESPACE API

using System;

#endregion

namespace Manager.Data.Category
{
    /// <summary>
    /// Addressable label data in <b>AddressableLabel.json</b>
    /// </summary>
    [Serializable]
    public class AddressableLabelData
    {
        public string[] audios;
        public string[] prefabs;
    }
}
