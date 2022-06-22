using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

using Manager.Data;

using Manager.Log;
using LabelType = Manager.Log.Console.Label.LabelType;

namespace Manager.Resource
{
    /// <summary>
    /// Class to read audio assets
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
#if UNITY_EDITOR

            LogManager.OnDebugLog(
                typeof(ResourceManager), 
                $"Called OnLoadBackgroundAudioAssets()");

#endif
            
            void Callback(AudioClip loadedAudioAsset)
            {
                SoundManager.AddBackgroundAudioClip(loadedAudioAsset.name, loadedAudioAsset);

#if UNITY_EDITOR

                LogManager.OnDebugLog(
                    LabelType.Success,
                    typeof(AudioAssetLoader),
                    $"Load {loadedAudioAsset.name} is complete");

#endif
            }

            _backgroundAudioAssetHandle = Addressables.LoadAssetsAsync(DataManager.Audio.audios[0],
                (Action<AudioClip>)Callback);
        }
        
        /// <summary>
        /// Load effect audio assets
        /// </summary>
        public static void OnLoadEffectAudioAssets()
        {
#if UNITY_EDITOR

            LogManager.OnDebugLog(
                typeof(ResourceManager), 
                $"Called OnLoadEffectAudioAssets()");

#endif
            
            void Callback(AudioClip loadedAudioAsset)
            {
                SoundManager.AddEffectAudioClip(loadedAudioAsset.name, loadedAudioAsset);

#if UNITY_EDITOR

                LogManager.OnDebugLog(
                    LabelType.Success,
                    typeof(AudioAssetLoader),
                    $"Load {loadedAudioAsset.name} is complete");

#endif
            }

            _effectAudioAssetHandle = Addressables.LoadAssetsAsync(DataManager.Audio.audios[1],
                (Action<AudioClip>)Callback);
        }
        
        /// <summary>
        /// Load voice audio assets
        /// </summary>
        public static void OnLoadVoiceAudioAssets()
        {
#if UNITY_EDITOR

            LogManager.OnDebugLog(
                typeof(ResourceManager), 
                $"Called OnLoadVoiceAudioAssets()");

#endif
            
            void Callback(AudioClip loadedAudioAsset)
            {
                SoundManager.AddVoiceAudioClip(loadedAudioAsset.name, loadedAudioAsset);

#if UNITY_EDITOR

                LogManager.OnDebugLog(
                    LabelType.Success,
                    typeof(AudioAssetLoader),
                    $"Load {loadedAudioAsset.name} is complete");

#endif
            }

            _voiceAudioAssetHandle = Addressables.LoadAssetsAsync(DataManager.Audio.audios[2],
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
    }
}
