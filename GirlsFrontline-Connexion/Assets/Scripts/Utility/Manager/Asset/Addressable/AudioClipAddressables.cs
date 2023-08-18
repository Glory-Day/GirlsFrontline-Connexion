using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Utility.Manager.Asset.Addressable
{
    public class AudioClipAddressables : IAddressables
    {
        private struct AsyncOperationHandler
        {
            public AsyncOperationHandle<IList<AudioClip>> background;
            public AsyncOperationHandle<IList<AudioClip>> effect;
            public AsyncOperationHandle<IList<AudioClip>> voice;
        }

        private AsyncOperationHandler asyncOperationHandler;
        
        public AudioClipAddressables()
        {
            LogManager.LogProgress();

            asyncOperationHandler = new AsyncOperationHandler();
        }
        
        public void Load()
        {
            LogManager.LogProgress();
            
            asyncOperationHandler.background = Addressables.LoadAssetsAsync(AssetLabel.AudioClip.Background,
                (Action<AudioClip>)LoadBackgroundAudioClips);
            
            //TODO: This code is not working yet.
            // asyncOperationHandler.effect = Addressables.LoadAssetsAsync(AddressableLabel.AudioClip.Effect,
            //     (Action<UnityEngine.AudioClip>)LoadEffectAudioClips);
            // asyncOperationHandler.voice = Addressables.LoadAssetsAsync(AddressableLabel.AudioClip.Voice,
            //     (Action<UnityEngine.AudioClip>)LoadVoiceAudioClips);
        }

        public void Unload()
        {
            LogManager.LogProgress();
            
            UnloadBackgroundAudioClips();
            UnloadEffectAudioClips();
            UnloadVoiceAudioClips();
        }

        public bool Check()
        {
            return IsBackgroundAudioClipsLoadedDone;
            
            //TODO: This code is not working yet.
            // return IsBackgroundAudioClipsLoadedDone &&
            //        IsEffectAudioClipsLoadedDone &&
            //        IsVoiceAudioClipsLoadedDone;
        }
        
        /// <summary>
        /// Load background audio clip assets using addressables
        /// </summary>
        /// <param name="asset"> Loaded asset </param>
        private static void LoadBackgroundAudioClips(AudioClip asset)
        {
            AssetManager.AudioClipAssets.Background.Add(asset.name, asset);
            
            LogManager.LogSuccess($"<b>{asset.name}</b> is loaded");
        }
        
        //TODO: This code is not working yet.
        /// <summary>
        /// Load effect audio clip assets using addressables
        /// </summary>
        /// <param name="asset"> Loaded asset </param>
        private static void LoadEffectAudioClips(AudioClip asset)
        {
            AssetManager.AudioClipAssets.Effect.Add(asset.name, asset);
            
            LogManager.LogSuccess($"<b>{asset.name}</b> is loaded");
        }
        
        //TODO: This code is not working yet.
        /// <summary>
        /// Load voice audio clip assets using addressables
        /// </summary>
        /// <param name="asset"> Loaded asset </param>
        private static void LoadVoiceAudioClips(AudioClip asset)
        {
            AssetManager.AudioClipAssets.Voice.Add(asset.name, asset);
            
            LogManager.LogSuccess($"<b>{asset.name}</b> is loaded");
        }

        /// <summary>
        /// Unload background audio clip assets using addressables
        /// </summary>
        private void UnloadBackgroundAudioClips()
        {
            Addressables.Release(asyncOperationHandler.background);

            LogManager.LogSuccess("<b>All Background Audio Clips</b> are unloaded");
        }
        
        /// <summary>
        /// Unload effect audio clip assets using addressables
        /// </summary>
        private void UnloadEffectAudioClips()
        {
            Addressables.Release(asyncOperationHandler.effect);

            LogManager.LogSuccess("<b>All Effect Audio Clips</b> are unloaded");
        }
        
        /// <summary>
        /// Unload voice audio clip assets using addressables
        /// </summary>
        private void UnloadVoiceAudioClips()
        {
            Addressables.Release(asyncOperationHandler.voice);

            LogManager.LogSuccess("<b>All Voice Audio Clips</b> are unloaded");
        }
        
        /// <summary>
        /// Check background audio clip assets is loaded
        /// </summary>
        private bool IsBackgroundAudioClipsLoadedDone => 
            asyncOperationHandler.background.IsValid() && asyncOperationHandler.background.IsDone;
        
        /// <summary>
        /// Check effect audio clip assets is loaded
        /// </summary>
        private bool IsEffectAudioClipsLoadedDone => 
            asyncOperationHandler.effect.IsValid() && asyncOperationHandler.effect.IsDone;
        
        /// <summary>
        /// Check voice audio clip assets is loaded
        /// </summary>
        private bool IsVoiceAudioClipsLoadedDone => 
            asyncOperationHandler.voice.IsValid() && asyncOperationHandler.voice.IsDone;
    }
}
