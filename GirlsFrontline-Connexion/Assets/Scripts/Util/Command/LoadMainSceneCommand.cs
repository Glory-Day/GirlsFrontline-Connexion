#region NAMESPACE API

using Object.Manager;
using Util.Manager;

#endregion

namespace Util.Command
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
