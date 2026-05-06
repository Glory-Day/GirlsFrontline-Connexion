#if UNITY_EDITOR

using System.Collections.Generic;

namespace GloryDay.Addressables
{
    [System.Serializable]
    public class AddressableAssetMetadata
    {
        public List<string> Addresses { get; set; } = new List<string>();

        public Dictionary<string, Dictionary<string, List<string>>> Groups { get; set; } = new Dictionary<string, Dictionary<string, List<string>>>();
    }
}

#endif
