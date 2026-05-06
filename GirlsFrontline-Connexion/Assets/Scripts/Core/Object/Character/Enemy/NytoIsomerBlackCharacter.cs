using GloryDay.Debug;

namespace Core.Object.Character.Enemy
{
    public partial class NytoIsomerBlackCharacter : EnemyCharacter
    {
        protected override void Awake()
        {
            Console.LogProgress();
            
            base.Awake();
        }
    }
}