#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using GloryDay.Debug.Log;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace GloryDay.Editor.Coroutine
{
	public class UnityEditorCoroutine
	{
		private static UnityEditorCoroutine _instance;

		private readonly Dictionary<string, List<Routine>> _routines =
			new Dictionary<string, List<Routine>>();
		private readonly Dictionary<string, Dictionary<string, Routine>> _coroutines =
			new Dictionary<string, Dictionary<string, Routine>>();
		
		private readonly List<List<Routine>> _caches = new List<List<Routine>>();

		private DateTime _timer;

		private UnityEditorCoroutine()
		{
			_timer = DateTime.Now;
			EditorApplication.update += Update;
		}

		/// <summary>Starts a coroutine.</summary>
		/// <param name="iteration">The coroutine to start.</param>
		/// <param name="reference">Reference to the instance of the class containing the method.</param>
		public static Routine StartCoroutine(IEnumerator iteration, object reference)
		{
			CreateInstance();
			return _instance.Add(iteration, reference);
		}

		/// <summary>Starts a coroutine.</summary>
		/// <param name="methodName">The name of the coroutine method to start.</param>
		/// <param name="reference">Reference to the instance of the class containing the method.</param>
		public static Routine StartCoroutine(string methodName, object reference)
		{
			return StartCoroutine(methodName, null, reference);
		}

		/// <summary>Starts a coroutine.</summary>
		/// <param name="methodName">The name of the coroutine method to start.</param>
		/// <param name="value">The parameter to pass to the coroutine.</param>
		/// <param name="reference">Reference to the instance of the class containing the method.</param>
		public static Routine StartCoroutine(string methodName, object value, object reference)
		{
			var methodInfo = reference.GetType().GetMethod(
				methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
			if (methodInfo == null)
			{
				LogManager.LogError($"Coroutine {methodName} couldn't be started, the method doesn't exist.");
			}

			var returnValue = methodInfo?.Invoke(reference, value == null ? null : new [] { value });
			if (returnValue is IEnumerator enumerator)
			{
				CreateInstance();
				
				return _instance.Add(enumerator, reference);
			}
			
			LogManager.LogError($"Coroutine {methodName} couldn't be started, the method doesn't return an IEnumerator.");

			return null;
		}

		/// <summary>Stops all coroutines being the routine running on the passed instance.</summary>
		/// <param name="iteration"> The coroutine to stop.</param>
		/// <param name="reference">Reference to the instance of the class containing the method.</param>
		public static void StopCoroutine(IEnumerator iteration, object reference)
		{
			CreateInstance();
			
			_instance.Remove(iteration, reference);
		}

		/// <summary>
		/// Stops all coroutines named methodName running on the passed instance.</summary>
		/// <param name="methodName"> The name of the coroutine method to stop.</param>
		/// <param name="reference">Reference to the instance of the class containing the method.</param>
		public static void StopCoroutine(string methodName, object reference)
		{
			CreateInstance();
			
			_instance.Remove(methodName, reference);
		}

		/// <summary>
		/// Stops all coroutines running on the passed instance.</summary>
		/// <param name="reference">Reference to the instance of the class containing the method.</param>
		public static void StopAllCoroutines(object reference)
		{
			CreateInstance();
			
			_instance.Clear(reference);
		}

		private static void CreateInstance()
		{
			if (_instance != null)
			{
				return;
			}
			
			_instance = new UnityEditorCoroutine();
		}

		private void Remove(IEnumerator iteration, object reference)
		{
			Remove(CreateRoutine(iteration, reference));
		}

		private void Remove(string methodName, object reference)
		{
			Remove(CreateRoutineFromMethodName(methodName, reference));
		}

		private void Remove(Routine routine)
		{
			if (!_routines.ContainsKey(routine.HashCode))
			{
				return;
			}
			
			_coroutines[routine.HashCode].Remove(routine.HashCode);
			_routines.Remove(routine.HashCode);
		}

		private void Clear(object reference)
		{
			var coroutineInfo = CreateRoutine(null, reference);
			if (!_coroutines.ContainsKey(coroutineInfo.HashCode))
			{
				return;
			}
			
			foreach (var routine in _coroutines[coroutineInfo.HashCode].Values)
			{
				_routines.Remove(routine.HashCode);
			}
			
			_coroutines.Remove(coroutineInfo.HashCode);
		}

		private Routine Add(IEnumerator iteration, object reference)
		{
			Routine routine = null;
			
			try
			{
				if (iteration == null)
				{
					throw new Exception("Routine is null reference.");
				}
			
				routine = CreateRoutine(iteration, reference);
				Add(routine);
			}
			catch (Exception exception)
			{
				LogManager.LogError(exception.Message);
			}
			
			return routine;
		}

		private void Add(Routine routine)
		{
			if (_routines.ContainsKey(routine.HashCode) == false)
			{
				_routines.Add(routine.HashCode, new List<Routine>());
			}
			_routines[routine.HashCode].Add(routine);

			if (_coroutines.ContainsKey(routine.HashCode) == false)
			{
				_coroutines.Add(routine.HashCode, new Dictionary<string, Routine>());
			}

			// If the method from the same owner has been stored before, it doesn't have to be stored anymore,
			// One reference is enough in order for "StopAllCoroutines" to work
			if (_coroutines[routine.HashCode].ContainsKey(routine.HashCode) == false)
			{
				_coroutines[routine.HashCode].Add(routine.HashCode, routine);
			}

			MoveNext(routine);
		}

		private static Routine CreateRoutine(IEnumerator iteration, object reference)
		{
			return new Routine(iteration, reference.GetHashCode(), reference.GetType().ToString());
		}

		private static Routine CreateRoutineFromMethodName(string methodName, object reference)
		{
			return new Routine(methodName, reference.GetHashCode(), reference.GetType().ToString());
		}

		private void Update()
		{
			var deltaTime = (float)(DateTime.Now.Subtract(_timer).TotalMilliseconds / 1000.0f);

			_timer = DateTime.Now;
			if (_routines.Count == 0)
			{
				return;
			}

			_caches.Clear();
			foreach (var item in _routines.Values)
			{
				_caches.Add(item);
			}

			for (var i = _caches.Count - 1; i >= 0; i--)
			{
				var routines = _caches[i];
				for (var j = routines.Count - 1; j >= 0; j--)
				{
					var routine = routines[j];
					if (routine.State.IsDone(deltaTime) == false)
					{
						continue;
					}

					if (MoveNext(routine) == false)
					{
						routines.RemoveAt(j);
						routine.State = null;
						routine.IsDone = true;
					}

					if (routines.Count == 0)
					{
						_routines.Remove(routine.HashCode);
					}
				}
			}
		}

		private static bool MoveNext(Routine routine)
		{
			return routine.Iteration.MoveNext() && Process(routine);
		}

		// returns false if no next, returns true if OK
		private static bool Process(Routine routine)
		{
			var current = routine.Iteration.Current;
			switch (current)
			{
				case null:
					return false;
				case WaitForSeconds _:
				{
					var seconds = float.Parse(GetInstanceField(typeof(WaitForSeconds), current, "m_Seconds").ToString());
					routine.State = new WaitForSecondsRoutineState { Seconds = seconds };
					break;
				}
				case UnityWebRequest request:
					routine.State = new UnityWebRequestRoutineState { Request = request };
					break;
				case WaitForFixedUpdate _:
					routine.State = new RoutineState();
					break;
				case AsyncOperation operation:
					routine.State = new AsyncRoutineState { AsyncOperation = operation };
					break;
				case Routine nestedRoutine:
					routine.State = new NestedRoutineState { NestedRoutine = nestedRoutine};
					break;
				default:
					UnityEngine.Debug.LogException(
						new Exception("<" + routine.MethodName + "> yielded an unknown or unsupported type! (" + current.GetType() + ")"),
						null);
					routine.State = new RoutineState();
					break;
			}
			
			return true;
		}

		private static object GetInstanceField(IReflect type, object instance, string fieldName)
		{
			const BindingFlags bindingAttr =
				BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
			var fieldInfo = type.GetField(fieldName, bindingAttr);
			
			return fieldInfo.GetValue(instance);
		}
	}
}

#endif