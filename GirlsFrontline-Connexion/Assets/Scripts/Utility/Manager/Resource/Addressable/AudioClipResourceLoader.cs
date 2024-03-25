﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using GloryDay.Log;

namespace Utility.Manager.Resource.Addressable
{
    public class AudioClipResourceLoader : IResourceLoader
    {
        private AsyncOperationHandle<IList<AudioClip>> _backgroundAudioClipResourceHandle;
        private AsyncOperationHandle<IList<AudioClip>> _effectAudioClipResourceHandle;
        private AsyncOperationHandle<IList<AudioClip>> _voiceAudioClipResourceHandle;
        
        public void Load()
        {
            LogManager.LogProgress();
            
            _backgroundAudioClipResourceHandle = Addressables.LoadAssetsAsync(
                AddressableGroup.AudioClip.Background, (Action<AudioClip>)LoadBackgroundAudioClipResources);
            
            //TODO: This code is not working yet.
            // _effectAudioClipResourceHandle = Addressables.LoadAssetsAsync(AddressableLabel.AudioClip.Effect,
            //     (Action<UnityEngine.AudioClip>)LoadEffectAudioClipResources);
            // _voiceAudioClipResourceHandle = Addressables.LoadAssetsAsync(AddressableLabel.AudioClip.Voice,
            //     (Action<UnityEngine.AudioClip>)LoadVoiceAudioClipResources);
        }

        public void Unload()
        {
            LogManager.LogProgress();
            
            UnloadBackgroundAudioClipResources();
            UnloadEffectAudioClipResources();
            UnloadVoiceAudioClipResources();
        }
        
        /// <summary>
        /// Load background audio clip assets using addressables
        /// </summary>
        /// <param name="resource"> Loaded asset </param>
        private static void LoadBackgroundAudioClipResources(AudioClip resource)
        {
            ResourceManager.AudioClipResource.Background.Add(resource.name, resource);
            
            LogManager.LogSuccess($"<b>{resource.name}</b> is loaded");
        }
        
        //TODO: This code is not working yet.
        /// <summary>
        /// Load effect audio clip assets using addressables
        /// </summary>
        /// <param name="resource"> Loaded asset </param>
        private static void LoadEffectAudioClipResources(AudioClip resource)
        {
            ResourceManager.AudioClipResource.Effect.Add(resource.name, resource);
            
            LogManager.LogSuccess($"<b>{resource.name}</b> is loaded");
        }
        
        //TODO: This code is not working yet.
        /// <summary>
        /// Load voice audio clip assets using addressables
        /// </summary>
        /// <param name="resource"> Loaded asset </param>
        private static void LoadVoiceAudioClipResources(AudioClip resource)
        {
            ResourceManager.AudioClipResource.Voice.Add(resource.name, resource);
            
            LogManager.LogSuccess($"<b>{resource.name}</b> is loaded");
        }

        /// <summary>
        /// Unload background audio clip assets using addressables
        /// </summary>
        private void UnloadBackgroundAudioClipResources()
        {
            Addressables.Release(_backgroundAudioClipResourceHandle);

            LogManager.LogSuccess("<b>All Background Audio Clips</b> are unloaded");
        }
        
        /// <summary>
        /// Unload effect audio clip assets using addressables
        /// </summary>
        private void UnloadEffectAudioClipResources()
        {
            Addressables.Release(_effectAudioClipResourceHandle);

            LogManager.LogSuccess("<b>All Effect Audio Clips</b> are unloaded");
        }
        
        /// <summary>
        /// Unload voice audio clip assets using addressables
        /// </summary>
        private void UnloadVoiceAudioClipResources()
        {
            Addressables.Release(_voiceAudioClipResourceHandle);

            LogManager.LogSuccess("<b>All Voice Audio Clips</b> are unloaded");
        }
        
        public bool IsLoadedDone => IsBackgroundAudioClipResourcesLoadedDone;

        //TODO: This code is not working yet.
        // public bool IsDone => IsBackgroundAudioClipsLoadedDone &&
        //                       IsEffectAudioClipsLoadedDone &&
        //                       IsVoiceAudioClipsLoadedDone;
        
        /// <summary>
        /// Check background audio clip assets is loaded
        /// </summary>
        private bool IsBackgroundAudioClipResourcesLoadedDone => 
            _backgroundAudioClipResourceHandle.IsValid() && _backgroundAudioClipResourceHandle.IsDone;
        
        /// <summary>
        /// Check effect audio clip assets is loaded
        /// </summary>
        private bool IsEffectAudioClipResourcesLoadedDone => 
            _effectAudioClipResourceHandle.IsValid() && _effectAudioClipResourceHandle.IsDone;
        
        /// <summary>
        /// Check voice audio clip assets is loaded
        /// </summary>
        private bool IsVoiceAudioClipResourcesLoadedDone => 
            _voiceAudioClipResourceHandle.IsValid() && _voiceAudioClipResourceHandle.IsDone;
    }
}
