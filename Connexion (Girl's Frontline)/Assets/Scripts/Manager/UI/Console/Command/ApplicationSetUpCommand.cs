#region NAMESPACE API

using System.Threading.Tasks;
using Manager.UI.Console.Command;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Manager.UI.Console.Command
{
    public class ApplicationSetUpCommand : ICommand
    {
        private readonly ICommand[] loadCommands;
        private readonly ICommand[] initializeCommands;

        public ApplicationSetUpCommand()
        {
            loadCommands = new ICommand[]
                           {
                               new LoadAllDataCommand(),
                               new LoadAllAssetsCommand()
                           };

            initializeCommands = new ICommand[]
                                 {
                                     new InstantiateAllUIPrefabsCommand(),
                                     new InitializeBackgroundAudioMixerCommand(),
                                     new ChangeBackgroundAudioClipCommand()
                                 };
        }

        private static bool IsLoadedAllResourcesDone()
        {
            LogManager.OnDebugLog(LabelType.Event, typeof(ICommand),
                $"<b>Waiting All Assets</b> is loaded");

            while(!AssetManager.IsLoadedAllAssetsDone()) { }

            return true;
        }

        public async void Execute()
        {
            LogManager.OnDebugLog("Execute <b><i>OnApplicationSetUp()</i></b>");

            for (var i = 0; i < loadCommands.Length; i++) loadCommands[i].Execute();

            await Task.Run(() => Task.FromResult(IsLoadedAllResourcesDone()));

            LogManager.OnDebugLog(LabelType.Success, typeof(ICommand),
                "<b>All Assets</b> are loaded successfully");

            while(!AssetManager.IsLoadedAllAssetsDone()) { }

            for (var i = 0; i < initializeCommands.Length; i++) initializeCommands[i].Execute();
        }
    }
}
