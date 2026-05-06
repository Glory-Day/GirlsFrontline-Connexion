#if UNITY_EDITOR

using GloryDay.Json.Serialization;
using System.IO;
using UnityEngine;

namespace GloryDay.Addressables
{
    public class AddressableAssetCacheRepository
    {
        #region CONSTANT FIELD API

        private const string CacheDataFilePath = "Addressables";
        private const string CacheDataFileName = "cache.json";

        #endregion

        public static AddressableAssetMetadata ReadCacheDataFromDisk()
        {
            var path = Path.Combine(Application.persistentDataPath, CacheDataFilePath);
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }

            path = Path.Combine(path, CacheDataFileName);
            if (File.Exists(path) == false)
            {
                JsonSerializer.Serialize(path, new AddressableAssetMetadata());
            }

            return JsonSerializer.Deserialize<AddressableAssetMetadata>(path);
        }

        public static void WriteCacheDataToDisk(AddressableAssetMetadata data)
        {
            var path = Path.Combine(Application.persistentDataPath, CacheDataFilePath);
            path = Path.Combine(path, CacheDataFileName);

            JsonSerializer.Serialize(path, data);
        }
    }
}

#endif
