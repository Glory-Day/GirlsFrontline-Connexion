using GloryDay.Debug.Log;
using Backend.Object.Character.Enemy;
using UnityEngine;
using Backend.Utility.Management;

namespace Backend.Object.Map
{
    public class EnemyCharacterReleaser : MonoBehaviour
    {
        #region CONSTANT FIELD API

        private const string EnemyCharacterTag = "Enemy";

        #endregion

        private CharacterSpawner _spawner;

        private void Awake()
        {
            LogManager.LogProgress();

            _spawner = GetComponentInParent<CharacterSpawner>();
        }

        private void OnCollisionEnter(Collision other)
        {
            LogManager.LogProgress();

            var instance = other.gameObject;
            if (instance.TryGetComponent<PathfinderCharacter>(out var character))
            {
                ObjectManager.OnRelease(instance);

                return;
            }

            if (other.collider.CompareTag(EnemyCharacterTag) == false)
            {
                return;
            }

            _spawner.RespawnEnemyCharacter(instance);
        }
    }
}
