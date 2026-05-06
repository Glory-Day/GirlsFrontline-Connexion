using System.Collections;
using System.Collections.Generic;
using GloryDay.Debug;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Utility
{
    public class Bootstrap : MonoBehaviour
    {
        #region SERIALIZABLE FIELD API

        [SerializeField] private List<UnityEvent> progresses;

        #endregion

        private int _count;

        public void Run()
        {
            Console.LogProgress();
            
            StartCoroutine(Running());
        }

        private IEnumerator Running()
        {
            _count = 0;

            var count = progresses.Count;
            while (IsCompleted == false)
            {
                for (var i = 0; i < count; i++)
                {
                    progresses[i].Invoke();
                    _count++;
                    
                    yield return null;
                }
            }
        }

        public void Add(UnityAction callback)
        {
            Console.LogProgress();
            
            var @event = new UnityEvent();
            @event.AddListener(callback);
            
            progresses.Add(@event);
        }

        public void Insert(int index, UnityAction callback)
        {
            Console.LogProgress();
            
            progresses[index].AddListener(callback);
        }

        public bool IsCompleted => progresses.Count == _count;
    }
}