#region NAMESPACE API

using Interface;
using Manager;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Object.Console.Command
{
    public class UnloadAllAssetsCommand : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog("Execute <b><i>OnUnloadAllAssets()</i></b>");

            AssetManager.OnUnloadAllAssets();

            LogManager.OnDebugLog(LabelType.Success, typeof(ICommand),
                "<b>All Assets</b> are unloaded successfully");
        }
    }
}
