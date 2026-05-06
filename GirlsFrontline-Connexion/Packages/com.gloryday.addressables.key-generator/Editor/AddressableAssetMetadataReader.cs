#if UNITY_EDITOR

using System.Collections.Generic;
using UnityEditor.AddressableAssets;
using UnityEngine;

namespace GloryDay.Addressables
{
    public class AddressableAssetMetadataReader
    {
        private readonly HashSet<string> _defaults = new HashSet<string>()
        {
            "Default Local Group", "Built In Data", "EditorSceneList", "Resources"
        };

        public AddressableAssetMetadata Read()
        {
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            if (settings is null)
            {
                Debug.LogError("Addressable settings is not existed.");

                return null;
            }

            var addresses = new List<string>();
            var groups = new Dictionary<string, Dictionary<string, List<string>>>();

            // Read addressable asset group metadata.
            var count = settings.groups.Count;
            for (var index = 0; index < count; index++)
            {
                var group = settings.groups[index];
                var name = group.Name;
                var entries = group.entries;
                if (_defaults.Contains(name))
                {
                    continue;
                }

                groups.Add(name, new Dictionary<string, List<string>>());

                // Read addressable asset entries metadata in group.
                foreach (var entry in entries)
                {
                    var address = entry.address;
                    if (_defaults.Contains(address) == false)
                    {
                        addresses.Add(address);
                    }

                    foreach (var label in entry.labels)
                    {
                        if (groups[name].ContainsKey(label))
                        {
                            groups[name][label].Add(address);
                        }
                        else
                        {
                            groups[name].Add(label, new List<string> { address });
                        }
                    }
                }
            }

            return new AddressableAssetMetadata { Addresses = addresses, Groups = groups };
        }
    }
}

#endif
