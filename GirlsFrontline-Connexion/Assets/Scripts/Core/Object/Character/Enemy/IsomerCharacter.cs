using GloryDay.Debug;

namespace Core.Object.Character.Enemy
{
    public partial class IsomerCharacter : EnemyCharacter
    {
        protected override void Awake()
        {
            Console.LogProgress();
            
            base.Awake();
            
            // Set character states in state machine.
            States.Add(new MoveState(this));
            
            base.DieState = new DieState(this);
            base.WaitState = new WaitState(this);
        }
        
        protected override void OnEnable()
        {
            Console.LogProgress();
            
            base.OnEnable();
            
            FiniteStateMachine.Run(States[0]);
        }
    }
}