namespace Manager.Log.Console
{
    /// <summary>
    /// Class with label or label-related data in the output log
    /// </summary>
    public static class Label
    {
        // Log Label Text
        public const string ErrorLogLabel = "[ERROR]";
        public const string WarningLogLabel = "[WARNING]";
        public const string SuccessLogLabel = "[SUCCESS]";

        // Log Label Color
        public const string DefaultLogColor = "#C0C0C0";
        public const string ErrorLogColor = "#DC143C";
        public const string WarningLogColor = "#F7E600";
        public const string SuccessLogColor = "#39FF14";
        
        // Log Label Type
        public enum LabelType
        {
            Error = 0, Warning, Success
        }
    }
}
