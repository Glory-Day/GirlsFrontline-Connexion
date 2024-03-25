using GloryDay.Log;
using Library.UI.CommandConsole;
using Library.UI.CommandConsole.Utils;

namespace Utility.Command
{
    public class Echo : BaseCommand
    {
        public override void Execute(ParameterData parameterData)
        {
            base.Execute(parameterData);
            
            var text =(Arguments[nameof(Message)] as Message)?.Text;
            LogManager.LogAsAdministrator(text);
        }

        private class Message : BaseArgument
        {
            public override void SetProperties(string[] data)
            {
                Text = TypeConverter.ToString(data[0]);
            }
            
            public string Text { get; private set; }
        }
    }
}