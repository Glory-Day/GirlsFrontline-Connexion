#region NAMESPACE API

using Manager;
using SceneName = Manager.SceneManager.SceneName;

#endregion

namespace UI.Console.Command.Util
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
