using System;
using System.Collections;
using System.Text;
using GloryDay.Log;
using UnityEngine;
using Utility;
using Utility.Manager;

namespace UI
{
    public class ChapterProgressTimer : MonoBehaviour
    {
        #region CONSTANT FIELD API

        private const string TextFormat = "D2";

        private const string Separator = ":";
        
        #endregion
        
        private IEnumerator _routine;
        
        private readonly StringBuilder _builder = new StringBuilder();
        private float _time;

        private readonly WaitUntil _instruction = new WaitUntil(() => GameManager.IsApplicationPaused == false);
        
        public void CountDown()
        {
            LogManager.LogProgress();

            _time = 0f;
            
            _routine = CountingDown();
            StartCoroutine(_routine);
        }

        public void Stop()
        {
            LogManager.LogProgress();
            
            StopCoroutine(_routine);
            _routine = null;
        }

        private IEnumerator CountingDown()
        {
            var deltaTime = Time.deltaTime;
            while (true)
            {
                var time = TimeSpan.FromSeconds(_time);
                var hour = time.Hours.ToString(TextFormat);
                var minute = time.Minutes.ToString(TextFormat);
                var second = time.Seconds.ToString(TextFormat);

                _builder.Append(hour);
                _builder.Append(Separator);
                _builder.Append(minute);
                _builder.Append(Separator);
                _builder.Append(second);

                Text = _builder.ToString();
                _builder.Clear();
                
                OnProgressTimeTextChanged.Invoke(Text);

                _time += deltaTime;

                yield return _instruction;
            }
        }
        
        public string Text { get; private set; }
        
        public ValueChangedCallback<string> OnProgressTimeTextChanged;
    }
}