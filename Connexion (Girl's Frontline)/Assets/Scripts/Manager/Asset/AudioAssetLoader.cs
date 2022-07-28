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
        private AsyncOperationHandle<IList<AudioMixer>> audioMixerAssetHandle;

        private AsyncOperationHandle<IList<AudioClip>> backgroundAudioClipAssetHandle;
        private AsyncOperationHandle<IList<AudioClip>> effectAudioClipAssetHandle;
        private AsyncOperationHandle<IList<AudioClip>> voiceAudioClipAssetHandle;

        public AudioAssetLoader()
        {
            audioMixerAssetHandle          = new AsyncOperationHandle<IList<AudioMixer>>();
            backgroundAudioClipAssetHandle = new AsyncOperationHandle<IList<AudioClip>>();
            effectAudioClipAssetHandle     = new AsyncOperationHandle<IList<AudioClip>>();
            voiceAudioClipAssetHandle      = new AsyncOperationHandle<IList<AudioClip>>();
        }

        #region LOAD ASSET API

        /// <summary>
        /// Load all audio mixer assets using <b>DataManager.AddressableLabelData</b>
        /// </summary>
        public void LoadAudioMixerAssets()
        {
            LogManager.OnDebugLog(typeof(AudioAssetLoader),
                $"LoadAudioMixerAssets()");

            void Loaded(AudioMixer loadedAudioMixer)
            {
                SoundManager.AddAudioMixer(loadedAudioMixer.name, loadedAudioMixer);

                LogManager.OnDebugLog(LabelType.Success, typeof(AudioAssetLoader),
                    $"<b>{loadedAudioMixer.name}</b> is loaded successfully");
            }

            audioMixerAssetHandle = Addressables.LoadAssetsAsync(DataManager.AddressableLabelData.audioAsset.names[3],
                (Action<AudioMixer>)Loaded);
        }

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

            backgroundAudioClipAssetHandle = Addressables.LoadAssetsAsync(
                DataManager.AddressableLabelData.audioAsset.names[0], (Action<AudioClip>)Loaded);
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

            effectAudioClipAssetHandle = Addressables.LoadAssetsAsync(
                DataManager.AddressableLabelData.audioAsset.names[1], (Action<AudioClip>)Loaded);
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

            voiceAudioClipAssetHandle = Addressables.LoadAssetsAsync(
                DataManager.AddressableLabelData.audioAsset.names[2], (Action<AudioClip>)Loaded);
        }

        #endregion

        #region UNLOAD ASSET API

        /// <summary>
        /// Unload all audio mixer assets
        /// </summary>
        public void UnloadAudioMixerAssets()
        {
            LogManager.OnDebugLog(typeof(AudioAssetLoader),
                $"UnloadAudioMixerAssets()");

            Addressables.Release(audioMixerAssetHandle);

            LogManager.OnDebugLog(LabelType.Success, typeof(AudioAssetLoader),
                $"<b>All Audio Mixers</b> are unloaded successfully");
        }

        /// <summary>
        /// Unload all background audio clip assets
        /// </summary>
        public void UnloadBackgroundAudioClipAssets()
        {
            LogManager.OnDebugLog(typeof(AudioAssetLoader),
                $"UnloadBackgroundAudioClipAssets()");

            Addressables.Release(backgroundAudioClipAssetHandle);

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

            Addressables.Release(effectAudioClipAssetHandle);

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

            Addressables.Release(voiceAudioClipAssetHandle);

            LogManager.OnDebugLog(LabelType.Success, typeof(AudioAssetLoader),
                $"<b>All Voice Audio Clips</b> are unloaded successfully");
        }

        #endregion

        /// <summary>
        /// Check all audio mixer assets loaded is done
        /// </summary>
        public bool IsLoadedAudioMixerAssetsDone()
        {
            return audioMixerAssetHandle.IsValid() && audioMixerAssetHandle.IsDone;
        }

        /// <summary>
        /// Check all background audio clip assets loaded is done
        /// </summary>
        public bool IsLoadedBackgroundAudioClipAssetsDone()
        {
            return backgroundAudioClipAssetHandle.IsValid() && backgroundAudioClipAssetHandle.IsDone;
        }

        /// <summary>
        /// Check all effect audio clip assets loaded is done
        /// </summary>
        public bool IsLoadedEffectAudioClipAssetsDone()
        {
            return effectAudioClipAssetHandle.IsValid() && effectAudioClipAssetHandle.IsDone;
        }

        /// <summary>
        /// Check all voice audio clip assets loaded is done
        /// </summary>
        public bool IsLoadedVoiceAudioClipAssetsDone()
        {
            return voiceAudioClipAssetHandle.IsValid() && voiceAudioClipAssetHandle.IsDone;
        }
    }
}
