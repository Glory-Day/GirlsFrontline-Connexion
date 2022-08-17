#region NAMESPACE API

using System;

#endregion

namespace Manager.Data.Category
{
    #region DATA API

    /// <summary>
    /// Data format of chapter lock in <see cref="GameData"/>
    /// </summary>
    [Serializable]
    public class Chapter
    {
        public bool isLock;
    }

    #endregion

    /// <summary>
    /// Data format in <see cref="GameData"/> Json file
    /// </summary>
    [Serializable]
    public class GameData
    {
        public Chapter[] chapters;
    }
}
