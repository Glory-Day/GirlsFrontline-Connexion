namespace Manager.Log
{
    public static class Label
    {
        // Log label text
        public const string DefaultLogLabel                         = "DEFAULT";
        public const string EventLogLabel                           = "EVENT";
        public const string ErrorLogLabel                           = "ERROR";
        public const string AdministratorInUnityEditorLogLabel      = "PERMISSON][ADMINISTRATOR";
        public const string AdministratorInDevelopmentBuildLogLabel = "PERMISSION|ADMINISTRATOR";
        public const string SuccessLogLabel                         = "SUCCESS";

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
            Success
        }
    }
}
