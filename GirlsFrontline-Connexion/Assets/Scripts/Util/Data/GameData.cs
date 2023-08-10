using System;

namespace Util.Data
{
    #region DATA CLASS API

    [Serializable]
    public class Chapter
    {
        public bool isBlock;

        #region PROPERTIES API

        public bool IsBlock => isBlock;

        #endregion
    }

    #endregion

    [Serializable]
    public class GameData
    {
        public Chapter[] chapters;

        #region PROPERTIES API

        public Chapter[] Chapters => chapters;

        #endregion
    }
}
