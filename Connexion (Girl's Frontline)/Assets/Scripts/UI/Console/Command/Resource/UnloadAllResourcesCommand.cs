#region NAMESPACE API

using Manager;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace UI.Console.Command.Resource
{
    public class UnloadAllResourcesCommand : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog("Execute <b><i>OnUnloadAllResources()</i></b>");
            
            ResourceManager.OnUnloadAllResources();
            
            LogManager.OnDebugLog(LabelType.Success, typeof(ICommand), 
                "<b>All Resources</b> are unloaded successfully");
        }
    }
}
