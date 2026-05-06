using System;
using System.Collections;
using System.Text;
using GloryDay.Debug;
using UnityEngine;
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/ChapterProgressTimer.cs
using Core.Utility;
using Core.Utility.Manager;

using Console = GloryDay.Debug.Console;

namespace Core.UI
========
using Backend.Utility;
using Backend.Utility.Management;

namespace Backend.Object.UI
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/ChapterProgressTimer.cs
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

        private readonly WaitUntil _instruction = new WaitUntil(() => ApplicationManager.IsPaused == false);

        public void CountDown()
        {
            Console.LogProgress();

            _time = 0f;

            _routine = CountingDown();
            StartCoroutine(_routine);
        }

        public void Stop()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/ChapterProgressTimer.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/ChapterProgressTimer.cs
            StopCoroutine(_routine);
            _routine = null;
        }

        private IEnumerator CountingDown()
        {
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

                _time += Time.deltaTime;

                yield return _instruction;
            }
        }

        public string Text { get; private set; }

        public ValueChangedCallback<string> OnProgressTimeTextChanged;
    }
}
