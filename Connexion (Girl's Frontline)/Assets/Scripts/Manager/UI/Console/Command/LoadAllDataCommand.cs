namespace Manager.UI.Console.Command
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
