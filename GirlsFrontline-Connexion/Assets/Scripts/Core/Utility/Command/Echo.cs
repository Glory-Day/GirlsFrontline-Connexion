using GloryDay.Debug;

namespace Core.Utility.Command
{
    public class Echo : BaseCommand
    {
        public override void Execute(ParameterData parameterData)
        {
            base.Execute(parameterData);
            
            var text = (Arguments[nameof(Message)] as Message)?.Text;
            Console.LogAsAdministrator(text);
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