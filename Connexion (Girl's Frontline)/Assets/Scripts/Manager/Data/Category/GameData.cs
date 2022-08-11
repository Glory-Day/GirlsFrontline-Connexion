#region NAMESPACE API

using System;

#endregion

namespace Manager.Data.Category
{
    #region CHAPTER DATA API

    /// <summary>
    /// Chapter lock data format in <see cref="GameData"/>
    /// </summary>
    [Serializable]
    public class Chapter
    {
        public bool isLock;
    }

    #endregion

    /// <summary>
    /// <b>Data Format</b> in <b>GameData.json</b>
    /// </summary>
    [Serializable]
    public class GameData
    {
        public Chapter[] chapters;
    }
}
