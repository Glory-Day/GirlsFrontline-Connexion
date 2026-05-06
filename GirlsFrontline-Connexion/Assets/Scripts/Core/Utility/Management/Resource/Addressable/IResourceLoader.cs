<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/Resource/Addressable/IResourceLoader.cs
﻿namespace Core.Utility.Manager.Resource.Addressable
========
﻿namespace Backend.Utility.Management.Resource.Addressable
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/Resource/Addressable/IResourceLoader.cs
{
    public interface IResourceLoader
    {
        /// <summary>
        /// Load assets using addressables
        /// </summary>
        void Load();

        /// <summary>
        /// Unload assets using addressables
        /// </summary>
        void Unload();

        /// <summary>
        /// Check assets is Loaded
        /// </summary>
        bool IsLoadedDone { get; }
    }
}
