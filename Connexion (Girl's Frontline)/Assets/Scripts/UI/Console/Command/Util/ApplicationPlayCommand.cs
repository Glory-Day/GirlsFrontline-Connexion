#region NAMESPACE API

using Manager;

#endregion

namespace UI.Console.Command.Util
{
    public class ApplicationPlayCommand : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog("Execute <b><i>OnApplicationPlay()</i></b>");
            
            GameManager.OnPlay();
        }
    }
}
