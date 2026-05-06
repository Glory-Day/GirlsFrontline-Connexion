using GloryDay.Debug;

namespace Core.Utility.State
{
    public class FiniteStateMachine
    {
        private IState _current;
        
        /// <summary>
        /// Run the initial state of the finite state machine.
        /// </summary>
        /// <param name="state"> The initial state. </param>
        public void Run(IState state)
        {
            Console.LogProgress();
            
            _current = state;
            _current.Start();

            Previous = null;
        }
        
        /// <summary>
        /// Stop the current running state and update it to a new state.
        /// </summary>
        /// <param name="state"> New state for running. </param>
        public void ChangeTo(IState state)
        {
            // Save the current state.
            Previous = _current;
            
            _current.End();
            _current = state;
            
            Console.LogMessage("<b>Finite State Machine</b> is updated.");
            
            _current.Start();
        }
        
        /// <summary>
        /// Update the running current state on the finite state machine. 
        /// </summary>
        public void Update()
        {
            _current.Update();
        }

        /// <summary>
        /// Shut down the running finite state machine.
        /// </summary>
        public void ShutDown()
        {
            Console.LogProgress();
            
            _current?.End();
            _current = null;
            
            Previous = null;
        }
        
        /// <summary>
        /// Previously running state in finite state machine.
        /// </summary>
        public IState Previous { get; private set; }
    }
}
