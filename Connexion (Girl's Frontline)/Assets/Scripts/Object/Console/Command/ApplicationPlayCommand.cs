#region NAMESPACE API

using Interface;
using Manager;

#endregion

namespace Object.Console.Command
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
