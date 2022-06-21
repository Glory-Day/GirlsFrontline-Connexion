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
    public static class AudioAssetLoader
    {
        private static AsyncOperationHandle<IList<AudioClip>> _backgroundAudioAssetHandle;
        private static AsyncOperationHandle<IList<AudioClip>> _effectAudioAssetHandle;
        private static AsyncOperationHandle<IList<AudioClip>> _voiceAudioAssetHandle;
        
        public static void OnLoadBackgroundAudioResources()
        {
#if UNITY_EDITOR

            LogManager.OnDebugLog(
                typeof(ResourceManager), 
                $"Called OnLoadBackgroundAudioResources()");

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
        
        public static void OnLoadEffectAudioResources()
        {
#if UNITY_EDITOR

            LogManager.OnDebugLog(
                typeof(ResourceManager), 
                $"Called OnLoadEffectAudioResources()");

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
        
        public static void OnLoadVoiceAudioResources()
        {
#if UNITY_EDITOR

            LogManager.OnDebugLog(
                typeof(ResourceManager), 
                $"Called OnLoadVoiceAudioResources()");

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

        public static void OnUnloadBackgroundAudioResources()
        {
            Addressables.Release(_backgroundAudioAssetHandle);
        }
        
        public static void OnUnloadEffectAudioResources()
        {
            Addressables.Release(_effectAudioAssetHandle);
        }
        
        public static void OnUnloadVoiceAudioResources()
        {
            Addressables.Release(_voiceAudioAssetHandle);
        }
    }
}
