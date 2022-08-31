#region NAMESPACE API

using System;

#endregion

namespace Manager.Data.Category
{
    #region DATA API

    [Serializable]
    public class Scene
    {
        public string name;
    }

    #endregion

    [Serializable]
    public class SceneData
    {
        public Scene[] scenes;
    }
}
