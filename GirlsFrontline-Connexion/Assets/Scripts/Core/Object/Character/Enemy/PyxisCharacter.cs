using GloryDay.Debug;

namespace Core.Object.Character.Enemy
{
    public partial class PyxisCharacter : EnemyCharacter
    {
        #region COMPONENT FIELD API

        private ProjectileAttackAction _action;

        #endregion
        
        #region CONSTANT FIELD API

        private const float MaximumCoolDownTime = 15f;

        #endregion
        
        protected override void Awake()
        {
            Console.LogProgress();
            
            base.Awake();
            
            // Initialize projectile attack action component.
            _action = GetComponent<ProjectileAttackAction>();
            
            // Set character states in state machine.
            States.Add(new AttackState(this));
            States.Add(new MoveState(this));
            States.Add(new MoveUpState(this));
            States.Add(new CoolDownState(this));
            
            base.DieState = new DieState(this);
            base.WaitState = new WaitState(this);
        }
        
        protected override void OnEnable()
        {
            Console.LogProgress();
            
            base.OnEnable();
            
            HealthPointBar.Collider.enabled = false;
            
            FiniteStateMachine.Run(States[1]);
        }
        
        private void Start()
        {
            Console.LogProgress();
            
            // Set projectile attack action component.
            _action.AddBulletData(characterData.BulletData[0]);
            _action.SetCharacterDamagePoint(DamagePoint, DefensePenetrationPoint);
        }
    }
}