using System;

namespace Util.Data
{
    #region DATA CLASS API

    [Serializable]
    public class AudioAsset
    {
        public string[] labels;

        #region PROPERTIES API

        public string[] Labels => labels;

        #endregion
    }

    [Serializable]
    public class PrefabAsset
    {
        public string[] labels;

        #region PROPERTIES API

        public string[] Labels => labels;

        #endregion
    }

    #endregion

    [Serializable]
    public class AddressableLabelData
    {
        public AudioAsset  audioAsset;
        public PrefabAsset prefabAsset;

        #region PROPERTIES API

        public AudioAsset AudioAsset => audioAsset;

        public PrefabAsset PrefabAsset => prefabAsset;

        #endregion
    }
}
