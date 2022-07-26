#region NAMESPACE API

using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Audio;
using UnityEngine.ResourceManagement.AsyncOperations;

using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Manager.Resource
{
    /// <summary>
    /// Audio asset loader with <b>Addressable</b>
    /// </summary>
    public static class AudioAssetLoader
    {
        private static AsyncOperationHandle<IList<AudioMixer>> _audioMixerAssetHandle;
        
        private static AsyncOperationHandle<IList<AudioClip>> _backgroundAudioClipAssetHandle;
        private static AsyncOperationHandle<IList<AudioClip>> _effectAudioClipAssetHandle;
        private static AsyncOperationHandle<IList<AudioClip>> _voiceAudioClipAssetHandle;

        #region LOAD ASSET API

        /// <summary>
        /// Load all audio mixer assets using <b>DataManager.AddressableLabelData</b>
        /// </summary>
        public static void OnLoadAudioMixerAssets()
        {
            LogManager.OnDebugLog(typeof(AudioAssetLoader), 
                $"OnLoadAudioMixerAssets()");

            void Loaded(AudioMixer loadedAudioMixer)
            {
                SoundManager.AddAudioMixer(loadedAudioMixer.name, loadedAudioMixer);
                
                LogManager.OnDebugLog(LabelType.Event, typeof(AudioAssetLoader),
                    $"<b>{loadedAudioMixer.name}</b> is loaded");
            }

            _audioMixerAssetHandle = Addressables.LoadAssetsAsync(DataManager.AddressableLabelData.audios[3],
                (Action<AudioMixer>)Loaded);
        }
        
        /// <summary>
        /// Load all background audio clip assets using <b>DataManager.AddressableLabelData</b>
        /// </summary>
        public static void OnLoadBackgroundAudioClipAssets()
        {
            LogManager.OnDebugLog(typeof(AudioAssetLoader), 
                $"OnLoadBackgroundAudioClipAssets()");

            void Loaded(AudioClip loadedAudioClipAsset)
            {
                SoundManager.AddBackgroundAudioClip(loadedAudioClipAsset.name, loadedAudioClipAsset);
                
                LogManager.OnDebugLog(LabelType.Event, typeof(AudioAssetLoader),
                    $"<b>{loadedAudioClipAsset.name}</b> is loaded");
            }

            _backgroundAudioClipAssetHandle = Addressables.LoadAssetsAsync(DataManager.AddressableLabelData.audios[0],
                (Action<AudioClip>)Loaded);
        }
        
        /// <summary>
        /// Load all effect audio clip assets using <b>DataManager.AddressableLabelData</b>
        /// </summary>
        public static void OnLoadEffectAudioClipAssets()
        {
            LogManager.OnDebugLog(typeof(AudioAssetLoader), 
                $"OnLoadEffectAudioClipAssets()");

            void Loaded(AudioClip loadedAudioClipAsset)
            {
                SoundManager.AddEffectAudioClip(loadedAudioClipAsset.name, loadedAudioClipAsset);

                LogManager.OnDebugLog(LabelType.Event, typeof(AudioAssetLoader),
                    $"<b>{loadedAudioClipAsset.name}</b> is loaded");
            }

            _effectAudioClipAssetHandle = Addressables.LoadAssetsAsync(DataManager.AddressableLabelData.audios[1],
                (Action<AudioClip>)Loaded);
        }
        
        /// <summary>
        /// Load all voice audio clip assets using <b>DataManager.AddressableLabelData</b>
        /// </summary>
        public static void OnLoadVoiceAudioClipAssets()
        {
            LogManager.OnDebugLog(typeof(AudioAssetLoader), 
                $"Called OnLoadVoiceAudioClipAssets()");

            void Loaded(AudioClip loadedAudioClipAsset)
            {
                SoundManager.AddVoiceAudioClip(loadedAudioClipAsset.name, loadedAudioClipAsset);

                LogManager.OnDebugLog(LabelType.Event, typeof(AudioAssetLoader),
                    $"<b>{loadedAudioClipAsset.name}</b> is loaded");
            }

            _voiceAudioClipAssetHandle = Addressables.LoadAssetsAsync(DataManager.AddressableLabelData.audios[2],
                (Action<AudioClip>)Loaded);
        }

        #endregion

        #region UNLOAD ASSET API

        /// <summary>
        /// Unload all audio mixer assets
        /// </summary>
        public static void OnUnloadAudioMixerAssets()
        {
            LogManager.OnDebugLog(typeof(AudioAssetLoader), 
                $"OnUnloadAudioMixerAssets()");
            
            Addressables.Release(_audioMixerAssetHandle);
            
            LogManager.OnDebugLog(LabelType.Event, typeof(AudioAssetLoader),
                $"<b>All Audio mixers</b> are unloaded");
        }

        /// <summary>
        /// Unload all background audio clip assets
        /// </summary>
        public static void OnUnloadBackgroundAudioClipAssets()
        {
            LogManager.OnDebugLog(typeof(AudioAssetLoader), 
                $"OnUnloadBackgroundAudioClipAssets()");
            
            Addressables.Release(_backgroundAudioClipAssetHandle);
            
            LogManager.OnDebugLog(LabelType.Event, typeof(AudioAssetLoader),
                $"<b>All background audio clips</b> are unloaded");
        }
        
        /// <summary>
        /// Unload all effect audio clip assets
        /// </summary>
        public static void OnUnloadEffectAudioClipAssets()
        {
            LogManager.OnDebugLog(typeof(AudioAssetLoader), 
                $"OnUnloadEffectAudioClipAssets()");
            
            Addressables.Release(_effectAudioClipAssetHandle);
            
            LogManager.OnDebugLog(LabelType.Event, typeof(AudioAssetLoader),
                $"<b>All effect audio clips</b> are unloaded");
        }
        
        /// <summary>
        /// Unload all voice audio clip assets
        /// </summary>
        public static void OnUnloadVoiceAudioClipAssets()
        {
            LogManager.OnDebugLog(typeof(AudioAssetLoader), 
                $"OnUnloadVoiceAudioClipAssets()");
            
            Addressables.Release(_voiceAudioClipAssetHandle);
            
            LogManager.OnDebugLog(LabelType.Event, typeof(AudioAssetLoader),
                $"<b>All voice audio clips</b> are unloaded");
        }

        #endregion

        /// <summary>
        /// Check all audio mixer assets loaded is done
        /// </summary>
        public static bool IsLoadedAudioMixerAssetsDone() => 
            _audioMixerAssetHandle.IsValid() && _audioMixerAssetHandle.IsDone;

        /// <summary>
        /// Check all background audio clip assets loaded is done
        /// </summary>
        public static bool IsLoadedBackgroundAudioClipAssetsDone() => 
            _backgroundAudioClipAssetHandle.IsValid() && _backgroundAudioClipAssetHandle.IsDone;

        /// <summary>
        /// Check all effect audio clip assets loaded is done
        /// </summary>
        public static bool IsLoadedEffectAudioClipAssetsDone() => 
            _effectAudioClipAssetHandle.IsValid() && _effectAudioClipAssetHandle.IsDone;

        /// <summary>
        /// Check all voice audio clip assets loaded is done
        /// </summary>
        public static bool IsLoadedVoiceAudioClipAssetsDone() => 
            _voiceAudioClipAssetHandle.IsValid() && _voiceAudioClipAssetHandle.IsDone;
    }
}
