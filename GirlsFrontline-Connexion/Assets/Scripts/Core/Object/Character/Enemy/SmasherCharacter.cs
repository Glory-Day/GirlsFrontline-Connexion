using GloryDay.Debug;

namespace Core.Object.Character.Enemy
{
    public partial class SmasherCharacter : EnemyCharacter
    {
        protected override void Awake()
        {
            Console.LogProgress();
            
            base.Awake();
        }
    }
}