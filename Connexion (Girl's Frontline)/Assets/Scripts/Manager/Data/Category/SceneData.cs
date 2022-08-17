#region NAMESPACE API

using System;

#endregion

namespace Manager.Data.Category
{
    #region DATA API

    /// <summary>
    /// Data format of scene in <see cref="SceneData"/>
    /// </summary>
    [Serializable]
    public class Scene
    {
        public string name;
    }

    #endregion

    /// <summary>
    /// Data format in <see cref="SceneData"/> Json file
    /// </summary>
    [Serializable]
    public class SceneData
    {
        public Scene[] scenes;
    }
}
