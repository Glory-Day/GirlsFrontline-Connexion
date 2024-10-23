using GloryDay;
using GloryDay.Debug.Log;
using Utility.Manager.Resource;
using Utility.Manager.Resource.Addressable;

namespace Utility.Manager
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
            LogManager.LogProgress();
        }
        
        private void LoadAllResources()
        {
            LogManager.LogProgress();
            
            var length = _resourceLoaders.Length;
            for (var i = 0; i < length; i++)
            {
                _resourceLoaders[i].Load();
            }
        }
        
        private void UnloadAllResources()
        {
            LogManager.LogProgress();
            
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
            LogManager.LogProgress();
            
            Instance.LoadAllResources();
        }

        /// <summary>
        /// Unload all loaded resources inside the application.
        /// </summary>
        public static void OnUnloadAllResources()
        {
            LogManager.LogProgress();
            
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
