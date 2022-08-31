#region NAMESPACE API

using Manager;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Object.UI.Console.Command
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
                    LabelType.Success, 
                    typeof(ICommand),
                    $"<b>All Resources</b> is loaded successfully");

                return;
            }

            LogManager.OnDebugLog(
                LabelType.Error, 
                typeof(ICommand),
                $"<b>All Resources</b> is not loaded");
        }
    }
}
