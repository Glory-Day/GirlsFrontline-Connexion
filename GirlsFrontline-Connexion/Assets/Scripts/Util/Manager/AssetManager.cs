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
        
        private AssetManager()
        {
            LogManager.LogProgress();

            assetLoaders = new IAssetLoader[] {
                                        new AudioClipAssetLoader(),
                                        new PrefabAssetLoader()
                                    };

            audioClipAsset = new AudioClipAsset();
            prefabAsset = new PrefabAsset();
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

        private bool IsAllAudioClipsLoadedDone
        {
            get
            {
                var audioClipLoader = assetLoaders[0] as AudioClipAssetLoader;

                return audioClipLoader != null &&
                       audioClipLoader.Check();

                //TODO: This code is not working yet.
                // return audioClipLoader != null &&
                //       audioClipLoader.IsBackgroundAudioClipsLoadedDone &&
                //       audioClipLoader.IsEffectAudioClipsLoadedDone &&
                //       audioClipLoader.IsVoiceAudioClipsLoadedDone;
            }
        }

        private bool IsAllUIPrefabsLoadedDone
        {
            get
            {
                var prefabLoader = assetLoaders[1] as PrefabAssetLoader;

                return prefabLoader != null &&
                       prefabLoader.Check();
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

        #region STATIC API
        
        /// <summary>
        /// Load all assets for application
        /// </summary>
        public static void OnLoadAllAssets()
        {
            Instance.LoadAllAssets();
        }

        /// <summary>
        /// Unload all assets for application
        /// </summary>
        public static void OnUnloadAllAssets()
        {
            Instance.UnloadAllAssets();
        }
        
        public static bool CheckAllAudioClipsLoaded()
        {
            return Instance.IsAllAudioClipsLoadedDone;
        }
        
        public static bool CheckAllUIPrefabsLoaded()
        {
            return Instance.IsAllUIPrefabsLoadedDone;
        }

        public static bool CheckAllAssetsLoaded()
        {
            return Instance.IsAllAssetsLoadedDone;
        }
        
        public static AudioClipAsset AudioClipAsset => Instance.audioClipAsset;
        public static PrefabAsset PrefabAsset => Instance.prefabAsset;
        
        #endregion
    }
}
