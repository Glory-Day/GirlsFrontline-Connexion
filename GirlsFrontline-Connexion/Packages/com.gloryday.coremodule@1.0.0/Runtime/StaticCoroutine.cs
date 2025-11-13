using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GloryDay
{
    public class StaticCoroutine : SingletonGameObject<StaticCoroutine>
    {
#if UNITY_EDITOR
        
        [Serializable]
        private class CoroutineRecord
        {
            public string message;
        }
        
        [SerializeField]
        private List<CoroutineRecord> records = new List<CoroutineRecord>();
        
#endif
        
        public static Coroutine Start(IEnumerator routine)
        {
            return Instance.StartProcessing(routine);
        }

        public static void Stop(IEnumerator routine)
        {
            Instance.StopProcessing(routine);
        }

        public static void Stop()
        {
            Instance.StopAllProcessing();
        }

        private Coroutine StartProcessing(IEnumerator routine)
        {
#if UNITY_EDITOR
            
            return base.StartCoroutine(Trace(routine));
            
#else
            
            return base.StartCoroutine(routine);

#endif
        }

        private void StopProcessing(IEnumerator routine)
        {
            base.StopCoroutine(routine);
        }

        private void StopAllProcessing()
        {
            base.StopAllCoroutines();
        }

#if UNITY_EDITOR
        
        private IEnumerator Trace(IEnumerator routine)
        {
            CoroutineRecord record = null;
            
            var trace = new System.Diagnostics.StackTrace(true);
            var frame = trace.GetFrame(6);
            if (frame is null == false)
            {
                var filePath = frame.GetFileName()?.Split('\\');
                var fileName = filePath?[filePath.Length - 1];
                var methodName = frame.GetMethod().ToString();

                record = new CoroutineRecord
                         {
                             message = $"[{DateTime.Now:hh:mm:ss}] {fileName}:{methodName}"
                         };
                
                records.Add(record);
            }

            yield return routine;
            

            if (record is null == false)
            {
                records.Remove(record);
            }
        }
        
#endif
    }
}