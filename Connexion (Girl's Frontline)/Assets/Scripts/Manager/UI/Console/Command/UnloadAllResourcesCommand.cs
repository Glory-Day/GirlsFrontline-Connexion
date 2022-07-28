#region NAMESPACE API

using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Manager.UI.Console.Command
{
    public class UnloadAllResourcesCommand : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog("Execute <b><i>OnUnloadAllResources()</i></b>");

            AssetManager.OnUnloadAllResources();

            LogManager.OnDebugLog(LabelType.Success, typeof(ICommand),
                "<b>All Resources</b> are unloaded successfully");
        }
    }
}
