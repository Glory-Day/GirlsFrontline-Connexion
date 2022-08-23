namespace Object.Console.Command
{
    /// <summary>
    /// <b>Command</b> name
    /// </summary>
    public static class CommandName
    {
        private const string LoadAllDataCommand             = "OnLoadAllData";
        private const string LoadAllAssetsCommand           = "OnLoadAllAssets";
        private const string UnloadAllAssetsCommand         = "OnUnloadAllAssets";
        private const string IsAllAssetsLoadedCommand       = "IsLoadedAllAssetsDone";
        private const string ChangeBackgroundAudioClip      = "OnChangeBackgroundAudioClip --CurrentScene";
        private const string InstantiateAllUIPrefabsCommand = "OnInstantiateAllUIPrefabs";
        private const string LoadMainScene                  = "OnLoadScene --Name Main";
        private const string LoadSelectionScene             = "OnLoadScene --Name Selection";
        private const string ApplicationQuit                = "OnApplicationQuit";
        private const string ApplicationSetUp               = "OnApplicationSetUp";
        private const string ApplicationPlay                = "OnApplicationPlay";

        public static string[] Names => new[]
                                        {
                                            LoadAllDataCommand,
                                            LoadAllAssetsCommand,
                                            UnloadAllAssetsCommand,
                                            IsAllAssetsLoadedCommand,
                                            ChangeBackgroundAudioClip,
                                            InstantiateAllUIPrefabsCommand,
                                            LoadMainScene,
                                            LoadSelectionScene,
                                            ApplicationQuit,
                                            ApplicationSetUp,
                                            ApplicationPlay
                                        };
    }
}
