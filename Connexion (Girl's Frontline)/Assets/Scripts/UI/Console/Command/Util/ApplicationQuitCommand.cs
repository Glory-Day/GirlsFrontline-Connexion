#region NAMESPACE API

using Manager;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace UI.Console.Command.Util
{
    public class ApplicationQuitCommand : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog(LabelType.Event, typeof(ICommand), 
                $"Execute as administrator <b><i>OnQuit()</i></b>");
            
            GameManager.OnQuit();
        }
    }
}
