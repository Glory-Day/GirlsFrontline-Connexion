using GloryDay.Log;

namespace Object.Character.Enemy
{
    public partial class TeslatrooperCharacter : EnemyCharacter
    {
        #region CONSTANT FIELD API

        private const float AdditionalDefense = 1000f;
        private const float MaximumCoolDownTime = 15f;

        #endregion
        
        #region COMPONENT FIELD API

        private MeleeAttackAction _meleeAttackAction;
        private ProjectileAttackAction _projectileAttackAction;

        
        #endregion

        private float _coolDownTime;
        
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();
            
            // Initialize melee attack action component.
            _meleeAttackAction = GetComponent<MeleeAttackAction>();
            
            // Initialize projectile attack action component.
            _projectileAttackAction = GetComponent<ProjectileAttackAction>();
            
            // Set character states in state machine.
            States.Add(new AttackState(this));
            States.Add(new MoveState(this));
            States.Add(new UseSkill01(this));
            States.Add(new UseSkill02(this));
            
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
            
            // Set melee attack action component.
            _meleeAttackAction.AddMeleeData(characterData.WeaponData[0]);
            _meleeAttackAction.SetCharacterDamagePoint(DamagePoint, DefensePenetrationPoint);
            
            // Set projectile attack action component.
            _projectileAttackAction.AddGrenadeData(characterData.GrenadeData[0]);
            _projectileAttackAction.SetCharacterDamagePoint(DamagePoint, DefensePenetrationPoint);
        }

        protected override void Update()
        {
            base.Update();
            
            _coolDownTime += DeltaTime;
        }
    }
}