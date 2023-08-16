using System.Collections.Generic;
using UnityEngine;

namespace Util.Manager.Asset
{
    public class TextAsset
    {
        public TextAsset()
        {
            Data = new Dictionary<string, UnityEngine.TextAsset>();
        }

        public Dictionary<string, UnityEngine.TextAsset> Data { get; set; }
    }
}
