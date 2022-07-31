#region NAMESPACE API

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Audio;
using UnityEngine.ResourceManagement.AsyncOperations;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Manager.Asset
{
    /// <summary>
    /// Audio asset loader with <b>Addressable</b>
    /// </summary>
    public class AudioAssetLoader
    {
        private AsyncOperationHandle<AudioMixer>       masterAudioMixerAssetHandle;
        private AsyncOperationHandle<IList<AudioClip>> backgroundAudioClipAssetsHandle;
        private AsyncOperationHandle<IList<AudioClip>> effectAudioClipAssetsHandle;
        private AsyncOperationHandle<IList<AudioClip>> voiceAudioClipAssetsHandle;

        public AudioAssetLoader()
        {
            masterAudioMixerAssetHandle    = new AsyncOperationHandle<AudioMixer>();
            backgroundAudioClipAssetsHandle = new AsyncOperationHandle<IList<AudioClip>>();
            effectAudioClipAssetsHandle     = new AsyncOperationHandle<IList<AudioClip>>();
            voiceAudioClipAssetsHandle      = new AsyncOperationHandle<IList<AudioClip>>(); 
        }

        #region LOAD ASSET API

        /// <summary>
        /// Load all background audio clip assets using <b>DataManager.AddressableLabelData</b>
        /// </summary>
        public void LoadBackgroundAudioClipAssets()
        {
            LogManager.OnDebugLog(typeof(AudioAssetLoader),
                $"LoadBackgroundAudioClipAssets()");

            void Loaded(AudioClip loadedAudioClipAsset)
            {
                SoundManager.AddBackgroundAudioClip(loadedAudioClipAsset.name, loadedAudioClipAsset);

                LogManager.OnDebugLog(LabelType.Success, typeof(AudioAssetLoader),
                    $"<b>{loadedAudioClipAsset.name}</b> is loaded successfully");
            }

            backgroundAudioClipAssetsHandle = Addressables.LoadAssetsAsync(
                DataManager.AddressableLabelData.audioAsset.labels[0], (Action<AudioClip>)Loaded);
        }

        /// <summary>
        /// Load all effect audio clip assets using <b>DataManager.AddressableLabelData</b>
        /// </summary>
        public void LoadEffectAudioClipAssets()
        {
            LogManager.OnDebugLog(typeof(AudioAssetLoader),
                $"LoadEffectAudioClipAssets()");

            void Loaded(AudioClip loadedAudioClipAsset)
            {
                SoundManager.AddEffectAudioClip(loadedAudioClipAsset.name, loadedAudioClipAsset);

                LogManager.OnDebugLog(LabelType.Success, typeof(AudioAssetLoader),
                    $"<b>{loadedAudioClipAsset.name}</b> is loaded successfully");
            }

            effectAudioClipAssetsHandle = Addressables.LoadAssetsAsync(
                DataManager.AddressableLabelData.audioAsset.labels[1], (Action<AudioClip>)Loaded);
        }

        /// <summary>
        /// Load all voice audio clip assets using <b>DataManager.AddressableLabelData</b>
        /// </summary>
        public void LoadVoiceAudioClipAssets()
        {
            LogManager.OnDebugLog(typeof(AudioAssetLoader),
                $"LoadVoiceAudioClipAssets()");

            void Loaded(AudioClip loadedAudioClipAsset)
            {
                SoundManager.AddVoiceAudioClip(loadedAudioClipAsset.name, loadedAudioClipAsset);

                LogManager.OnDebugLog(LabelType.Success, typeof(AudioAssetLoader),
                    $"<b>{loadedAudioClipAsset.name}</b> is loaded successfully");
            }

            voiceAudioClipAssetsHandle = Addressables.LoadAssetsAsync(
                DataManager.AddressableLabelData.audioAsset.labels[2], (Action<AudioClip>)Loaded);
        }
        
        /// <summary>
        /// Load master audio mixer asset using <b>DataManager.AddressableLabelData</b>
        /// </summary>
        public void LoadMasterAudioMixerAsset()
        {
            LogManager.OnDebugLog(typeof(AudioAssetLoader),
                $"LoadMasterAudioMixerAsset()");

            void Loaded(AsyncOperationHandle<AudioMixer> handle)
            {
                switch (handle.Status)
                {
                    case AsyncOperationStatus.Succeeded:
                        var masterAudioMixer = handle.Result;
                        
                        SoundManager.MasterAudioMixer = masterAudioMixer;

                        LogManager.OnDebugLog(LabelType.Success, typeof(AudioAssetLoader),
                            $"<b>{masterAudioMixer.name}</b> is loaded successfully");
                        
                        break;
                    case AsyncOperationStatus.Failed:
                        LogManager.OnDebugLog(LabelType.Error, typeof(AudioAssetLoader),
                            $"<b>Loaded Asset</b> is failed");
                        
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            masterAudioMixerAssetHandle =
                Addressables.LoadAssetAsync<AudioMixer>(DataManager.AddressableLabelData.audioAsset.labels[3]);

            masterAudioMixerAssetHandle.Completed += Loaded;
        }

        #endregion

        #region UNLOAD ASSET API

        /// <summary>
        /// Unload all background audio clip assets
        /// </summary>
        public void UnloadBackgroundAudioClipAssets()
        {
            LogManager.OnDebugLog(typeof(AudioAssetLoader),
                $"UnloadBackgroundAudioClipAssets()");

            Addressables.Release(backgroundAudioClipAssetsHandle);

            LogManager.OnDebugLog(LabelType.Success, typeof(AudioAssetLoader),
                $"<b>All Background Audio Clips</b> are unloaded successfully");
        }

        /// <summary>
        /// Unload all effect audio clip assets
        /// </summary>
        public void UnloadEffectAudioClipAssets()
        {
            LogManager.OnDebugLog(typeof(AudioAssetLoader),
                $"UnloadEffectAudioClipAssets()");

            Addressables.Release(effectAudioClipAssetsHandle);

            LogManager.OnDebugLog(LabelType.Success, typeof(AudioAssetLoader),
                $"<b>All Effect Audio Clips</b> are unloaded successfully");
        }

        /// <summary>
        /// Unload all voice audio clip assets
        /// </summary>
        public void UnloadVoiceAudioClipAssets()
        {
            LogManager.OnDebugLog(typeof(AudioAssetLoader),
                $"UnloadVoiceAudioClipAssets()");

            Addressables.Release(voiceAudioClipAssetsHandle);

            LogManager.OnDebugLog(LabelType.Success, typeof(AudioAssetLoader),
                $"<b>All Voice Audio Clips</b> are unloaded successfully");
        }
        
        /// <summary>
        /// Unload master audio mixer asset
        /// </summary>
        public void UnloadMasterAudioMixerAsset()
        {
            LogManager.OnDebugLog(typeof(AudioAssetLoader),
                $"UnloadMasterAudioMixerAsset()");

            Addressables.Release(masterAudioMixerAssetHandle);

            LogManager.OnDebugLog(LabelType.Success, typeof(AudioAssetLoader),
                $"<b>Master Audio Mixers</b> is unloaded successfully");
        }

        #endregion

        /// <summary>
        /// Check all background audio clip assets loaded is done
        /// </summary>
        public bool IsLoadedBackgroundAudioClipAssetsDone()
        {
            return backgroundAudioClipAssetsHandle.IsValid() && backgroundAudioClipAssetsHandle.IsDone;
        }

        /// <summary>
        /// Check all effect audio clip assets loaded is done
        /// </summary>
        public bool IsLoadedEffectAudioClipAssetsDone()
        {
            return effectAudioClipAssetsHandle.IsValid() && effectAudioClipAssetsHandle.IsDone;
        }

        /// <summary>
        /// Check all voice audio clip assets loaded is done
        /// </summary>
        public bool IsLoadedVoiceAudioClipAssetsDone()
        {
            return voiceAudioClipAssetsHandle.IsValid() && voiceAudioClipAssetsHandle.IsDone;
        }
        
        /// <summary>
        /// Check master audio mixer asset loaded is done
        /// </summary>
        public bool IsLoadedAudioMixerAssetDone()
        {
            return masterAudioMixerAssetHandle.IsValid() && masterAudioMixerAssetHandle.IsDone;
        }
    }
}
