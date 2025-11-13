using System.Collections;

namespace GloryDay.Editor.Coroutine
{
    public class Routine
    {
        public IRoutineState State = new RoutineState();

        private readonly int    _hashCode;
        private readonly string _typeName;

        public Routine(IEnumerator iteration, int hashCode, string typeName)
        {
            _hashCode = hashCode;
            _typeName = typeName;

            Iteration = iteration;
            if (iteration == null)
            {
                return;
            }
            
            var split = iteration.ToString().Split('<', '>');
            if (split.Length == 3)
            {
                MethodName = split[1];
            }
        }

        public Routine(string methodName, int hashCodeNumber, string typeName)
        {
            _hashCode = hashCodeNumber;
            _typeName = typeName;
            
            MethodName = methodName;
        }
        
        public IEnumerator Iteration { get; }

        public string HashCode => $"{_hashCode}_{_typeName}_{MethodName}";

        public string MethodName { get; }

        public bool IsDone { get; set; }
    }
}