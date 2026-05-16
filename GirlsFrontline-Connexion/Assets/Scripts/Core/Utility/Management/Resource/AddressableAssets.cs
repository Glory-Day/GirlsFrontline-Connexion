using System.Collections.Generic;
using UnityEngine;

namespace Core.Utility.Management.Resource
{
    public class Audio
    {
        public Dictionary<string, AudioClip> Background { get; } = new Dictionary<string, AudioClip>();

        public Dictionary<string, AudioClip> Effect { get; } = new Dictionary<string, AudioClip>();

        public Dictionary<string, AudioClip> Voice { get; } = new Dictionary<string, AudioClip>();

        public Dictionary<string, AudioClip> UI { get; } = new Dictionary<string, AudioClip>();
    }

    public class Object
    {
        public Dictionary<string, GameObject> Character { get; } = new Dictionary<string, GameObject>();

        public Dictionary<string, GameObject> Item { get; } = new Dictionary<string, GameObject>();

        public Dictionary<string, GameObject> Weapon { get; } = new Dictionary<string, GameObject>();
    }

    public class AddressableAssets
    {
        public Audio Audio { get; } = new Audio();

        public Object Object { get; } = new Object();

        public Dictionary<string, GameObject> UI { get; } = new Dictionary<string, GameObject>();
    }
}
