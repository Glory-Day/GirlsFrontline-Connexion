using System.Collections.Generic;
using System.Threading.Tasks;
using GloryDay.Debug;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace Core.Utility.Management.Resource
{
    public class AddressableAssetLoader : IAssetLoader
    {
        private readonly List<AsyncOperationHandle> _handles = new List<AsyncOperationHandle>();

        // Container that stores loaded assets.
        private readonly AddressableAssets _assets;

        public AddressableAssetLoader(AddressableAssets container)
        {
            _assets = container;
        }

        public async Task Load()
        {
            var label = SceneManager.CurrentSceneName;

            // Loads all assets required for the current scene in parallel, using the scene name as a label.
            await Task.WhenAll(
                LoadAudioAssetsAsync(label),
                LoadObjectAssetsAsync(label),
                LoadUIAssetsAsync(label));

            IsLoadedDone = true;

            Console.LogSuccess("All assets loaded completely");
        }

        private async Task LoadAudioAssetsAsync(string label)
        {
            await Task.WhenAll(
                AddHandleAsync(_assets.Audio.Background, new List<object> { AddressableAssetKeys.Label.Audio, AddressableAssetKeys.Label.Background, label }),
                AddHandleAsync(_assets.Audio.Effect, new List<object> { AddressableAssetKeys.Label.Audio, AddressableAssetKeys.Label.Effect, label }),
                AddHandleAsync(_assets.Audio.Voice, new List<object> { AddressableAssetKeys.Label.Audio, AddressableAssetKeys.Label.Voice, label }),
                AddHandleAsync(_assets.Audio.UI, new List<object> { AddressableAssetKeys.Label.Audio, AddressableAssetKeys.Label.UI, label }));
        }

        private async Task LoadObjectAssetsAsync(string label)
        {
            await Task.WhenAll(
                AddHandleAsync(_assets.Object.Character, new List<object> { AddressableAssetKeys.Label.Object, AddressableAssetKeys.Label.Character, label }),
                AddHandleAsync(_assets.Object.Item, new List<object> { AddressableAssetKeys.Label.Object, AddressableAssetKeys.Label.Item, label }),
                AddHandleAsync(_assets.Object.Weapon, new List<object> { AddressableAssetKeys.Label.Object, AddressableAssetKeys.Label.Weapon, label }));
        }

        private async Task LoadUIAssetsAsync(string label)
        {
            await Task.WhenAll(AddHandleAsync(
                _assets.UI, new List<object> { AddressableAssetKeys.Label.UI, label }));
        }

        /// <summary>
        /// Queries <see cref="IResourceLocation"/> list by label combination, then loads and stores each into the container.
        /// </summary>
        /// <param name="container">Type of asset to load.</param>
        /// <param name="keys">Container to store loaded assets, keys by primary key.</param>
        /// <typeparam name="T">Label combination used for intersection query.</typeparam>
        private async Task AddHandleAsync<T>(Dictionary<string, T> container, List<object> keys) where T : UnityEngine.Object
        {
            // Loads only location information, not the asset itself.
            var handle = Addressables.LoadResourceLocationsAsync(keys, Addressables.MergeMode.Intersection, typeof(T));

            _handles.Add(handle);

            await handle.Task;

            // Delegates actual asset loading and container storage based on location information.
            var operation = new AddressableLocationOperation<T>(container, _handles);

            await operation.LoadLocationAsync(handle);
        }

        public void Release()
        {
            // Releases all stored handles to unlead assets from memory.
            var count = _handles.Count;
            for (var i = 0; i < count; i++)
            {
                Addressables.Release(_handles[i]);
            }

            _handles.Clear();
        }

        public bool IsLoadedDone { get; private set; }
    }
}
