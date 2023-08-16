namespace Util.Manager.Asset.Loader
{
    public interface ILoader
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
