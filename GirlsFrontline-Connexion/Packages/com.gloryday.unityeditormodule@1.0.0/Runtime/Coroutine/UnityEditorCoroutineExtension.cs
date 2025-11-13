#if UNITY_EDITOR

using System.Collections;
using UnityEditor;

namespace GloryDay.Editor.Coroutine
{
    public static class UnityEditorCoroutineExtensions
    {
        public static Routine StartCoroutine(this EditorWindow reference, IEnumerator coroutine)
        {
            return UnityEditorCoroutine.StartCoroutine(coroutine, reference);
        }

        public static Routine StartCoroutine(this EditorWindow reference, string methodName)
        {
            return UnityEditorCoroutine.StartCoroutine(methodName, reference);
        }

        public static Routine StartCoroutine(this EditorWindow reference, string methodName, object value)
        {
            return UnityEditorCoroutine.StartCoroutine(methodName, value, reference);
        }

        public static void StopCoroutine(this EditorWindow reference, IEnumerator coroutine)
        {
            UnityEditorCoroutine.StopCoroutine(coroutine, reference);
        }

        public static void StopCoroutine(this EditorWindow reference, string methodName)
        {
            UnityEditorCoroutine.StopCoroutine(methodName, reference);
        }

        public static void StopAllCoroutines(this EditorWindow reference)
        {
            UnityEditorCoroutine.StopAllCoroutines(reference);
        }
    }
}

#endif