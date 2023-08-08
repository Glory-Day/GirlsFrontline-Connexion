using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object.Manager;
using Util.Manager;

namespace Util.Asset
{
    public class AudioAssetLoader
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

        #region LOAD ASSET METHOD API
        
        public void LoadBackgroundAudioClipAssets()
        {
            LogManager.LogProgress();
            
            void Loaded(AudioClip loadedAudioClipAsset)
            {
                SoundManager.BackgroundAudioClip.Add(loadedAudioClipAsset.name, loadedAudioClipAsset);

                LogManager.LogSuccess($"<b>{loadedAudioClipAsset.name}</b> is loaded");
            }

            backgroundAudioClipAssetsHandle = Addressables.LoadAssetsAsync(
                DataManager.AddressableLabelData.audioAsset.labels[0], (Action<AudioClip>)Loaded);
        }
        
        public void LoadEffectAudioClipAssets()
        {
            LogManager.LogProgress();

            void Loaded(AudioClip loadedAudioClipAsset)
            {
                SoundManager.EffectAudioClip.Add(loadedAudioClipAsset.name, loadedAudioClipAsset);

                LogManager.LogSuccess($"<b>{loadedAudioClipAsset.name}</b> is loaded");
            }

            effectAudioClipAssetsHandle = Addressables.LoadAssetsAsync(
                DataManager.AddressableLabelData.audioAsset.labels[1], (Action<AudioClip>)Loaded);
        }
        
        public void LoadVoiceAudioClipAssets()
        {
            LogManager.LogProgress();

            void Loaded(AudioClip loadedAudioClipAsset)
            {
                SoundManager.VoiceAudioClip.Add(loadedAudioClipAsset.name, loadedAudioClipAsset);

                LogManager.LogSuccess($"<b>{loadedAudioClipAsset.name}</b> is loaded");
            }

            voiceAudioClipAssetsHandle = Addressables.LoadAssetsAsync(
                DataManager.AddressableLabelData.audioAsset.labels[2], (Action<AudioClip>)Loaded);
        }

        #endregion

        #region UNLOAD ASSET METHOD API
        
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

        #endregion

        #region CHECK ASSET METHOD API

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
