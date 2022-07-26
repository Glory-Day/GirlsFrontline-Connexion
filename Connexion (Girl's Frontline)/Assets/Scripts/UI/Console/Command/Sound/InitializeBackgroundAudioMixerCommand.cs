#region NAMESPACE API

using Manager;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace UI.Console.Command.Sound
{
    public class InitializeBackgroundAudioMixerCommand : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog(LabelType.Event, typeof(ICommand), 
                $"Execute as administrator <b><i>OnInitializeBackgroundAudioMixer()</i></b>");
            
            SoundManager.OnInitializeBackgroundAudioMixer();
            
            LogManager.OnDebugLog(LabelType.Success, typeof(ICommand), 
                $"<b>Background Audio Mixer</b> is initialized completely");
        }
    }
}
