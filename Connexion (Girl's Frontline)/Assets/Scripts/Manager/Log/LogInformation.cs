namespace Manager.Log
{
    public static class Tag
    {
        public const string Default = "DEFAULT";
        public const string Event   = "EVENT";
        public const string Error   = "ERROR";
        public const string Success = "SUCCESS";
            
        public struct Administrator
        {
            public const string UnityEditor      = "PERMISSON][ADMINISTRATOR";
            public const string DevelopmentBuild = "PERMISSION|ADMINISTRATOR";
        }
    }

    public static class Color
    {
        public const string Default       = "#C0C0C0";
        public const string Event         = "#F8F8FF";
        public const string Error         = "#DC143C";
        public const string Administrator = "#F7E600";
        public const string Success       = "#39FF14";
    }

    public static class LogLabel
    {
        public enum Label
        {
            Event,
            Error,
            Success
        }
    }
}
