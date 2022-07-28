#region NAMESPACE API

using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Manager.UI.Console.Command
{
    public class IsLoadedAllResourcesDoneCommand : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog("Execute <b><i>IsLoadedAllResourcesDone()</i></b>");

            if (AssetManager.IsLoadedAllAssetsDone())
            {
                LogManager.OnDebugLog(LabelType.Success, typeof(ICommand),
                    $"<b>All Resources</b> is loaded successfully");

                return;
            }

            LogManager.OnDebugLog(LabelType.Error, typeof(ICommand),
                $"<b>All Resources</b> is not loaded");
        }
    }
}
