using System;
using System.Collections;
using GloryDay.Log;
using UnityEngine;
using Utility.Manager;

namespace Object.Character
{
    public class ShieldPoint : MonoBehaviour
    {
        #region COMPONENT FIELD API

        private SpriteRenderer _spriteRenderer01;
        private SpriteRenderer _spriteRenderer02;

        #endregion
        
        private IEnumerator _routine;
        
        private readonly WaitUntil _instruction = new WaitUntil(() => GameManager.IsApplicationPaused == false);
        
        private void OnDisable()
        {
            LogManager.LogProgress();
            
            _spriteRenderer01.color = new Color(1f, 1f, 1f, 0f);
            _spriteRenderer02.color = new Color(1f, 1f, 1f, 0f);

            Value = 0f;
            
            IsEnabled = false;
        }
        
        public void Initialize()
        {
            LogManager.LogProgress();
            
            _spriteRenderer01 = transform.GetChild(0).GetComponent<SpriteRenderer>();
            _spriteRenderer02 = transform.GetChild(1).GetComponent<SpriteRenderer>();
            
            _spriteRenderer01.color = new Color(1f, 1f, 1f, 0f);
            _spriteRenderer02.color = new Color(1f, 1f, 1f, 0f);
        }

        /// <summary>
        /// Calculate the damage point the character's shield received.
        /// </summary>
        /// <param name="point"> The damage point the character's shield received. </param>
        /// <returns> Remaining damage point. </returns>
        public float Subtract(float point)
        {
            if (_routine is null)
            {
                _routine = Blink();
                StartCoroutine(_routine);
            }
            
            Value -= point;
            if (0f < Value)
            {
                return 0f;
            }
            
            // Stop blinking effect.
            StopCoroutine(_routine);

            _routine = FadeOut();
            StartCoroutine(_routine);

            IsEnabled = false;
            
            return -Value;
        }

        public void SetPoint(float point)
        {
            LogManager.LogProgress();
            
            _spriteRenderer01.color = Color.white;
            
            Value = point;
            
            IsEnabled = true;
        }

        private IEnumerator Blink()
        {
            _spriteRenderer01.color = new Color(1f, 1f, 1f, 0f);

            while (true)
            {
                for (var i = 0f; i <= 2f; i += Time.fixedDeltaTime)
                {
                    var alpha = i <= 1f ? i : 1f - (i - 1f);
                    _spriteRenderer02.color = new Color(1f, 1f, 1f, alpha);
            
                    yield return _instruction;
                }
            }
        }

        private IEnumerator FadeOut()
        {
            _spriteRenderer01.color = new Color(1f, 1f, 1f, 0f);
            
            for (var i = 1f; i >= 0f; i -= Time.fixedDeltaTime)
            {
                _spriteRenderer02.color = new Color(1f, 1f, 1f, i);
            
                yield return _instruction;
            }

            _spriteRenderer02.color = new Color(1f, 1f, 1f, 0f);
        }
        
        public float Value { get; private set; }
        
        /// <summary>
        /// True if shield point is enabled, otherwise false.
        /// </summary>
        public bool IsEnabled { get; private set; }
    }
}