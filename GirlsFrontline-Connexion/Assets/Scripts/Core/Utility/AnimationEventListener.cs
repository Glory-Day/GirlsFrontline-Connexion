using System;
using UnityEngine;
using UnityEngine.Events;

using Console = GloryDay.Debug.Console;

namespace Core.Utility.Animation
{
    /// <summary>
    /// Event listener for animation component
    /// </summary>
    public class AnimationEventListener : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent[] events;

        /// <summary>
        /// Invoke all registered events
        /// </summary>
        public void InvokeAllEvents()
        {
            var length = events.Length;
            for (var i = 0; i < length; i++)
            {
                events[i].Invoke();
            }
        }

        /// <summary>
        /// Invoke event that match the index among registered events
        /// </summary>
        /// <param name="index"> Index of registered events </param>
        public void InvokeEvent(int index)
        {
            try
            {
                var length = events.Length;
                if (0 <= index && index < length)
                {
                    events[index].Invoke();
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.LogError(exception.Message);
            }
        }
    }
}
