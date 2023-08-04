#region NAMESPACE API

using Object.Manager;
using Util.Manager;

#endregion

namespace Util.Command
{
    public class InstantiateAllUIPrefabsCommand : ICommand
    {
        public void Execute()
        {
            LogManager.LogAdministrator(
                "Execute <b><i>OnInstantiateAllUIPrefabs()</i></b>");

            UIManager.OnInstantiateAllUIPrefabs();
        }
    }
}
