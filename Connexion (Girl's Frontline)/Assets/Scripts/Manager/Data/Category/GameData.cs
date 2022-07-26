#region NAMESPACE API

using System;

#endregion

namespace Manager.Data.Category
{
    /// <summary>
    /// Game data in <b>GameData.json</b>
    /// </summary>
    [Serializable]
    public class GameData
    {
        public bool[] isChapterLock;
    }
}
