#region NAMESPACE API

using Manager;

#endregion

namespace Object.UI.Console.Command
{
    public class LoadMainScene : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog(
                "Execute <b><i>OnLoadSceneByName(Scene.Label.Main)</i></b>");

            SceneManager.OnLoadSceneByLabel(Manager.Scene.Label.Main);
        }
    }
}
