#region NAMESPACE API

using Manager;
using Label = Manager.Log.LogLabel.Label;

#endregion

namespace Object.UI.Console.Command
{
    public class UnloadAllAssetsCommand : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog(
                "Execute <b><i>OnUnloadAllAssets()</i></b>");

            AssetManager.OnUnloadAllAssets();

            LogManager.OnDebugLog(
                Label.Success, 
                typeof(ICommand),
                "<b>All Assets</b> are unloaded successfully");
        }
    }
}
