#region NAMESPACE API

using Manager;

#endregion

namespace UI.Console.Command.Util
{
    public class ApplicationQuitCommand : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog("Execute <b><i>OnApplicationQuit()</i></b>");
            
            GameManager.OnQuit();
        }
    }
}
