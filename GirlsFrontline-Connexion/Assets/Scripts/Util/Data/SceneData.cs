using System;

namespace Util.Data
{
    #region DATA CLASS API

    [Serializable]
    public class Scene
    {
        public string name;

        #region PROPERTIES API

        public string Name => name;

        #endregion
    }

    #endregion

    [Serializable]
    public class SceneData
    {
        public Scene[] scenes;

        #region PROPERTIES API

        public Scene[] Scenes => scenes;

        #endregion
    }
}
