namespace Util.State
{
    public class StateMachine
    {
        public StateMachine(IState state)
        {
            CurrentState = state;
            CurrentState.Enter();
        }
        
        /// <summary>
        /// Exit current state and set new state
        /// </summary>
        /// <param name="state"> New state </param>
        public void SetState(IState state)
        {
            // Do not set same state
            if (CurrentState == state)
            {
                return;
            }
            
            // Before state change, exit state
            CurrentState.Exit();

            // Change state
            CurrentState = state;
            
            // Enter new state
            CurrentState.Enter();
        }
        
        /// <summary>
        /// Update is called once per frame
        /// </summary>
        public void OnUpdate()
        {
            CurrentState.Update();
        }

        #region PROPERTIES API

        public IState CurrentState { get; private set; }

        #endregion
    }
}
