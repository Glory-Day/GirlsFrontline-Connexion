using UnityEngine.Networking;

namespace GloryDay.Editor.Coroutine
{
    public struct UnityWebRequestRoutineState : IRoutineState
    {
        public UnityWebRequest Request;

        public bool IsDone(float deltaTime)
        {
            return Request.isDone;
        }
    }
}