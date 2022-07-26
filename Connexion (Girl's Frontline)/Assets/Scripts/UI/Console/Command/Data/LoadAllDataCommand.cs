#region NAMESPACE API

using Manager;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace UI.Console.Command.Data
{
    public class LoadAllDataCommand : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog(LabelType.Event, typeof(ICommand), 
                $"Execute as administrator <b><i>OnLoadAllData()</i></b>");
            
            DataManager.OnLoadAllData();
        }
    }
}