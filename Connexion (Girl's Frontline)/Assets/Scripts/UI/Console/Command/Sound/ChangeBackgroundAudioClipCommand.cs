#region NAMESPACE API

using Manager;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace UI.Console.Command.Sound
{
    public class ChangeBackgroundAudioClipCommand : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog(LabelType.Event, typeof(ICommand), 
                $"Execute as administrator <b><i>OnChangeBackgroundAudioClip()</i></b> for current scene");
            
            SoundManager.OnChangeBackgroundAudioClip(SceneManager.CurrentSceneName);
        }
    }
}
