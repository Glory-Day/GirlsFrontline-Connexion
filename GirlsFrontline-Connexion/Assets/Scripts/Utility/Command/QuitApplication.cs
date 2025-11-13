using System;
using Library.UI.CommandConsole;
using Backend.Utility.Management;

namespace Backend.Utility.Command
{
    public class QuitApplication : BaseCommand
    {
        public override void Execute(ParameterData data)
        {
            base.Execute(data);

            ApplicationManager.Quit();
        }
    }
}
