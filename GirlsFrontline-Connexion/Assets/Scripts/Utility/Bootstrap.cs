using System.Collections;
using System.Collections.Generic;
using GloryDay.Log;
using UnityEngine;
using UnityEngine.Events;

namespace Utility
{
    public class Bootstrap : MonoBehaviour
    {
        #region SERIALIZABLE FIELD API

        [SerializeField] private List<UnityEvent> progresses;

        #endregion

        private int _count;

        public void Run()
        {
            LogManager.LogProgress();
            
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
            LogManager.LogProgress();
            
            var @event = new UnityEvent();
            @event.AddListener(callback);
            
            progresses.Add(@event);
        }

        public void Insert(int index, UnityAction callback)
        {
            LogManager.LogProgress();
            
            progresses[index].AddListener(callback);
        }

        public bool IsCompleted => progresses.Count == _count;
    }
}