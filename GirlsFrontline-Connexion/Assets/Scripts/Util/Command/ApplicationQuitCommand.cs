#region NAMESPACE API

using Util.Manager;

#endregion

namespace Util.Command
{
    public class ApplicationQuitCommand : ICommand
    {
        public void Execute()
        {
            LogManager.LogAdministrator(
                "Execute <b><i>OnApplicationQuit()</i></b>");

            GameManager.OnQuit();
        }
    }
}
