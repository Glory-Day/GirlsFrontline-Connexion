using Library.UI.CommandConsole;
using Utility.Manager;

namespace Utility.Command
{
    public class PlayApplication : BaseCommand
    {
        public override void Execute(ParameterData data)
        {
            base.Execute(data);

            GameManager.OnApplicationPlay();
        }
    }
}