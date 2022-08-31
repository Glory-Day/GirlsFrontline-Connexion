﻿#region NAMESPACE API

using Manager;
using Label = Manager.Log.LogLabel.Label;

#endregion

namespace Object.UI.Console.Command
{
    public class LoadAllAssetsCommand : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog(
                "Execute <b><i>OnLoadAllAssets()</i></b>");

            AssetManager.OnLoadAllAssets();

            LogManager.OnDebugLog(
                Label.Success, 
                typeof(ICommand),
                "<b>All Assets</b> are loaded successfully");
        }
    }
}
