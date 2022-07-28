#region NAMESPACE API

using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Manager.UI.Console.Command
{
    public class InitializeBackgroundAudioMixerCommand : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog("Execute <b><i>OnInitializeBackgroundAudioMixer()</i></b>");

            SoundManager.OnInitializeBackgroundAudioMixer();

            LogManager.OnDebugLog(LabelType.Success, typeof(ICommand),
                $"<b>Background Audio Mixer</b> is initialized successfully");
        }
    }
}
