﻿namespace Manager.UI.Console.Command
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