using System.Collections.Generic;
using UnityEngine;

namespace Utility.Manager.Resource
{
    public class GameObjectResource
    {
        public Dictionary<string, GameObject> UI { get; } = new Dictionary<string, GameObject>();
    }
}
