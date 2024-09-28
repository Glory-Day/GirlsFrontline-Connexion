using GloryDay.Log;

namespace Object.Character.Enemy
{
    public partial class ThunderCharacter : EnemyCharacter
    {
        #region CONSTANT FIELD API
        
        private const int MaximumAttackCount = 3;

        #endregion
        
        #region COMPONENT FIELD API

        private ProjectileAttackAction _action;

        #endregion

        private int _count;
        
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();
            
            // Initialize projectile attack action component.
            _action = GetComponent<ProjectileAttackAction>();
            
            // Set character states in state machine.
            States.Add(new AttackState(this));
            States.Add(new MoveState(this));
            States.Add(new UseSkill(this));
            
            base.DieState = new DieState(this);
            base.WaitState = new WaitState(this);
        }
        
        protected override void OnEnable()
        {
            LogManager.LogProgress();
            
            base.OnEnable();
            
            FiniteStateMachine.Run(States[1]);
        }
        
        private void Start()
        {
            LogManager.LogProgress();
            
            // Set projectile attack action component.
            _action.AddBulletData(characterData.BulletData[0]);
            _action.AddBulletData(characterData.BulletData[1]);
            _action.SetCharacterDamagePoint(DamagePoint, DefensePenetrationPoint);
        }
    }
}