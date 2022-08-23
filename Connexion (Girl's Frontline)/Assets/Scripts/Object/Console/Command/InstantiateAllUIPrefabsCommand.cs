#region NAMESPACE API

using Interface;
using Manager;

#endregion

namespace Object.Console.Command
{
    public class InstantiateAllUIPrefabsCommand : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog(
                "Execute <b><i>OnInstantiateAllUIPrefabs()</i></b>");

            UIManager.OnInstantiateAllUIPrefabs();
        }
    }
}
