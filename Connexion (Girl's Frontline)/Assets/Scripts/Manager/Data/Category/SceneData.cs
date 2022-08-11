#region NAMESPACE API

using System;

#endregion

namespace Manager.Data.Category
{
    #region SCENE DATA API

    /// <summary>
    /// Scene data format in <see cref="SceneData"/>
    /// </summary>
    [Serializable]
    public class Scene
    {
        public string name;
    }

    #endregion

    /// <summary>
    /// <b>Data Format</b> in <b>SceneData.json</b>
    /// </summary>
    [Serializable]
    public class SceneData
    {
        public Scene[] scenes;
    }
}
