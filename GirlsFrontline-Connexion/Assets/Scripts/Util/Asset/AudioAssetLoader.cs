using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object.Manager;
using Util.Manager;

namespace Util.Asset
{
    public class AudioAssetLoader : IAssetLoader
    {
        private AsyncOperationHandle<IList<AudioClip>> backgroundAudioClipAssetsHandle;
        private AsyncOperationHandle<IList<AudioClip>> effectAudioClipAssetsHandle;
        private AsyncOperationHandle<IList<AudioClip>> voiceAudioClipAssetsHandle;
        
        public AudioAssetLoader()
        {
            LogManager.LogProgress();
            
            backgroundAudioClipAssetsHandle = new AsyncOperationHandle<IList<AudioClip>>();
            effectAudioClipAssetsHandle     = new AsyncOperationHandle<IList<AudioClip>>();
            voiceAudioClipAssetsHandle      = new AsyncOperationHandle<IList<AudioClip>>(); 
        }

        public void Load()
        {
            
        }

        public void Unload()
        {
            
        }
        
        public void LoadBackgroundAudioClipAssets()
        {
            LogManager.LogProgress();

            backgroundAudioClipAssetsHandle = Addressables.LoadAssetsAsync(
                DataManager.AddressableLabelData.audioAsset.labels[0], (Action<AudioClip>)Loaded);
            
            return;

            void Loaded(AudioClip loadedAudioClipAsset)
            {
                SoundManager.BackgroundAudioClip.Add(loadedAudioClipAsset.name, loadedAudioClipAsset);

                LogManager.LogSuccess($"<b>{loadedAudioClipAsset.name}</b> is loaded");
            }
        }
        
        public void LoadEffectAudioClipAssets()
        {
            LogManager.LogProgress();

            effectAudioClipAssetsHandle = Addressables.LoadAssetsAsync(
                DataManager.AddressableLabelData.audioAsset.labels[1], (Action<AudioClip>)Loaded);
            
            return;

            void Loaded(AudioClip loadedAudioClipAsset)
            {
                SoundManager.EffectAudioClip.Add(loadedAudioClipAsset.name, loadedAudioClipAsset);

                LogManager.LogSuccess($"<b>{loadedAudioClipAsset.name}</b> is loaded");
            }
        }
        
        public void LoadVoiceAudioClipAssets()
        {
            LogManager.LogProgress();

            voiceAudioClipAssetsHandle = Addressables.LoadAssetsAsync(
                DataManager.AddressableLabelData.audioAsset.labels[2], (Action<AudioClip>)Loaded);
            
            return;

            void Loaded(AudioClip loadedAudioClipAsset)
            {
                SoundManager.VoiceAudioClip.Add(loadedAudioClipAsset.name, loadedAudioClipAsset);

                LogManager.LogSuccess($"<b>{loadedAudioClipAsset.name}</b> is loaded");
            }
        }
        
        public void UnloadBackgroundAudioClipAssets()
        {
            Addressables.Release(backgroundAudioClipAssetsHandle);

            LogManager.LogSuccess("<b>All Background Audio Clips</b> are unloaded");
        }
        
        public void UnloadEffectAudioClipAssets()
        {
            LogManager.LogProgress();

            Addressables.Release(effectAudioClipAssetsHandle);

            LogManager.LogSuccess("<b>All Effect Audio Clips</b> are unloaded");
        }
        
        public void UnloadVoiceAudioClipAssets()
        {
            LogManager.LogProgress();

            Addressables.Release(voiceAudioClipAssetsHandle);

            LogManager.LogSuccess("<b>All Voice Audio Clips</b> are unloaded");
        }

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
    }
}
