using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace Core.Utility.Management.Resource
{
    public sealed class AddressableLocationOperation<T> where T : UnityEngine.Object
    {
        private readonly Dictionary<string, T> _container;
        private readonly List<AsyncOperationHandle> _handles;

        public AddressableLocationOperation(Dictionary<string, T> container, List<AsyncOperationHandle> handles)
        {
            _container = container;
            _handles = handles;
        }

        /// <summary>
        /// Iterates over the resolved locations and loads each asset in parallel.
        /// Each asset is stored in the container via <see cref="AddressableAssetOperation{T}"/> upon completion.
        /// </summary>
        /// <param name="locationHandle">Handle of the completed location load operation.</param>
        /// <returns>A task that completes when all asset load operations have finished.</returns>
        public async Task LoadLocationAsync(AsyncOperationHandle<IList<IResourceLocation>> locationHandle)
        {
            if (locationHandle.Status != AsyncOperationStatus.Succeeded)
            {
                return;
            }

            var tasks = new List<Task>();
            foreach (var location in locationHandle.Result)
            {
                // Creates an asset load handle based on the resolved location.
                var assetHandle = Addressables.LoadAssetAsync<T>(location);

                // Registers a completion callback bound to the primary key and container.
                var operation = new AddressableAssetOperation<T>(location.PrimaryKey, _container);
                assetHandle.Completed += operation.LoadAsset;

                _handles.Add(assetHandle);

                // Adds the task to the list for parallel awaiting.
                tasks.Add(assetHandle.Task);
            }

            // Waits until all asset load operations have completed.
            await Task.WhenAll(tasks);
        }
    }
}
