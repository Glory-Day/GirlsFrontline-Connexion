#region NAMESPACE API

using Object.Manager;
using Utility.Manager;

#endregion

namespace Utility.Command
{
    public class LoadMainScene : ICommand
    {
        public void Execute()
        {
            LogManager.LogAsAdministrator(
                "Execute <b><i>OnLoadSceneByName(Scene.Label.Main)</i></b>");

            SceneManager.OnLoadSceneByLabel(Manager.Scene.Label.Main);
        }
    }
}
