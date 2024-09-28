using GloryDay.Log;

namespace Object.Character.Enemy
{
    public partial class NytoIsomerShadowCharacter : EnemyCharacter
    {
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();
        }
    }
}