#if UNITY_EDITOR

namespace GloryDay.Addressables
{
    [System.Serializable]
    public class UserData
    {
        public string Path { get; set; } = string.Empty;

        public string Namespace { get; set; } = string.Empty;

        public string ClassName { get; set; } = string.Empty;
    }
}

#endif
