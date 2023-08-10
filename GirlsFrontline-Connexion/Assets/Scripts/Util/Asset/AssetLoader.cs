using Util.Manager;

namespace Util.Asset
{
    public class AssetLoader
    {
        private readonly AudioAssetLoader  audioAssetLoader;
        private readonly PrefabAssetLoader prefabAssetLoader;

        public AssetLoader()
        {
            LogManager.LogProgress();
            
            audioAssetLoader = new AudioAssetLoader();
            prefabAssetLoader = new PrefabAssetLoader();
        }

        private void LoadAudioAssets()
        {
            LogManager.LogProgress();
            
            audioAssetLoader.LoadBackgroundAudioClipAssets();
        }
        
        //DEBUG: This code is not working yet
        /*
        private void LoadAudioAssets()
        {
            LogManager.OnDebugLog(typeof(AssetManager),
                $"LoadAudioAssets()");

            audioAssetLoader.LoadBackgroundAudioClipAssets();
            audioAssetLoader.LoadEffectAudioAssets();
            audioAssetLoader.LoadVoiceAudioAssets();
        }
        */
        
        private void UnloadAudioAssets()
        {
            LogManager.LogProgress();
            
            audioAssetLoader.UnloadBackgroundAudioClipAssets();
        }
        
        //DEBUG: This code is not working yet
        /*
        private void UnloadAudioAssets()
        {
            LogManager.OnDebugLog(typeof(AssetManager),
                $"UnloadAudioAssets()");

            audioAssetLoader.UnloadBackgroundAudioClipAssets();
            audioAssetLoader.UnloadEffectAudioClipAssets();
            audioAssetLoader.UnloadVoiceAudioClipAssets();
        }
        */
        
        private bool IsLoadedAudioAssetsDone()
        {
            return audioAssetLoader.IsLoadedBackgroundAudioClipAssetsDone();
        }

        //DEBUG: This code is not working yet
        /*
        private bool IsAudioAssetsLoaded()
        {
            return audioAssetLoader.IsBackgroundAudioClipAssetsLoaded() &&
                   audioAssetLoader.IsEffectAudioClipAssetsLoaded() &&
                   audioAssetLoader.IsVoiceAudioClipAssetsLoaded();
        }
        */

        private void LoadPrefabAssets()
        {
            LogManager.LogProgress();

            prefabAssetLoader.LoadUIPrefabAssets();
        }

        private void UnloadPrefabAssets()
        {
            LogManager.LogProgress();

            prefabAssetLoader.UnloadUIPrefabAssets();
        }

        private bool IsLoadedPrefabAssetsDone()
        {
            return prefabAssetLoader.IsLoadedUIPrefabAssetsDone();
        }

        #region STATIC METHOD API
        
        public void LoadAllAssets()
        {
            LogManager.LogProgress();

            LoadAudioAssets();
            LoadPrefabAssets();
        }

        public void UnloadAllAssets()
        {
            LogManager.LogProgress();

            UnloadAudioAssets();
            UnloadPrefabAssets();
        }

        public bool IsLoadedAllAssetsDone()
        {
            return IsLoadedAudioAssetsDone() && IsLoadedPrefabAssetsDone();
        }

        #endregion
    }
}
