namespace Manager.UI.Console.Command
{
    public class ApplicationQuitCommand : ICommand
    {
        public void Execute()
        {
            LogManager.OnDebugLog("Execute <b><i>OnApplicationQuit()</i></b>");

            GameManager.OnQuit();
        }
    }
}
