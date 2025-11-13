using GloryDay.Debug.Log;
using UnityEngine;
using Backend.Utility.Management;

namespace Backend.Object.Map
{
    public class BulletReleaser : MonoBehaviour
    {
        #region CONSTANT FIELD API

        private const string BulletTag = "Bullet";

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            LogManager.LogProgress();

            if (other.CompareTag(BulletTag))
            {
                ObjectManager.OnRelease(other.gameObject);
            }
        }
    }
}
