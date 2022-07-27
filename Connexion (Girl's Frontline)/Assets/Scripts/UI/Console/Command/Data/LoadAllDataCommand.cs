#region NAMESPACE API

using Manager;

#endregion

namespace UI.Console.Command.Data
{
    public class LoadAllDataCommand : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog("Execute <b><i>OnLoadAllData()</i></b>");
            
            DataManager.OnLoadAllData();
        }
    }
}