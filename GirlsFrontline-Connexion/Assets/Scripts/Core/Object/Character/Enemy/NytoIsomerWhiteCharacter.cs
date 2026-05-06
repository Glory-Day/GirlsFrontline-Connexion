using GloryDay.Debug;

namespace Core.Object.Character.Enemy
{
    public partial class NytoIsomerWhiteCharacter : EnemyCharacter
    {
        protected override void Awake()
        {
            Console.LogProgress();
            
            base.Awake();
        }
    }
}