namespace Manager.Log
{
    /// <summary>
    /// Label or label-related data in the output log
    /// </summary>
    public static class Label
    {
        // Log label text for unity editor
        public const string DefaultLogLabel                    = "[DEFAULT]";
        public const string EventLogLabel                      = "[EVENT]";
        public const string ErrorLogLabel                      = "[ERROR]";
        public const string AdministratorInUnityEditorLogLabel = "[PERMISSON][ADMINISTRATOR]";
        public const string SuccessLogLabel                    = "[SUCCESS]";

        // Log label text for development build
        public const string AdministratorInDevelopmentBuildLogLabel = "PERMISSION|ADMINISTRATOR";

        // Log label color
        public const string DefaultLogColor       = "#C0C0C0";
        public const string EventLogColor         = "#F8F8FF";
        public const string ErrorLogColor         = "#DC143C";
        public const string AdministratorLogColor = "#F7E600";
        public const string SuccessLogColor       = "#39FF14";

        // Log label type
        public enum LabelType
        {
            Event = 0,
            Error,
            Administrator,
            Success
        }
    }
}
