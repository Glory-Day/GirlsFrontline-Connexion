using GloryDay.Debug.Log;

namespace Object.Character.Enemy
{
    public partial class NytoIsomerWhiteCharacter : EnemyCharacter
    {
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();
        }
    }
}