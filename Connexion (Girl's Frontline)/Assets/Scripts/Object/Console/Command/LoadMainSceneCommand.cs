#region NAMESPACE API

using Interface;
using Manager;
using SceneName = Manager.SceneManager.SceneName;

#endregion

namespace Object.Console.Command
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
