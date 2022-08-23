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
    /// <summary>
    /// Audio asset loader with <see cref="Addressables"/>
    /// </summary>
    public class AudioAssetLoader
    {
        private AsyncOperationHandle<IList<AudioClip>> backgroundAudioClipAssetsHandle;
        private AsyncOperationHandle<IList<AudioClip>> effectAudioClipAssetsHandle;
        private AsyncOperationHandle<IList<AudioClip>> voiceAudioClipAssetsHandle;
        
        /// <summary>
        /// <see cref="AudioAssetLoader"/> constructor
        /// </summary>
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

        /// <summary>
        /// Load all background <see cref="AudioClip"/> assets
        /// using label in <see cref="DataManager.AddressableLabelData"/>
        /// </summary>
        public void LoadBackgroundAudioClipAssets()
        {
            LogManager.OnDebugLog(
                typeof(AudioAssetLoader),
                $"LoadBackgroundAudioClipAssets()");

            void Loaded(AudioClip loadedAudioClipAsset)
            {
                SoundManager.AddBackgroundAudioClip(loadedAudioClipAsset.name, loadedAudioClipAsset);

                LogManager.OnDebugLog(
                    LabelType.Success, 
                    typeof(AudioAssetLoader),
                    $"<b>{loadedAudioClipAsset.name}</b> is loaded successfully");
            }

            backgroundAudioClipAssetsHandle = Addressables.LoadAssetsAsync(
                DataManager.AddressableLabelData.audioAsset.labels[0], (Action<AudioClip>)Loaded);
        }

        /// <summary>
        /// Load all effect <see cref="AudioClip"/> assets
        /// using label in <see cref="DataManager.AddressableLabelData"/>
        /// </summary>
        public void LoadEffectAudioClipAssets()
        {
            LogManager.OnDebugLog(
                typeof(AudioAssetLoader),
                $"LoadEffectAudioClipAssets()");

            void Loaded(AudioClip loadedAudioClipAsset)
            {
                SoundManager.AddEffectAudioClip(loadedAudioClipAsset.name, loadedAudioClipAsset);

                LogManager.OnDebugLog(
                    LabelType.Success, 
                    typeof(AudioAssetLoader),
                    $"<b>{loadedAudioClipAsset.name}</b> is loaded successfully");
            }

            effectAudioClipAssetsHandle = Addressables.LoadAssetsAsync(
                DataManager.AddressableLabelData.audioAsset.labels[1], (Action<AudioClip>)Loaded);
        }

        /// <summary>
        /// Load all voice <see cref="AudioClip"/> assets
        /// using label in <see cref="DataManager.AddressableLabelData"/>
        /// </summary>
        public void LoadVoiceAudioClipAssets()
        {
            LogManager.OnDebugLog(
                typeof(AudioAssetLoader),
                $"LoadVoiceAudioClipAssets()");

            void Loaded(AudioClip loadedAudioClipAsset)
            {
                SoundManager.AddVoiceAudioClip(loadedAudioClipAsset.name, loadedAudioClipAsset);

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

        /// <summary>
        /// Unload all background <see cref="AudioClip"/> assets
        /// </summary>
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

        /// <summary>
        /// Unload all effect <see cref="AudioClip"/> assets
        /// </summary>
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

        /// <summary>
        /// Unload all voice <see cref="AudioClip"/> assets
        /// </summary>
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

        /// <summary>
        /// Check all background <see cref="AudioClip"/> assets loaded is done
        /// </summary>
        public bool IsLoadedBackgroundAudioClipAssetsDone()
        {
            return backgroundAudioClipAssetsHandle.IsValid() && backgroundAudioClipAssetsHandle.IsDone;
        }

        /// <summary>
        /// Check all effect <see cref="AudioClip"/> assets loaded is done
        /// </summary>
        public bool IsLoadedEffectAudioClipAssetsDone()
        {
            return effectAudioClipAssetsHandle.IsValid() && effectAudioClipAssetsHandle.IsDone;
        }

        /// <summary>
        /// Check all voice <see cref="AudioClip"/> assets loaded is done
        /// </summary>
        public bool IsLoadedVoiceAudioClipAssetsDone()
        {
            return voiceAudioClipAssetsHandle.IsValid() && voiceAudioClipAssetsHandle.IsDone;
        }
    }
}
