#region NAMESPACE API

using Manager;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace UI.Console.Command.Resource
{
    public class IsLoadedAllResourcesDoneCommand : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog("Execute <b><i>IsLoadedAllResourcesDone()</i></b>");
            
            if (ResourceManager.IsLoadedAllResourcesDone())
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
