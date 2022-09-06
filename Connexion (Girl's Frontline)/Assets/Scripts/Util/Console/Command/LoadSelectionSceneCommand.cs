#region NAMESPACE API

using Manager;

#endregion

namespace Util.Console.Command
{
    public class LoadSelectionScene : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog(
                "Execute <b><i>OnLoadSceneByName(SceneName.SelectionScene)</i></b>");

            SceneManager.OnLoadSceneByLabel(Manager.Scene.Label.Selection);
        }
    }
}
