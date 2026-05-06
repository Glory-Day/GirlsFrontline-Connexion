using GloryDay.Debug;

namespace Core.Object.Character.Enemy
{
    public partial class NytoIsomerShadowCharacter : EnemyCharacter
    {
        protected override void Awake()
        {
            Console.LogProgress();
            
            base.Awake();
        }
    }
}