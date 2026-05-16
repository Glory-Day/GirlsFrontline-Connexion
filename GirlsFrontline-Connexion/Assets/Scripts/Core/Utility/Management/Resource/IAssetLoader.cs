using System.Threading.Tasks;

namespace Core.Utility.Management.Resource
{
    public interface IAssetLoader
    {
        /// <summary>
        /// Load assets using addressables.
        /// </summary>
        public Task Load();

        /// <summary>
        /// Release assets using addressables.
        /// </summary>
        public void Release();

        /// <summary>
        /// True when all assets have been successfully loaded.
        /// </summary>
        public bool IsLoadedDone { get; }
    }
}
