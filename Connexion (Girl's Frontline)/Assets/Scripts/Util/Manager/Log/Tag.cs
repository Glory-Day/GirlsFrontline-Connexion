namespace Util.Manager.Log
{
    public static class Tag
    {
        #region CONSTANT FIELD API

        public const string Called  = "CALLED";
        public const string Event   = "EVENT";
        public const string Error   = "ERROR";
        public const string Success = "SUCCESS";
        
        public struct Administrator
        {
            public const string UnityEditor      = "PERMISSON][ADMINISTRATOR";
            public const string DevelopmentBuild = "PERMISSION|ADMINISTRATOR";
        }

        #endregion
    }
}
