using UnityEngine;

namespace Utility.State
{
    public abstract class StateBase<T> : IState where T : MonoBehaviour
    {
        protected readonly T Component;
        
        protected StateBase(T component)
        {
            Component = component;
        }
        
        /// <summary>
        /// Initialize the state before its starts.
        /// </summary>
        public abstract void Start();

        /// <summary>
        /// Update the state.
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// End the updating of the state.
        /// </summary>
        public abstract void End();
    }
}