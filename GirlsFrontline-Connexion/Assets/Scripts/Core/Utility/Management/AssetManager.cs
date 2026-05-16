using GloryDay.Debug;
using GloryDay.Utility;
using Core.Utility.Management.Resource;

namespace Core.Utility.Management
{
    public class AssetManager : Singleton<AssetManager>
    {
        private readonly IAssetLoader _loader;

        private AssetManager()
        {
            Console.LogProgress();

            _loader = new AddressableAssetLoader(Asset_Internal);
        }

        private void Load_Internal()
        {
            Console.LogProgress();

            _loader.Load();
        }

        private void Release_Internal()
        {
            Console.LogProgress();

            _loader.Release();
        }

        private bool IsLoadedDone_Internal => _loader.IsLoadedDone;

        private AddressableAssets Asset_Internal { get; } = new AddressableAssets();

        #region STATIC METHOD API

        /// <summary>
        /// Loads all the resources that compose the application.
        /// </summary>
        public static void Load()
        {
            Console.LogProgress();

            Instance.Load_Internal();
        }

        /// <summary>
        /// Unload all loaded resources inside the application.
        /// </summary>
        public static void Release()
        {
            Console.LogProgress();

            Instance.Release_Internal();
        }

        #endregion

        #region STATIC PROPERTIES API

        public static AddressableAssets Asset => Instance.Asset_Internal;

        public static bool IsLoadedDone => Instance.IsLoadedDone_Internal;

        #endregion
    }
}
