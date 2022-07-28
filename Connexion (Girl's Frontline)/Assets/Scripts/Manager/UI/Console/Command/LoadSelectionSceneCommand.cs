#region NAMESPACE API

using SceneName = Manager.SceneManager.SceneName;

#endregion

namespace Manager.UI.Console.Command
{
    public class LoadSelectionScene : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog("Execute <b><i>OnLoadSceneByName(SceneName.SelectionScene)</i></b>");

            SceneManager.OnLoadSceneByName(SceneName.SelectionScene);
        }
    }
}
