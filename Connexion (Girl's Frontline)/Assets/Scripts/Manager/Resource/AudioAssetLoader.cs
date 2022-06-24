using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Audio;
using UnityEngine.ResourceManagement.AsyncOperations;

using LabelType = Manager.Log.Console.Label.LabelType;

namespace Manager.Resource
{
    /// <summary>
    /// Audio asset loader with <b>Addressable</b>
    /// </summary>
    public static class AudioAssetLoader
    {
        private static AsyncOperationHandle<AudioMixer> _backgroundAudioMixerAssetHandle;
        
        private static AsyncOperationHandle<IList<AudioClip>> _backgroundAudioClipAssetHandle;
        private static AsyncOperationHandle<IList<AudioClip>> _effectAudioClipAssetHandle;
        private static AsyncOperationHandle<IList<AudioClip>> _voiceAudioClipAssetHandle;

        /// <summary>
        /// Load background audio mixer asset
        /// </summary>
        public static void OnLoadBackgroundAudioMixerAsset()
        {
            LogManager.OnDebugLog(typeof(ResourceManager), 
                $"Called OnLoadBackgroundAudioMixerAsset()");

            void Callback(AsyncOperationHandle<AudioMixer> handle)
            {
                switch (handle.Status)
                {
                    case AsyncOperationStatus.None:
                        break;
                    case AsyncOperationStatus.Succeeded:
                        LogManager.OnDebugLog(LabelType.Event, typeof(AudioAssetLoader),
                            $"<b>{handle.Result.name}</b> audio mixer is loaded");
                        
                        SoundManager.SetBackgroundAudioMixer(handle.Result);
                        break;
                    case AsyncOperationStatus.Failed:
                        LogManager.OnDebugLog(LabelType.Error, typeof(AudioAssetLoader),
                            $"Failed to load background audio mixer");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            _backgroundAudioMixerAssetHandle = Addressables.LoadAssetAsync<AudioMixer>(
                DataManager.AudioAddressableLabel.audios[3]);

            _backgroundAudioMixerAssetHandle.Completed += Callback;
        }
        
        /// <summary>
        /// Load background audio clip assets
        /// </summary>
        public static void OnLoadBackgroundAudioClipAssets()
        {
            LogManager.OnDebugLog(typeof(ResourceManager), 
                $"Called OnLoadBackgroundAudioClipAssets()");

            void Callback(AudioClip loadedAudioClipAsset)
            {
                SoundManager.AddBackgroundAudioClip(loadedAudioClipAsset);
                
                LogManager.OnDebugLog(LabelType.Event, typeof(AudioAssetLoader),
                    $"<b>{loadedAudioClipAsset.name}</b> audio clip is loaded");
            }

            _backgroundAudioClipAssetHandle = Addressables.LoadAssetsAsync(DataManager.AudioAddressableLabel.audios[0],
                (Action<AudioClip>)Callback);
        }
        
        /// <summary>
        /// Load effect audio clip assets
        /// </summary>
        public static void OnLoadEffectAudioClipAssets()
        {
            LogManager.OnDebugLog(typeof(ResourceManager), 
                $"Called OnLoadEffectAudioClipAssets()");

            void Callback(AudioClip loadedAudioClipAsset)
            {
                SoundManager.AddEffectAudioClip(loadedAudioClipAsset);

                LogManager.OnDebugLog(LabelType.Event, typeof(AudioAssetLoader),
                    $"<b>{loadedAudioClipAsset.name}</b> audio clip is loaded");
            }

            _effectAudioClipAssetHandle = Addressables.LoadAssetsAsync(DataManager.AudioAddressableLabel.audios[1],
                (Action<AudioClip>)Callback);
        }
        
        /// <summary>
        /// Load voice audio clip assets
        /// </summary>
        public static void OnLoadVoiceAudioClipAssets()
        {
            LogManager.OnDebugLog(typeof(ResourceManager), 
                $"Called OnLoadVoiceAudioClipAssets()");

            void Callback(AudioClip loadedAudioClipAsset)
            {
                SoundManager.AddVoiceAudioClip(loadedAudioClipAsset);

                LogManager.OnDebugLog(LabelType.Event, typeof(AudioAssetLoader),
                    $"<b>{loadedAudioClipAsset.name}</b> audio clip is loaded");
            }

            _voiceAudioClipAssetHandle = Addressables.LoadAssetsAsync(DataManager.AudioAddressableLabel.audios[2],
                (Action<AudioClip>)Callback);
        }
        
        /// <summary>
        /// Unload background audio mixer asset
        /// </summary>
        public static void OnUnloadBackgroundAudioMixerAsset()
        {
            LogManager.OnDebugLog(typeof(ResourceManager), 
                $"Called OnUnloadBackgroundAudioMixerAsset()");
            
            Addressables.Release(_backgroundAudioMixerAssetHandle);
            
            LogManager.OnDebugLog(LabelType.Event, typeof(AudioAssetLoader),
                $"<b>Background audio mixer</b> is unloaded");
        }

        /// <summary>
        /// Unload background audio clip assets
        /// </summary>
        public static void OnUnloadBackgroundAudioClipAssets()
        {
            LogManager.OnDebugLog(typeof(ResourceManager), 
                $"Called OnUnloadBackgroundAudioClipAssets()");
            
            Addressables.Release(_backgroundAudioClipAssetHandle);
            
            LogManager.OnDebugLog(LabelType.Event, typeof(AudioAssetLoader),
                $"<b>All background audio clips</b> are unloaded");
        }
        
        /// <summary>
        /// Unload effect audio clip assets
        /// </summary>
        public static void OnUnloadEffectAudioClipAssets()
        {
            LogManager.OnDebugLog(typeof(ResourceManager), 
                $"Called OnUnloadEffectAudioClipAssets()");
            
            Addressables.Release(_effectAudioClipAssetHandle);
            
            LogManager.OnDebugLog(LabelType.Event, typeof(AudioAssetLoader),
                $"<b>All effect audio clips</b> are unloaded");
        }
        
        /// <summary>
        /// Unload voice audio clip assets
        /// </summary>
        public static void OnUnloadVoiceAudioClipAssets()
        {
            LogManager.OnDebugLog(typeof(ResourceManager), 
                $"Called OnUnloadVoiceAudioClipAssets()");
            
            Addressables.Release(_voiceAudioClipAssetHandle);
            
            LogManager.OnDebugLog(LabelType.Event, typeof(AudioAssetLoader),
                $"<b>All voice audio clips</b> are unloaded");
        }
        
        /// <summary>
        /// Check main audio mixer asset load is done
        /// </summary>
        public static bool IsBackgroundAudioMixerAssetLoaded() => _backgroundAudioMixerAssetHandle.IsDone;

        /// <summary>
        /// Check background audio clip assets load is done
        /// </summary>
        public static bool IsBackgroundAudioClipAssetsLoaded() => _backgroundAudioClipAssetHandle.IsDone;
        
        /// <summary>
        /// Check effect audio clip assets load is done
        /// </summary>
        public static bool IsEffectAudioClipAssetsLoaded() => _effectAudioClipAssetHandle.IsDone;
        
        /// <summary>
        /// Check voice audio clip assets load is done
        /// </summary>
        public static bool IsVoiceAudioClipAssetsLoaded() => _voiceAudioClipAssetHandle.IsDone;
    }
}
