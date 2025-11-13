using UnityEngine;

namespace GloryDay.Editor.Coroutine
{
    public struct AsyncRoutineState : IRoutineState
    {
        public AsyncOperation AsyncOperation;

        public bool IsDone(float deltaTime)
        {
            return AsyncOperation.isDone;
        }
    }
}