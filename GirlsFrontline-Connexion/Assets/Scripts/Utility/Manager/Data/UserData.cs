using System;
using System.Collections.Generic;

namespace Utility.Manager.Data
{
    [Serializable]
    public class Chapter
    {
        public bool IsLocked { get; set; }
        public int Score { get; set; }
    }

    [Serializable]
    public class Default
    {
        public List<bool> IsDisplayAllowed { get; set; }
    }
    
    [Serializable]
    public class Sound
    {
        public float Volume { get; set; }

        public bool IsMute { get; set; }
    }
    
    [Serializable]
    public class UserData
    {
        public List<Chapter> Chapter { get; set; }

        public Default Default { get; set; }

        public List<Sound> Sound { get; set; }
    }
}
