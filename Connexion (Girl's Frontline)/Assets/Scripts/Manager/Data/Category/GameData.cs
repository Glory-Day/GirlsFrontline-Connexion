#region NAMESPACE API

using System;

#endregion

namespace Manager.Data.Category
{
    #region DATA API

    [Serializable]
    public class Chapter
    {
        public bool isLock;
    }

    #endregion

    [Serializable]
    public class GameData
    {
        public Chapter[] chapters;
    }
}
