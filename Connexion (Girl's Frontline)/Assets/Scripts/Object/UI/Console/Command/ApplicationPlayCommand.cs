#region NAMESPACE API

using Manager;

#endregion

namespace Object.UI.Console.Command
{
    public class ApplicationPlayCommand : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog(
                "Execute <b><i>OnApplicationPlay()</i></b>");

            GameManager.OnPlay();
        }
    }
}
