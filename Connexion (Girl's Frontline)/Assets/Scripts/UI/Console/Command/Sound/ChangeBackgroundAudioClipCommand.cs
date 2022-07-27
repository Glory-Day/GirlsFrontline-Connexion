#region NAMESPACE API

using Manager;

#endregion

namespace UI.Console.Command.Sound
{
    public class ChangeBackgroundAudioClipCommand : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog(
                "Execute <b><i>OnChangeBackgroundAudioClip(SceneManager.CurrentSceneName)</i></b>");
            
            SoundManager.OnChangeBackgroundAudioClip(SceneManager.CurrentSceneName);
        }
    }
}
