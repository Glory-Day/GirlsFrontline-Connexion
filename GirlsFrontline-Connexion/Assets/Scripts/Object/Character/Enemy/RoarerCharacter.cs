using GloryDay.Log;
using UnityEngine;
using Utility.Manager;

namespace Object.Character.Enemy
{
    public partial class RoarerCharacter : EnemyCharacter
    {
        #region COMPONENT FIELD API

        private MeleeAttackAction _action;

        #endregion
        
        #region CONSTANT FIELD API

        private const int MaximumAttackCount = 3;

        #endregion

        private int _count;

        private AudioClip _explosionSound;
        
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();
            
            // Initialize melee attack action component.
            _action = GetComponent<MeleeAttackAction>();
            
            // Set character states in state machine.
            States.Add(new AttackState(this));
            States.Add(new MoveState(this));
            States.Add(new UseSkill(this));
            
            base.DieState = new DieState(this);
            base.WaitState = new WaitState(this);

            var key = DataManager.AudioData.Effect[12];
            _explosionSound = ResourceManager.AudioClipResource.Effect[key];
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
            _action.AddMeleeData(characterData.WeaponData[0]);
            _action.AddMeleeData(characterData.WeaponData[1]);
            _action.SetCharacterDamagePoint(DamagePoint, DefensePenetrationPoint);
        }
    }
}