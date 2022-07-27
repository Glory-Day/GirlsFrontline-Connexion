namespace UI.Console
{
    public static class CommandName
    {
        public const string LoadAllDataCommand             = "OnLoadAllData";
        public const string LoadAllResourcesCommand        = "OnLoadAllResources";
        public const string UnloadAllResourcesCommand      = "OnUnloadAllResources";
        public const string IsAllResourcesLoadedCommand    = "IsLoadedAllResourcesDone";
        public const string InitializeBackgroundAudioMixer = "OnInitializeBackgoundAudioMixer";
        public const string ChangeBackgroundAudioClip      = "OnChangeBackgroundAudioClip --CurrentScene";
        public const string InstantiateAllUIPrefabsCommand = "OnInstantiateAllUIPrefabs";
        public const string LoadMainScene                  = "OnLoadScene --Name Main";
        public const string LoadSelectionScene             = "OnLoadScene --Name Selection";
        public const string ApplicationQuit                = "OnApplicationQuit";
        public const string ApplicationSetUp               = "OnApplicationSetUp";
        public const string ApplicationPlay                = "OnApplicationPlay";
    }
}