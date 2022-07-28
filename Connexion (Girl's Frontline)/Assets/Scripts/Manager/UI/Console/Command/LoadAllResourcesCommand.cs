#region NAMESPACE API

using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Manager.UI.Console.Command
{
    public class LoadAllResourcesCommand : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog("Execute <b><i>OnLoadAllResources()</i></b>");

            AssetManager.OnLoadAllResources();

            LogManager.OnDebugLog(LabelType.Success, typeof(ICommand),
                "<b>All Resources</b> are loaded successfully");
        }
    }
}
