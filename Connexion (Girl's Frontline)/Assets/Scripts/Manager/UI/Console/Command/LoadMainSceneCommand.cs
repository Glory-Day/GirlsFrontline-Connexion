#region NAMESPACE API

using SceneName = Manager.SceneManager.SceneName;

#endregion

namespace Manager.UI.Console.Command
{
    public class LoadMainScene : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog("Execute <b><i>OnLoadSceneByName(SceneName.MainScene)</i></b>");

            SceneManager.OnLoadSceneByName(SceneName.MainScene);
        }
    }
}
