#region NAMESPACE API

using Manager;
using Label = Manager.Log.Label;

#endregion

namespace Util.Console.Command
{
    public class IsLoadedAllAssetsDoneCommand : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog(
                "Execute <b><i>IsLoadedAllAssetsDoneCommand()</i></b>");

            if (AssetManager.IsLoadedAllAssetsDone())
            {
                LogManager.OnDebugLog(
                    Label.Success, 
                    typeof(ICommand),
                    $"<b>All Resources</b> is loaded successfully");

                return;
            }

            LogManager.OnDebugLog(
                Label.Error, 
                typeof(ICommand),
                $"<b>All Resources</b> is not loaded");
        }
    }
}
