using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using GloryDay.Debug;

<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/Resource/Addressable/AudioClipResourceLoader.cs
using Console = GloryDay.Debug.Console;

namespace Core.Utility.Manager.Resource.Addressable
========
namespace Backend.Utility.Management.Resource.Addressable
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/Resource/Addressable/AudioClipResourceLoader.cs
{
    public class AudioClipResourceLoader : IResourceLoader
    {
        private AsyncOperationHandle<IList<AudioClip>> _backgroundAudioClipResourceHandle;
        private AsyncOperationHandle<IList<AudioClip>> _effectAudioClipResourceHandle;
        private AsyncOperationHandle<IList<AudioClip>> _voiceAudioClipResourceHandle;

        public void Load()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/Resource/Addressable/AudioClipResourceLoader.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/Resource/Addressable/AudioClipResourceLoader.cs
            _backgroundAudioClipResourceHandle = Addressables.LoadAssetsAsync(
                AddressableLabelGroup.AudioClip.Background, (Action<AudioClip>)LoadBackgroundAudioClipResources);
            _effectAudioClipResourceHandle = Addressables.LoadAssetsAsync(
                AddressableLabelGroup.AudioClip.Effect, (Action<AudioClip>)LoadEffectAudioClipResources);
            _voiceAudioClipResourceHandle = Addressables.LoadAssetsAsync(
                AddressableLabelGroup.AudioClip.Voice, (Action<AudioClip>)LoadVoiceAudioClipResources);
        }

        public void Unload()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/Resource/Addressable/AudioClipResourceLoader.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/Resource/Addressable/AudioClipResourceLoader.cs
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
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/Resource/Addressable/AudioClipResourceLoader.cs
            
            Console.LogSuccess($"<b>{resource.name}</b> is loaded");
========

            LogManager.LogSuccess($"<b>{resource.name}</b> is loaded");
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/Resource/Addressable/AudioClipResourceLoader.cs
        }

        /// <summary>
        /// Load effect audio clip assets using addressables
        /// </summary>
        /// <param name="resource"> Loaded asset </param>
        private static void LoadEffectAudioClipResources(AudioClip resource)
        {
            ResourceManager.AudioClipResource.Effect.Add(resource.name, resource);
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/Resource/Addressable/AudioClipResourceLoader.cs
            
            Console.LogSuccess($"<b>{resource.name}</b> is loaded");
========

            LogManager.LogSuccess($"<b>{resource.name}</b> is loaded");
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/Resource/Addressable/AudioClipResourceLoader.cs
        }

        /// <summary>
        /// Load voice audio clip assets using addressables
        /// </summary>
        /// <param name="resource"> Loaded asset </param>
        private static void LoadVoiceAudioClipResources(AudioClip resource)
        {
            ResourceManager.AudioClipResource.Voice.Add(resource.name, resource);
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/Resource/Addressable/AudioClipResourceLoader.cs
            
            Console.LogSuccess($"<b>{resource.name}</b> is loaded");
========

            LogManager.LogSuccess($"<b>{resource.name}</b> is loaded");
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/Resource/Addressable/AudioClipResourceLoader.cs
        }

        /// <summary>
        /// Unload background audio clip assets using addressables
        /// </summary>
        private void UnloadBackgroundAudioClipResources()
        {
            Addressables.Release(_backgroundAudioClipResourceHandle);

            Console.LogSuccess("<b>All Background Audio Clips</b> are unloaded");
        }

        /// <summary>
        /// Unload effect audio clip assets using addressables
        /// </summary>
        private void UnloadEffectAudioClipResources()
        {
            Addressables.Release(_effectAudioClipResourceHandle);

            Console.LogSuccess("<b>All Effect Audio Clips</b> are unloaded");
        }

        /// <summary>
        /// Unload voice audio clip assets using addressables
        /// </summary>
        private void UnloadVoiceAudioClipResources()
        {
            Addressables.Release(_voiceAudioClipResourceHandle);

            Console.LogSuccess("<b>All Voice Audio Clips</b> are unloaded");
        }

        public bool IsLoadedDone => IsBackgroundAudioClipResourcesLoadedDone &&
                                    IsEffectAudioClipResourcesLoadedDone &&
                                    IsVoiceAudioClipResourcesLoadedDone;

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
