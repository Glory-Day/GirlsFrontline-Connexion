#region NAMESPACE API

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Label = Manager.Log.Label;

#endregion

namespace Manager.Asset
{
    public class AudioAssetLoader
    {
        private AsyncOperationHandle<IList<AudioClip>> backgroundAudioClipAssetsHandle;
        private AsyncOperationHandle<IList<AudioClip>> effectAudioClipAssetsHandle;
        private AsyncOperationHandle<IList<AudioClip>> voiceAudioClipAssetsHandle;
        
        public AudioAssetLoader()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(AudioAssetLoader),
                "AudioAssetLoader()");
            
            backgroundAudioClipAssetsHandle = new AsyncOperationHandle<IList<AudioClip>>();
            effectAudioClipAssetsHandle     = new AsyncOperationHandle<IList<AudioClip>>();
            voiceAudioClipAssetsHandle      = new AsyncOperationHandle<IList<AudioClip>>(); 
        }

        #region LOAD METHOD API
        
        public void LoadBackgroundAudioClipAssets()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(AudioAssetLoader),
                $"LoadBackgroundAudioClipAssets()");
            
            void Loaded(AudioClip loadedAudioClipAsset)
            {
                SoundManager.BackgroundAudioClip.Add(loadedAudioClipAsset.name, loadedAudioClipAsset);

                LogManager.OnDebugLog(
                    Label.Success,
                    typeof(AudioAssetLoader),
                    $"<b>{loadedAudioClipAsset.name}</b> is loaded");
            }

            backgroundAudioClipAssetsHandle = Addressables.LoadAssetsAsync(
                DataManager.AddressableLabelData.audioAsset.labels[0], (Action<AudioClip>)Loaded);
        }
        
        public void LoadEffectAudioClipAssets()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(AudioAssetLoader),
                $"LoadEffectAudioClipAssets()");

            void Loaded(AudioClip loadedAudioClipAsset)
            {
                SoundManager.EffectAudioClip.Add(loadedAudioClipAsset.name, loadedAudioClipAsset);

                LogManager.OnDebugLog(
                    Label.Success, 
                    typeof(AudioAssetLoader),
                    $"<b>{loadedAudioClipAsset.name}</b> is loaded");
            }

            effectAudioClipAssetsHandle = Addressables.LoadAssetsAsync(
                DataManager.AddressableLabelData.audioAsset.labels[1], (Action<AudioClip>)Loaded);
        }
        
        public void LoadVoiceAudioClipAssets()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(AudioAssetLoader),
                $"LoadVoiceAudioClipAssets()");

            void Loaded(AudioClip loadedAudioClipAsset)
            {
                SoundManager.VoiceAudioClip.Add(loadedAudioClipAsset.name, loadedAudioClipAsset);

                LogManager.OnDebugLog(
                    Label.Success, 
                    typeof(AudioAssetLoader),
                    $"<b>{loadedAudioClipAsset.name}</b> is loaded");
            }

            voiceAudioClipAssetsHandle = Addressables.LoadAssetsAsync(
                DataManager.AddressableLabelData.audioAsset.labels[2], (Action<AudioClip>)Loaded);
        }

        #endregion

        #region UNLOAD METHOD API
        
        public void UnloadBackgroundAudioClipAssets()
        {
            Addressables.Release(backgroundAudioClipAssetsHandle);

            LogManager.OnDebugLog(
                Label.Success, 
                typeof(AudioAssetLoader),
                $"<b>All Background Audio Clips</b> are unloaded");
        }
        
        public void UnloadEffectAudioClipAssets()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(AudioAssetLoader),
                $"UnloadEffectAudioClipAssets()");

            Addressables.Release(effectAudioClipAssetsHandle);

            LogManager.OnDebugLog(
                Label.Success, 
                typeof(AudioAssetLoader),
                $"<b>All Effect Audio Clips</b> are unloaded");
        }
        
        public void UnloadVoiceAudioClipAssets()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(AudioAssetLoader),
                $"UnloadVoiceAudioClipAssets()");

            Addressables.Release(voiceAudioClipAssetsHandle);

            LogManager.OnDebugLog(
                Label.Success, 
                typeof(AudioAssetLoader),
                $"<b>All Voice Audio Clips</b> are unloaded");
        }

        #endregion

        #region CHECK METHOD API

        public bool IsLoadedBackgroundAudioClipAssetsDone()
        {
            return backgroundAudioClipAssetsHandle.IsValid() && backgroundAudioClipAssetsHandle.IsDone;
        }
        
        public bool IsLoadedEffectAudioClipAssetsDone()
        {
            return effectAudioClipAssetsHandle.IsValid() && effectAudioClipAssetsHandle.IsDone;
        }
        
        public bool IsLoadedVoiceAudioClipAssetsDone()
        {
            return voiceAudioClipAssetsHandle.IsValid() && voiceAudioClipAssetsHandle.IsDone;
        }

        #endregion
    }
}
