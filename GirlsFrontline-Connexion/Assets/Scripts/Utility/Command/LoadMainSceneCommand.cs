#region NAMESPACE API

using Object.Manager;
using Utility.Manager;

#endregion

namespace Utility.Command
{
    public class LoadNextScene : ICommand
    {
        public void Execute()
        {
            LogManager.LogAsAdministrator("Execute <b><i>OnLoadNextScene()</i></b>");

            SceneManager.OnLoadNextScene();
        }
    }
}
