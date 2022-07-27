#region NAMESPACE API

using Manager;
using SceneName = Manager.SceneManager.SceneName;

#endregion

namespace UI.Console.Command.Util
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
