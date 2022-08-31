#region NAMESPACE API

using Manager;

#endregion

namespace Object.UI.Console.Command
{
    public class LoadAllDataCommand : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog(
                "Execute <b><i>OnLoadAllData()</i></b>");

            DataManager.OnLoadAllData();
        }
    }
}
