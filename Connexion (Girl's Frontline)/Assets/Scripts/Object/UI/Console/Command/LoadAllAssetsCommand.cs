﻿#region NAMESPACE API

using Manager;
using LabelType = Manager.Log.Label.LabelType;

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
                LabelType.Success, 
                typeof(ICommand),
                "<b>All Assets</b> are loaded successfully");
        }
    }
}