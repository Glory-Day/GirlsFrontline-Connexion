using Util.Manager;
using Util.Log;

namespace Util.Asset
{
    public class AssetLoader
    {
        private readonly AudioAssetLoader  audioAssetLoader;
        private readonly PrefabAssetLoader prefabAssetLoader;

        public AssetLoader()
        {
            LogManager.LogCalled();
            
            audioAssetLoader = new AudioAssetLoader();
            prefabAssetLoader = new PrefabAssetLoader();
        }

        #region AUDIO ASSET METHOD API

        private void LoadAudioAssets()
        {
            LogManager.LogCalled();
            
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
            LogManager.LogCalled();
            
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

        #endregion

        #region PREFAB ASSET METHOD API

        private void LoadPrefabAssets()
        {
            LogManager.LogCalled();

            prefabAssetLoader.LoadUIPrefabAssets();
        }

        private void UnloadPrefabAssets()
        {
            LogManager.LogCalled();

            prefabAssetLoader.UnloadUIPrefabAssets();
        }

        private bool IsLoadedPrefabAssetsDone()
        {
            return prefabAssetLoader.IsLoadedUIPrefabAssetsDone();
        }

        #endregion

        #region STATIC METHOD API
        
        public void LoadAllAssets()
        {
            LogManager.LogCalled();

            LoadAudioAssets();
            LoadPrefabAssets();
        }

        public void UnloadAllAssets()
        {
            LogManager.LogCalled();

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
