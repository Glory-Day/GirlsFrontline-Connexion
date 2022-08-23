#region NAMESPACE API

using Interface;
using Manager;

#endregion

namespace Object.Console.Command
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
