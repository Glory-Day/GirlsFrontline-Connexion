namespace Utility.Manager.Resource.Addressable
{
    public interface IResourceLoader
    {
        /// <summary>
        /// Load assets using addressables
        /// </summary>
        void Load();
        
        /// <summary>
        /// Unload assets using addressables
        /// </summary>
        void Unload();
        
        /// <summary>
        /// Check assets is Loaded
        /// </summary>
        bool IsLoadedDone { get; }
    }
}