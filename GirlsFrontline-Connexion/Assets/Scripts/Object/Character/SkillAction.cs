using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Object.Character
{
    public class SkillAction : MonoBehaviour
    {
        #region SERIALIZABLE CLASS & STRUCT API

        [Serializable]
        public class Timer
        {
            public float coolDown;
            public float duration;
            
            private WaitForFixedUpdate _delay = new WaitForFixedUpdate();
            
            public IEnumerator CoolingTime()
            {
                IsCoolingTime = true;
                
                OnCoolingTimeStarted?.Invoke();
                
                var deltaTime = Time.deltaTime;
                CoolingDownTime = coolDown;
                while (0 <= CoolingDownTime)
                {
                    CoolingDownTime -= deltaTime;
                    CoolingDownTimeChanged.Invoke(CoolingDownTime);
                    
                    var percentage = 1f - CoolingDownTime / coolDown;
                    ProgressChanged.Invoke(percentage);
                    
                    yield return _delay;
                }
                
                CoolingDownTime = 0;
                
                OnCoolingTimeCompleted?.Invoke();
                
                IsCoolingTime = false;
            }

            public IEnumerator CountingDown()
            {
                IsCountingDown = true;
                
                OnCountingDownStarted?.Invoke();
                
                var deltaTime = Time.deltaTime;
                CountingDownTime = 0f;
                while (CountingDownTime <= duration)
                {
                    CountingDownTime += deltaTime;
                    
                    var percentage = 1f - CountingDownTime / duration;
                    ProgressChanged.Invoke(percentage);
                    
                    yield return _delay;
                }
                
                CountingDownTime = duration;
                IsCountingDown = false;
                
                OnCountingDownCompleted?.Invoke();
            }

            public Action OnCoolingTimeStarted;
            public Action OnCoolingTimeCompleted;
            
            public Action OnCountingDownStarted;
            public Action OnCountingDownCompleted;
            
            public ValueChangedCallback<float> CoolingDownTimeChanged;
            public ValueChangedCallback<float> ProgressChanged;
            
            public float CoolDown => coolDown;
            
            public float Duration => duration;
            
            public float CoolingDownTime { get; private set; }
            
            public float CountingDownTime { get; private set; }
            
            public bool IsCoolingTime { get; private set; }
            
            public bool IsCountingDown { get; private set; }
        }

        #endregion
        
        #region SERIALIZABLE FIELD API

        [SerializeField] private List<Timer> timers = new List<Timer>();

        #endregion

        /// <summary>
        /// Run the timer corresponding to the index.
        /// </summary>
        /// <param name="index"> The index number in the timers </param>
        public void Run(int index)
        {
            StartCoroutine(Running(index));
        }
        
        private IEnumerator Running(int index)
        {
            yield return StartCoroutine(Timers[index].CountingDown());
            yield return StartCoroutine(Timers[index].CoolingTime());
        }
        
        public List<Timer> Timers => timers;
    }
}