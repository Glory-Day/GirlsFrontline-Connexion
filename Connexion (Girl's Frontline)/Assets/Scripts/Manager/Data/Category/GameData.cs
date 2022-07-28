#region NAMESPACE API

using System;

#endregion

namespace Manager.Data.Category
{
    #region CHAPTER DATA API

    /// <summary>
    /// Chapter data in <b>GameData.json</b>
    /// </summary>
    [Serializable]
    public class Chapter
    {
        public bool isLock;
    }

    #endregion

    /// <summary>
    /// Game data in <b>GameData.json</b>
    /// </summary>
    [Serializable]
    public class GameData
    {
        public Chapter[] chapters;
    }
}
