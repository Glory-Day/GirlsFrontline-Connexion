#region NAMESPACE API

using Util.Manager;

#endregion

namespace Util.Command
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
