namespace Util.Manager.Asset.Loader
{
    public interface IAssetLoader
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
        /// <returns></returns>
        bool Check();
    }
}
