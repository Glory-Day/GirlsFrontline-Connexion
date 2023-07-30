#region NAMESPACE API

using Object.Manager;
using Util.Manager;

#endregion

namespace Util.Command
{
    public class ChangeBackgroundAudioClipCommand : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog(
                "Execute <b><i>OnChangeBackgroundAudioClip(SceneManager.CurrentSceneName)</i></b>");

            SoundManager.OnChangeBackgroundAudioClip(SceneManager.CurrentSceneLabel);
        }
    }
}
