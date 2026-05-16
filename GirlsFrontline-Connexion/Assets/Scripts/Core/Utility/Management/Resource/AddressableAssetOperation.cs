using System.Collections.Generic;
using GloryDay.Debug;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Core.Utility.Management.Resource
{
    public sealed class AddressableAssetOperation<T> where T : UnityEngine.Object
    {
        private readonly Dictionary<string, T> _container;

        // Addressables primary key of the asset to load.
        private readonly string _key;

        public  AddressableAssetOperation(string key, Dictionary<string, T> container)
        {
            _key = key;
            _container = container;
        }

        /// <summary>
        /// Callback invoked when the asset load operation completes.
        /// Stores the loaded asset into the container if the operation succeeded.
        /// </summary>
        /// <param name="handle">Handle of the completed asset load operation.</param>
        public void LoadAsset(AsyncOperationHandle<T> handle)
        {
            if (handle.Status != AsyncOperationStatus.Succeeded)
            {
                Console.LogError($"Unable to load the <b>{_key}</b>");

                return;
            }

            _container.Add(_key, handle.Result);
        }
    }
}
