#region NAMESPACE API

using Manager;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace UI.Console.Command.Resource
{
    public class LoadAllResourceCommand : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog(LabelType.Event, typeof(ICommand), 
                $"Execute as administrator <b><i>OnLoadAllResources()</i></b>");
            
            ResourceManager.OnLoadAllResources();
            
            LogManager.OnDebugLog(LabelType.Success, typeof(ICommand), 
                "<b>All Resources</b> are loaded completely");
        }
    }
}
