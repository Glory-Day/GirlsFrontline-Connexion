using GloryDay.Log;
using Object.Character.Enemy;
using UnityEngine;
using Utility.Manager;

namespace Object.Map
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