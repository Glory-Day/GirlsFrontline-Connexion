using JetBrains.Annotations;
using Utility.Manager.Asset.Addressable;
using Utility.Manager.Asset.Reference;

namespace Utility.Manager
{
    [PublicAPI]
    public class AssetManager : Singleton<AssetManager>
    {
        private readonly AudioClipReference audioClipReference;
        private readonly PrefabReference    prefabReference;
        private readonly TextReference      textReference;
        
        private readonly IAddressables[] assetLoaders;
        
        private AssetManager()
        {
            LogManager.LogProgress();

            // Initialize assets
            audioClipReference = new AudioClipReference();
            prefabReference = new PrefabReference();
            textReference = new TextReference();
            
            // Initialize asset loaders
            assetLoaders = new IAddressables[] {
                                                  new AudioClipAddressables(),
                                                  new PrefabAddressables(),
                                                  new TextAddressables()
                                              };
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
            return Instance.IsAllAssetsLoadedDone;
        }
        
        #endregion
        
        #region STATIC PROPERTIES API
        
        public static AudioClipReference AudioClipReference => Instance.audioClipReference;
        public static PrefabReference PrefabReference => Instance.prefabReference;
        public static TextReference TextReference => Instance.textReference;
        
        #endregion
    }
}
