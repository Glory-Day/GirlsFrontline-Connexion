#region NAMESPACE API

using UnityEngine;

#endregion

namespace View
{
    public class SubjectArrayAttribute : PropertyAttribute
    {
        public SubjectArrayAttribute(string subject)
        {
            Subject = subject;
            Start = 0;
        }
        
        public SubjectArrayAttribute(string subject, int start)
        {
            Subject = subject;
            Start = start;
        }
        
        public string Subject { get; }
        
        public int Start { get; }
    }
}
