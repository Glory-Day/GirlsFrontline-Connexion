using JetBrains.Annotations;
using Utility.Manager.Asset;
using Utility.Manager.Asset.Addressable;
using Utility.Singleton;

namespace Utility.Manager
{
    [PublicAPI]
    public class AssetManager : NotMonoBehavioural<AssetManager>
    {
        private readonly AudioClipAssets audioClipAssets;
        private readonly PrefabAssets    prefabAssets;
        private readonly TextAssets      textAssets;
        
        private readonly IAddressables[] assetLoaders;
        
        private AssetManager()
        {
            LogManager.LogProgress();

            // Initialize assets
            audioClipAssets = new AudioClipAssets();
            prefabAssets = new PrefabAssets();
            textAssets = new TextAssets();
            
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
        
        public static AudioClipAssets AudioClipAssets => Instance.audioClipAssets;
        public static PrefabAssets PrefabAssets => Instance.prefabAssets;
        public static TextAssets TextAssets => Instance.textAssets;
        
        #endregion
    }
}
