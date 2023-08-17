using JetBrains.Annotations;
using Util.Manager.Asset;
using Util.Manager.Asset.Loader;

namespace Util.Manager
{
    [PublicAPI]
    public class AssetManager : Singleton<AssetManager>
    {
        private readonly IAssetLoader[] assetLoaders;
        
        private readonly AudioClipAsset audioClipAsset;
        private readonly PrefabAsset    prefabAsset;
        private readonly TextAsset      textAsset;
        
        private AssetManager()
        {
            LogManager.LogProgress();

            // Initialize asset loaders
            assetLoaders = new IAssetLoader[] {
                                        new AudioClipAssetLoader(),
                                        new PrefabAssetLoader(),
                                        new TextAssetLoader()
                                    };

            // Initialize assets
            audioClipAsset = new AudioClipAsset();
            prefabAsset = new PrefabAsset();
            textAsset = new TextAsset();
        }
        
        private void LoadAllAssets()
        {
            LogManager.LogProgress();
            
            var length = assetLoaders.Length;
            for (var i = 0; i < length; i++)
            {
                assetLoaders[i].Load();
            }
        }
        
        private void UnloadAllAssets()
        {
            LogManager.LogProgress();
            
            var length = assetLoaders.Length;
            for (var i = 0; i < length; i++)
            {
                assetLoaders[i].Unload();
            }
        }

        private bool IsAllAssetsLoadedDone
        {
            get
            {
                var length = assetLoaders.Length;
                for (var i = 0; i < length; i++)
                {
                    if (assetLoaders[i].Check() == false)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        #region STATIC METHOD API
        
        /// <summary>
        /// Load all assets for application
        /// </summary>
        public static void OnLoadAllAssets()
        {
            LogManager.LogProgress();
            
            Instance.LoadAllAssets();
        }

        /// <summary>
        /// Unload all assets for application
        /// </summary>
        public static void OnUnloadAllAssets()
        {
            LogManager.LogProgress();
            
            Instance.UnloadAllAssets();
        }

        /// <summary>
        /// Check all assets is loaded
        /// </summary>
        public static bool CheckAllAssetsLoaded()
        {
            LogManager.LogProgress();
            
            return Instance.IsAllAssetsLoadedDone;
        }
        
        #endregion
        
        #region STATIC PROPERTIES API
        
        public static AudioClipAsset AudioClipAsset => Instance.audioClipAsset;
        public static PrefabAsset PrefabAsset => Instance.prefabAsset;
        public static TextAsset TextAsset => Instance.textAsset;
        
        #endregion
    }
}
