#region NAMESPACE API

using System;

#endregion

namespace Manager.Data.Category
{
    #region SCENE DATA API

    /// <summary>
    /// Scene data in <b>SceneData.json</b>
    /// </summary>
    [Serializable]
    public class Scene
    {
        public string name;
    }

    #endregion

    /// <summary>
    /// Scene data in <b>SceneData.json</b>
    /// </summary>
    [Serializable]
    public class SceneData
    {
        public Scene[] scenes;
    }
}
