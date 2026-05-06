using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using GloryDay.Debug;

<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/Resource/Addressable/TextResourceLoader.cs
using Console = GloryDay.Debug.Console;

namespace Core.Utility.Manager.Resource.Addressable
========
namespace Backend.Utility.Management.Resource.Addressable
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/Resource/Addressable/TextResourceLoader.cs
{
    public class TextResourceLoader : IResourceLoader
    {
        private AsyncOperationHandle<IList<UnityEngine.TextAsset>> _dataResourceHandle;

        public void Load()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/Resource/Addressable/TextResourceLoader.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/Resource/Addressable/TextResourceLoader.cs
            _dataResourceHandle = Addressables.LoadAssetsAsync(
                AddressableLabelGroup.Text.Data, (Action<UnityEngine.TextAsset>)LoadDataResources);
        }

        public void Unload()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/Resource/Addressable/TextResourceLoader.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/Resource/Addressable/TextResourceLoader.cs
            UnloadDataResources();
        }

        /// <summary>
        /// Load data assets using addressables
        /// </summary>
        /// <param name="resource"> Loaded asset </param>
        private static void LoadDataResources(UnityEngine.TextAsset resource)
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/Resource/Addressable/TextResourceLoader.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/Resource/Addressable/TextResourceLoader.cs
            ResourceManager.TextResource.Data.Add(resource.name, resource);

            var name = string.Concat(
                resource.name.Select(ch => char.IsUpper(ch) ? " " + ch : ch.ToString())).Substring(1);
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/Resource/Addressable/TextResourceLoader.cs
            
            Console.LogSuccess($"<b>{name}</b> is loaded");
========

            LogManager.LogSuccess($"<b>{name}</b> is loaded");
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/Resource/Addressable/TextResourceLoader.cs
        }

        /// <summary>
        /// Unload data assets using addressables
        /// </summary>
        private void UnloadDataResources()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/Resource/Addressable/TextResourceLoader.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/Resource/Addressable/TextResourceLoader.cs
            Addressables.Release(_dataResourceHandle);

            Console.LogSuccess("<b>All Data</b> are unloaded");
        }

        public bool IsLoadedDone => _dataResourceHandle.IsValid() && _dataResourceHandle.IsDone;
    }
}
