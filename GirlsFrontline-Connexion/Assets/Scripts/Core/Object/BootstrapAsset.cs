using System.Collections;
using UnityEngine;

namespace Core.Object
{
    public abstract class BootstrapAsset : ScriptableObject, IBootable
    {
        public IEnumerator Booting()
        {
            IsBooting = true;

            yield return Booting_Internal();

            IsBooting = false;
        }

        protected abstract IEnumerator Booting_Internal();

        public bool IsBooting { get; private set; }
    }
}
