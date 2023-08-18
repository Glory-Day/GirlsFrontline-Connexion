#region NAMESPACE API

using Object.Manager;
using Utility.Manager;

#endregion

namespace Utility.Command
{
    public class InstantiateAllUIPrefabsCommand : ICommand
    {
        public void Execute()
        {
            LogManager.LogAsAdministrator(
                "Execute <b><i>OnInstantiateAllUIPrefabs()</i></b>");

            UIManager.OnInstantiateAllUIPrefabs();
        }
    }
}
