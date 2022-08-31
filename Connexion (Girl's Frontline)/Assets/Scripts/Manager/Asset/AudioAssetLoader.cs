#region NAMESPACE API

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using LabelType = Manager.Log.Label.LabelType;

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
                typeof(AudioAssetLoader),
                "AudioAssetLoader()");
            
            backgroundAudioClipAssetsHandle = new AsyncOperationHandle<IList<AudioClip>>();
            effectAudioClipAssetsHandle     = new AsyncOperationHandle<IList<AudioClip>>();
            voiceAudioClipAssetsHandle      = new AsyncOperationHandle<IList<AudioClip>>(); 
        }

        #region LOAD ASSET API
        
        public void LoadBackgroundAudioClipAssets()
        {
            LogManager.OnDebugLog(
                typeof(AudioAssetLoader),
                $"LoadBackgroundAudioClipAssets()");

            void Loaded(AudioClip loadedAudioClipAsset)
            {
                SoundManager.BackgroundAudioClip.Add(loadedAudioClipAsset.name, loadedAudioClipAsset);

                LogManager.OnDebugLog(
                    LabelType.Success, 
                    typeof(AudioAssetLoader),
                    $"<b>{loadedAudioClipAsset.name}</b> is loaded successfully");
            }

            backgroundAudioClipAssetsHandle = Addressables.LoadAssetsAsync(
                DataManager.AddressableLabelData.audioAsset.labels[0], (Action<AudioClip>)Loaded);
        }
        
        public void LoadEffectAudioClipAssets()
        {
            LogManager.OnDebugLog(
                typeof(AudioAssetLoader),
                $"LoadEffectAudioClipAssets()");

            void Loaded(AudioClip loadedAudioClipAsset)
            {
                SoundManager.EffectAudioClip.Add(loadedAudioClipAsset.name, loadedAudioClipAsset);

                LogManager.OnDebugLog(
                    LabelType.Success, 
                    typeof(AudioAssetLoader),
                    $"<b>{loadedAudioClipAsset.name}</b> is loaded successfully");
            }

            effectAudioClipAssetsHandle = Addressables.LoadAssetsAsync(
                DataManager.AddressableLabelData.audioAsset.labels[1], (Action<AudioClip>)Loaded);
        }
        
        public void LoadVoiceAudioClipAssets()
        {
            LogManager.OnDebugLog(
                typeof(AudioAssetLoader),
                $"LoadVoiceAudioClipAssets()");

            void Loaded(AudioClip loadedAudioClipAsset)
            {
                SoundManager.VoiceAudioClip.Add(loadedAudioClipAsset.name, loadedAudioClipAsset);

                LogManager.OnDebugLog(
                    LabelType.Success, 
                    typeof(AudioAssetLoader),
                    $"<b>{loadedAudioClipAsset.name}</b> is loaded successfully");
            }

            voiceAudioClipAssetsHandle = Addressables.LoadAssetsAsync(
                DataManager.AddressableLabelData.audioAsset.labels[2], (Action<AudioClip>)Loaded);
        }

        #endregion

        #region UNLOAD ASSET API
        
        public void UnloadBackgroundAudioClipAssets()
        {
            LogManager.OnDebugLog(
                typeof(AudioAssetLoader),
                $"UnloadBackgroundAudioClipAssets()");

            Addressables.Release(backgroundAudioClipAssetsHandle);

            LogManager.OnDebugLog(
                LabelType.Success, 
                typeof(AudioAssetLoader),
                $"<b>All Background Audio Clips</b> are unloaded successfully");
        }
        
        public void UnloadEffectAudioClipAssets()
        {
            LogManager.OnDebugLog(
                typeof(AudioAssetLoader),
                $"UnloadEffectAudioClipAssets()");

            Addressables.Release(effectAudioClipAssetsHandle);

            LogManager.OnDebugLog(
                LabelType.Success, 
                typeof(AudioAssetLoader),
                $"<b>All Effect Audio Clips</b> are unloaded successfully");
        }
        
        public void UnloadVoiceAudioClipAssets()
        {
            LogManager.OnDebugLog(
                typeof(AudioAssetLoader),
                $"UnloadVoiceAudioClipAssets()");

            Addressables.Release(voiceAudioClipAssetsHandle);

            LogManager.OnDebugLog(
                LabelType.Success, 
                typeof(AudioAssetLoader),
                $"<b>All Voice Audio Clips</b> are unloaded successfully");
        }

        #endregion

        #region CHECK ASSET API

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
