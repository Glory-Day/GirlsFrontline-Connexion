namespace GloryDay.Editor.Coroutine
{
    public struct NestedRoutineState : IRoutineState
    {
        public Routine NestedRoutine;

        public bool IsDone(float deltaTime)
        {
            return NestedRoutine.IsDone;
        }
    }
}