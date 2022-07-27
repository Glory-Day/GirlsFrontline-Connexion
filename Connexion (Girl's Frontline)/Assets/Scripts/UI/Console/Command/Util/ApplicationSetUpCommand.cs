#region NAMESPACE API

using System.Threading.Tasks;
using Manager;
using LabelType = Manager.Log.Label.LabelType;

using UI.Console.Command.Data;
using UI.Console.Command.Resource;
using UI.Console.Command.Sound;
using UI.Console.Command.UI;

#endregion

namespace UI.Console.Command.Util
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
                new LoadAllResourcesCommand()
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
                $"<b>Waiting All Resources</b> is loaded");
            
            while (!ResourceManager.IsLoadedAllResourcesDone()) {}

            return true;
        }
        
        public async void Execute()
        {
            LogManager.OnDebugLog("Execute <b><i>OnApplicationSetUp()</i></b>");
            
            for (var i = 0; i < loadCommands.Length; i++)
            {
                loadCommands[i].Execute();
            }

            await Task.Run(() => Task.FromResult(IsLoadedAllResourcesDone()));
            
            LogManager.OnDebugLog(LabelType.Success, typeof(ICommand), 
                "<b>All Resources</b> are loaded successfully");
            
            while (!ResourceManager.IsLoadedAllResourcesDone()) {}
            
            for (var i = 0; i < initializeCommands.Length; i++)
            {
                initializeCommands[i].Execute();
            }
        }
    }
}
