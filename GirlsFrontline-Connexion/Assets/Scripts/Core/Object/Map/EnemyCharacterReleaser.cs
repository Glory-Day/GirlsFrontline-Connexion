using GloryDay.Debug;
using Core.Object.Character.Enemy;
using UnityEngine;
using Core.Utility.Management;

namespace Core.Object.Map
{
    public class EnemyCharacterReleaser : MonoBehaviour
    {
        #region CONSTANT FIELD API

        private const string EnemyCharacterTag = "Enemy";

        #endregion

        private CharacterSpawner _spawner;

        private void Awake()
        {
            Console.LogProgress();
            
            _spawner = GetComponentInParent<CharacterSpawner>();
        }
        
        private void OnCollisionEnter(Collision other)
        {
            Console.LogProgress();

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
