using GloryDay.Debug.Log;

namespace Backend.Object.Character.Enemy
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
