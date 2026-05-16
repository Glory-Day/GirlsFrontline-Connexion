using GloryDay.Debug;
using Core.Utility.Management;

namespace Core.Utility.Command
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
