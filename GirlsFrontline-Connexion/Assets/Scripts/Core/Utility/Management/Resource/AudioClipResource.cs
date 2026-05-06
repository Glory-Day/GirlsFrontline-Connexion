using System.Collections.Generic;
using UnityEngine;

<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/Resource/AudioClipResource.cs
namespace Core.Utility.Manager.Resource
========
namespace Backend.Utility.Management.Resource
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/Resource/AudioClipResource.cs
{
    public class AudioClipResource
    {
        public Dictionary<string, AudioClip> Background { get; } = new Dictionary<string, AudioClip>();

        public Dictionary<string, AudioClip> Effect { get; } = new Dictionary<string, AudioClip>();

        public Dictionary<string, AudioClip> Voice { get; } = new Dictionary<string, AudioClip>();
    }
}
