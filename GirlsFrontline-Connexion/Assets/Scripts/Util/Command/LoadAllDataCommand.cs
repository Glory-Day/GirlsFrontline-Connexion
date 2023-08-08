#region NAMESPACE API

using Util.Manager;

#endregion

namespace Util.Command
{
    public class LoadAllDataCommand : ICommand
    {
        public void Execute()
        {
            LogManager.LogAsAdministrator(
                "Execute <b><i>OnLoadAllData()</i></b>");

            DataManager.OnLoadAllData();
        }
    }
}
