<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/ResourceManager.cs
﻿using GloryDay.Debug;
using GloryDay.Utility;
using Core.Utility.Manager.Resource;
using Core.Utility.Manager.Resource.Addressable;

namespace Core.Utility.Manager
========
﻿using Backend.Utility.Management.Resource;
using Backend.Utility.Management.Resource.Addressable;
using GloryDay;
using GloryDay.Debug.Log;

namespace Backend.Utility.Management
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/ResourceManager.cs
{
    public class ResourceManager : Singleton<ResourceManager>
    {
        private readonly IResourceLoader[] _resourceLoaders = {
                                                                  new AudioClipResourceLoader(),
                                                                  new GameObjectResourceLoader(),
                                                                  new TextResourceLoader(),
                                                                  new UIResourceLoader()
                                                              };

        private readonly AudioClipResource _audioClipResource = new AudioClipResource();
        private readonly GameObjectResource _gameObjectResource = new GameObjectResource();
        private readonly TextResource _textResource = new TextResource();
        private readonly UIResource _uiResource = new UIResource();

        private ResourceManager()
        {
            Console.LogProgress();
        }

        private void LoadAllResources()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/ResourceManager.cs
            Console.LogProgress();
========
            LogManager.LogProgress();
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/ResourceManager.cs

            var length = _resourceLoaders.Length;
            for (var i = 0; i < length; i++)
            {
                _resourceLoaders[i].Load();
            }
        }

        private void UnloadAllResources()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/ResourceManager.cs
            Console.LogProgress();
========
            LogManager.LogProgress();
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/ResourceManager.cs

            var length = _resourceLoaders.Length;
            for (var i = 0; i < length; i++)
            {
                _resourceLoaders[i].Unload();
            }
        }

        #region STATIC METHOD API

        /// <summary>
        /// Loads all the resources that compose the application.
        /// </summary>
        public static void OnLoadAllResources()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/ResourceManager.cs
            Console.LogProgress();
========
            LogManager.LogProgress();
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/ResourceManager.cs

            Instance.LoadAllResources();
        }

        /// <summary>
        /// Unload all loaded resources inside the application.
        /// </summary>
        public static void OnUnloadAllResources()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/ResourceManager.cs
            Console.LogProgress();
========
            LogManager.LogProgress();
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/ResourceManager.cs

            Instance.UnloadAllResources();
        }

        #endregion

        #region STATIC PROPERTIES API

        /// <summary>
        /// Check all resources is loaded done.
        /// </summary>
        public static bool IsAllResourcesLoadedDone
        {
            get
            {
                var length = Instance._resourceLoaders.Length;
                for (var i = 0; i < length; i++)
                {
                    if (Instance._resourceLoaders[i].IsLoadedDone == false)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        /// <summary>
        /// Resource related to audio clip
        /// </summary>
        public static AudioClipResource AudioClipResource => Instance._audioClipResource;

        /// <summary>
        /// Resource related to game object
        /// </summary>
        public static GameObjectResource GameObjectResource => Instance._gameObjectResource;

        /// <summary>
        /// Resource related to text data
        /// </summary>
        public static TextResource TextResource => Instance._textResource;

        public static UIResource UIResource => Instance._uiResource;

        #endregion
    }
}
