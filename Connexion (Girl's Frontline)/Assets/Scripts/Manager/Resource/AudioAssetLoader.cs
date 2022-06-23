using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

using LabelType = Manager.Log.Console.Label.LabelType;

namespace Manager.Resource
{
    /// <summary>
    /// Audio asset loader with <b>Addressable</b>
    /// </summary>
    public static class AudioAssetLoader
    {
        private static AsyncOperationHandle<IList<AudioClip>> _backgroundAudioAssetHandle;
        private static AsyncOperationHandle<IList<AudioClip>> _effectAudioAssetHandle;
        private static AsyncOperationHandle<IList<AudioClip>> _voiceAudioAssetHandle;
        
        /// <summary>
        /// Load background audio assets
        /// </summary>
        public static void OnLoadBackgroundAudioAssets()
        {
            LogManager.OnDebugLog(typeof(ResourceManager), 
                $"Called OnLoadBackgroundAudioAssets()");

            void Callback(AudioClip loadedAudioAsset)
            {
                SoundManager.AddBackgroundAudioClip(loadedAudioAsset.name, loadedAudioAsset);
                
                LogManager.OnDebugLog(LabelType.Event, typeof(AudioAssetLoader),
                    $"{loadedAudioAsset.name} is loaded");
            }

            _backgroundAudioAssetHandle = Addressables.LoadAssetsAsync(DataManager.AudioAddressableLabel.audios[0],
                (Action<AudioClip>)Callback);
        }
        
        /// <summary>
        /// Load effect audio assets
        /// </summary>
        public static void OnLoadEffectAudioAssets()
        {
            LogManager.OnDebugLog(typeof(ResourceManager), 
                $"Called OnLoadEffectAudioAssets()");

            void Callback(AudioClip loadedAudioAsset)
            {
                SoundManager.AddEffectAudioClip(loadedAudioAsset.name, loadedAudioAsset);

                LogManager.OnDebugLog(LabelType.Success, typeof(AudioAssetLoader),
                    $"{loadedAudioAsset.name} is loaded");
            }

            _effectAudioAssetHandle = Addressables.LoadAssetsAsync(DataManager.AudioAddressableLabel.audios[1],
                (Action<AudioClip>)Callback);
        }
        
        /// <summary>
        /// Load voice audio assets
        /// </summary>
        public static void OnLoadVoiceAudioAssets()
        {
            LogManager.OnDebugLog(typeof(ResourceManager), 
                $"Called OnLoadVoiceAudioAssets()");

            void Callback(AudioClip loadedAudioAsset)
            {
                SoundManager.AddVoiceAudioClip(loadedAudioAsset.name, loadedAudioAsset);

                LogManager.OnDebugLog(LabelType.Success, typeof(AudioAssetLoader),
                    $"{loadedAudioAsset.name} is loaded");
            }

            _voiceAudioAssetHandle = Addressables.LoadAssetsAsync(DataManager.AudioAddressableLabel.audios[2],
                (Action<AudioClip>)Callback);
        }

        /// <summary>
        /// Unload background audio assets
        /// </summary>
        public static void OnUnloadBackgroundAudioAssets()
        {
            Addressables.Release(_backgroundAudioAssetHandle);
        }
        
        /// <summary>
        /// Unload effect audio assets
        /// </summary>
        public static void OnUnloadEffectAudioAssets()
        {
            Addressables.Release(_effectAudioAssetHandle);
        }
        
        /// <summary>
        /// Unload voice audio assets
        /// </summary>
        public static void OnUnloadVoiceAudioAssets()
        {
            Addressables.Release(_voiceAudioAssetHandle);
        }

        /// <summary>
        /// Check background audio assets load is done
        /// </summary>
        public static bool IsBackgroundAudioAssetsLoaded() => _backgroundAudioAssetHandle.IsDone;
        
        /// <summary>
        /// Check effect audio assets load is done
        /// </summary>
        public static bool IsEffectAudioAssetsLoaded() => _effectAudioAssetHandle.IsDone;
        
        /// <summary>
        /// Check voice audio assets load is done
        /// </summary>
        public static bool IsVoiceAudioAssetsLoaded() => _voiceAudioAssetHandle.IsDone;
    }
}
