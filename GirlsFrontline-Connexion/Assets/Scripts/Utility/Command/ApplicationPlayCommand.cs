#region NAMESPACE API

using Utility.Manager;

#endregion

namespace Utility.Command
{
    public class ApplicationPlayCommand : ICommand
    {
        public void Execute()
        {
            LogManager.LogAsAdministrator("Execute <b><i>OnApplicationPlay()</i></b>");

            GameManager.OnPlay();
        }
    }
}
