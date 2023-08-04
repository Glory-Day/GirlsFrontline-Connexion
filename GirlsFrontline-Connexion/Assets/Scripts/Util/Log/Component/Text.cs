#if UNITY_EDITOR

namespace Util.Log.Component
{
    public static class Text
    {
        public struct Bracket
        {
            public const string Left  = "[";
            public const string Right = "]";
        }
        
        public struct Header
        {
            public const string Class   = "Class: ";
            public const string Method  = "Method: ";
            public const string Message = "Message: ";
        }

        public const string Parentheses = "()";
        public const string NextLine    = "\n";
    }
}

#elif DEVELOPMENT_BUILD

namespace Util.Log.Component
{
    public static class Text
    {
        public const string Parentheses = "()";
        public const string Separator = "|";
    }
}

#endif