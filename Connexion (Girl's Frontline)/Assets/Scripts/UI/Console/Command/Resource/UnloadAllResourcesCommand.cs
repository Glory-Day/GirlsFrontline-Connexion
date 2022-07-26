#region NAMESPACE API

using Manager;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace UI.Console.Command.Resource
{
    public class UnloadAllResourceCommand : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog(LabelType.Event, typeof(ICommand), 
                $"Execute as administrator <b><i>OnUnloadAllResources()</i></b>");
            
            ResourceManager.OnUnloadAllResources();
            
            LogManager.OnDebugLog(LabelType.Success, typeof(ICommand), 
                "<b>All resources</b> are unloaded completely");
        }
    }
}
