﻿#region NAMESPACE API

using System;

#endregion

namespace Manager.Data.Category
{
    #region DATA CLASS API

    [Serializable]
    public class Chapter
    {
        public bool isBlock;
    }

    #endregion

    [Serializable]
    public class GameData
    {
        public Chapter[] chapters;
    }
}
