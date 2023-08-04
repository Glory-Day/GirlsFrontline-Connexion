#if UNITY_EDITOR

namespace Util.Log.Component
{
    public static class Tag
    {
        #region CONSTANT FIELD API

        public struct Color
        {
            public struct Opener
            {
                public const string Default       = "<color=#F8F8FF>";
                public const string Error         = "<color=#DC143C>";
                public const string Administrator = "<color=#F7E600>";
                public const string Success       = "<color=#39FF14>";
            }

            public const string Closer = "</color>";
        }
        
        public struct Bold
        {
            public const string Opener = "<b>";
            public const string Closer = "</b>";
        }

        #endregion
    }
}

#elif DEVELOPMENT_BUILD

namespace Util.Log.Component
{
    public static class Tag
    {
        #region CONSTANT FIELD API
        
        public struct Bold
        {
            public const string Opener = "<b>";
            public const string Closer = "</b>";
        }

        public struct Italic
        {
            public const string Opener = "<i>";
            public const string Closer = "</i>";
        }

        #endregion
    }
}

#endif