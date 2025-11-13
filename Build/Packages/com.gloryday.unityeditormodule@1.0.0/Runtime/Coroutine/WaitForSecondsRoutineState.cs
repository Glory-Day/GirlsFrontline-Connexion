namespace GloryDay.Editor.Coroutine
{
    public struct WaitForSecondsRoutineState : IRoutineState
    {
        public float Seconds;

        public bool IsDone(float deltaTime)
        {
            Seconds -= deltaTime;
            
            return Seconds < 0;
        }
    }
}