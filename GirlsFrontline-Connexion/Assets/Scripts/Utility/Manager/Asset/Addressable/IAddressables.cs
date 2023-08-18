namespace Utility.Manager.Asset.Addressable
{
    public interface IAddressables
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
        bool Check();
    }
}
