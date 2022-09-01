#region NAMESPACE API

using Manager.Asset;

#endregion

namespace Manager
{
    public class AssetManager : Singleton<AssetManager>
    {
        private AudioAssetLoader  audioAssetLoader;
        private PrefabAssetLoader prefabAssetLoader;

        protected AssetManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }
        
        public static void OnInitialize()
        {
            LogManager.OnDebugLog(
                typeof(AssetManager),
                $"OnInitialize()");

            Instance.audioAssetLoader  = new AudioAssetLoader();
            Instance.prefabAssetLoader = new PrefabAssetLoader();
        }

        #region AUDIO ASSET METHOD API

        private void LoadAudioAssets()
        {
            LogManager.OnDebugLog(
                typeof(AssetManager),
                $"LoadAudioAssets()");
            
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
            LogManager.OnDebugLog(
                typeof(AssetManager),
                $"UnloadAudioAssets()");
            
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
            LogManager.OnDebugLog(
                typeof(AssetManager),
                $"LoadPrefabAssets()");

            prefabAssetLoader.LoadUIPrefabAssets();
        }

        private void UnloadPrefabAssets()
        {
            LogManager.OnDebugLog(
                typeof(AssetManager),
                $"UnloadPrefabAssets()");

            prefabAssetLoader.UnloadUIPrefabAssets();
        }

        private bool IsLoadedPrefabAssetsDone()
        {
            return prefabAssetLoader.IsLoadedUIPrefabAssetsDone();
        }

        #endregion

        public static void OnLoadAllAssets()
        {
            LogManager.OnDebugLog(
                typeof(AssetManager),
                $"OnLoadAllAssets()");

            Instance.LoadAudioAssets();
            Instance.LoadPrefabAssets();
        }

        public static void OnUnloadAllAssets()
        {
            LogManager.OnDebugLog(
                typeof(AssetManager),
                $"OnUnloadAllAssets()");

            Instance.UnloadAudioAssets();
            Instance.UnloadPrefabAssets();
        }

        public static bool IsLoadedAllAssetsDone()
        {
            return Instance.IsLoadedAudioAssetsDone() && Instance.IsLoadedPrefabAssetsDone();
        }
    }
}
