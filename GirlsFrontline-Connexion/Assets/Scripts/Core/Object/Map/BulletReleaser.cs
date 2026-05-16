using GloryDay.Debug;
using UnityEngine;
using Core.Utility.Management;

namespace Core.Object.Map
{
    public class BulletReleaser : MonoBehaviour
    {
        #region CONSTANT FIELD API

        private const string BulletTag = "Bullet";

        #endregion
        
        private void OnTriggerEnter(Collider other)
        {
            Console.LogProgress();
            
            if (other.CompareTag(BulletTag))
            {
                ObjectPoolManager.Release(other.gameObject);
            }
        }
    }
}
