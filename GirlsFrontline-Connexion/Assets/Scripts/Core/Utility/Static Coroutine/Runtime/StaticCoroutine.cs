using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using UnityEngine;
using GloryDay.Utility;

namespace GloryDay.Services
{
    public class StaticCoroutine : SingletonGameObject<StaticCoroutine>
    {
#if UNITY_EDITOR

        [Serializable]
        private class Log
        {
            public string time;
            public string message;
        }

        [SerializeField]
        private List<Log> logs = new List<Log>();

        private void OnDisable()
        {
            logs.Clear();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            logs.Clear();
        }

#endif

        private Coroutine Start_Internal(IEnumerator routine)
        {
#if UNITY_EDITOR

            return StartCoroutine(Debug(routine));

#else

            return StartCoroutine(routine);

#endif
        }

#if UNITY_EDITOR

        private IEnumerator Debug(IEnumerator routine)
        {
            Log log = null;

            log = Trace();
            if (log != null)
            {
                logs.Add(log);
            }

            try
            {
                if (routine != null)
                {
                    yield return routine;
                }
                else
                {
                    yield break;
                }
            }
            finally
            {
                if (log != null)
                {
                    logs.Remove(log);
                }
            }
        }

        private Log Trace()
        {
            var trace = new StackTrace(true);
            var frames = trace.GetFrames();
            if (frames == null)
            {
                return null;
            }

            StackFrame caller = null;

            var length = frames.Length;
            for (var i = 0; i < length; i++)
            {
                var type = frames[i].GetMethod()?.DeclaringType;
                if (type == null || type == typeof(StaticCoroutine))
                {
                    continue;
                }

                caller = frames[i];

                break;
            }

            if (caller == null)
            {
                return null;
            }

            var filePath = caller.GetFileName();
            var fileName = string.IsNullOrEmpty(filePath) ? "Unknown" : Path.GetFileName(filePath);

            MethodBase method = caller.GetMethod();
            var methodName = method != null ? $"{method.DeclaringType?.Name}.{method.Name}" : "Unknown Method";

            return new Log { time = $"{DateTime.Now:HH:mm:ss}", message = $"{fileName}:{methodName}" };
        }

#endif

        #region STATIC METHOD API

        public static Coroutine Start(IEnumerator routine)
        {
            return Instance.Start_Internal(routine);
        }

        public static void Stop(IEnumerator routine)
        {
            Instance.StopCoroutine(routine);
        }

        public static void Stop()
        {
            Instance.StopAllCoroutines();
        }

        #endregion
    }
}
