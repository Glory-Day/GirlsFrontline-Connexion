using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GloryDay.Log;
using Object.Character;
using UI;
using UnityEngine;
using Utility.Data;
using Utility.Manager;

namespace Object.Map
{
    public class CharacterSpawner : MonoBehaviour
    {
        private readonly Dictionary<int, EnemyCharacter> _records = new Dictionary<int, EnemyCharacter>();
        private readonly Queue<SpawnData> _queue = new Queue<SpawnData>();
        private Comparison<IHorizontalComparable> _comparison;
        
        private PlaneMeshVertexExtractor _extractor;
        
        private MainInterfaceScreen _screen;
        private FailedResultScreen _failedResultScreen;
        
        private readonly WaitForSeconds _delay = new WaitForSeconds(10f);
        private readonly WaitUntil _instruction = new WaitUntil(() => GameManager.IsApplicationPaused == false);
        
        private void Awake()
        {
            LogManager.LogProgress();
            
            // Initialize the plane mesh vertex extractor to get coordinates for spawning character.
            var child = transform.GetChild(5);
            _extractor = child.GetComponent<PlaneMeshVertexExtractor>();
            
            _comparison = CompareEnemyCharacterPosition;

            _screen = FindObjectOfType<MainInterfaceScreen>();
            _failedResultScreen = FindObjectOfType<FailedResultScreen>();
            
            PlayerCharacterLifeCount = 1;
        }

        public void CreateCharacters(ChapterData data)
        {
            LogManager.LogProgress();
            
            // Create player character.
            var original = ResourceManager.GameObjectResource.PlayerCharacter;
            ObjectManager.OnCreate(original, transform, 1);

            // Set the number of enemy characters of each type.
            var count = 0;
            var caches = new Dictionary<string, int>();
            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < data.StageData[i].WaveData.Count; j++)
                {
                    for (var k = 0; k < data.StageData[i].WaveData[j].SpawnData.Count; k++)
                    {
                        var key = data.StageData[i].WaveData[j].SpawnData[k].CharacterName;
                        if (caches.ContainsKey(key))
                        {
                            caches[key]++;
                        }
                        else
                        {
                            caches.Add(key, 1);
                        }

                        count++;
                    }
                }
            }
            
            // Create all the enemy characters needed for the chapter.
            foreach (var cache in caches)
            {
                var key = cache.Key;
                original = ResourceManager.GameObjectResource.EnemyCharacter[key];
                ObjectManager.OnCreate(original, transform, cache.Value);
            }

            // Create all items from the enemy character.
            for (var i = 0; i < 4; i++)
            {
                original = ResourceManager.GameObjectResource.Item[i];
                ObjectManager.OnCreate(original, transform, count);
            }
        }
        
        public void SpawnPlayerCharacter()
        {
            LogManager.LogProgress();

            IsPlayerCharacterSpawning = true;
            
            StartCoroutine(SpawningPlayerCharacter());
        }

        public void MovePlayerCharacter()
        {
            LogManager.LogProgress();
            
            StartCoroutine(MovingPlayerCharacter());
        }

        private IEnumerator SpawningPlayerCharacter()
        {
            var original = ResourceManager.GameObjectResource.PlayerCharacter;
            var position = _extractor.GetPosition(302);
            var rotation = original.transform.rotation;
            var clone = ObjectManager.OnSpawn<PlayerCharacter>(original, position, rotation, transform);
            clone.OnDamagePointTextChanged = _screen.DisplayPlayerCharacterDamagePoint;
            clone.OnDefensePenetratePointTextChanged = _screen.DisplayPlayerCharacterDefensePenetratePoint;
            clone.OnDefensePointTextChanged = _screen.DisplayPlayerCharacterDefensePoint;
            clone.OnSpeedPointTextChanged = _screen.DisplayPlayerCharacterSpeedPoint;
            clone.Timers[0].OnCoolingTimeStarted += _screen.SkillInformationDisplays[0].PlayCooldownStarted;
            clone.Timers[0].OnCoolingTimeStarted += _screen.SkillInformationDisplays[0].DisplaySkillDeactivated;
            clone.Timers[0].OnCoolingTimeCompleted += _screen.SkillInformationDisplays[0].PlayCooldownCompleted;
            clone.Timers[0].OnCountingDownStarted += _screen.SkillInformationDisplays[0].DisplaySkillActivated;
            clone.Timers[0].CoolingDownTimeChanged += _screen.SkillInformationDisplays[0].SetCooldownTime;
            clone.Timers[0].ProgressChanged += _screen.SkillInformationDisplays[0].SetProgress;
            clone.Timers[1].OnCoolingTimeStarted += _screen.SkillInformationDisplays[1].PlayCooldownStarted;
            clone.Timers[1].OnCoolingTimeStarted += _screen.SkillInformationDisplays[1].DisplaySkillDeactivated;
            clone.Timers[1].OnCoolingTimeCompleted += _screen.SkillInformationDisplays[1].PlayCooldownCompleted;
            clone.Timers[1].OnCountingDownStarted += _screen.SkillInformationDisplays[1].DisplaySkillActivated;
            clone.Timers[1].CoolingDownTimeChanged += _screen.SkillInformationDisplays[1].SetCooldownTime;
            clone.Timers[1].ProgressChanged += _screen.SkillInformationDisplays[1].SetProgress;
            clone.Timers[2].OnCoolingTimeStarted += _screen.SkillInformationDisplays[2].PlayCooldownStarted;
            clone.Timers[2].OnCoolingTimeStarted += _screen.SkillInformationDisplays[2].DisplaySkillDeactivated;
            clone.Timers[2].OnCoolingTimeCompleted += _screen.SkillInformationDisplays[2].PlayCooldownCompleted;
            clone.Timers[2].OnCountingDownStarted += _screen.SkillInformationDisplays[2].DisplaySkillActivated;
            clone.Timers[2].CoolingDownTimeChanged += _screen.SkillInformationDisplays[2].SetCooldownTime;
            clone.Timers[2].ProgressChanged += _screen.SkillInformationDisplays[2].SetProgress;
            clone.ClosestEnemyCharacterPosition = GetClosestEnemyCharacterPosition;
            clone.OnScoreChanged = SetChapterScore;
            clone.OnReleaseCharacter = ReleasePlayerCharacter;
            clone.gameObject.SetActive(true);
            
            _screen.DisplayPlayerCharacterLifeCount(PlayerCharacterLifeCount);
            
            PlayerCharacterCache = clone;
            
            yield return StartCoroutine(MovingPlayerCharacter());
            
            IsPlayerCharacterSpawning = false;
        }

        private IEnumerator MovingPlayerCharacter()
        {
            IsPlayerCharacterMoving = true;
            
            PlayerCharacterCache.DisablePlayerCharacterControls();
            PlayerCharacterCache.IgnoreWallCollision();
            
            PlayerCharacterCache.MoveToDestination();
            while (PlayerCharacterCache.IsMovingToDestination)
            {
                yield return _instruction;
            }
            
            PlayerCharacterCache.IgnoreWallCollision(false);
            
            IsPlayerCharacterMoving = false;
        }

        public void SpawnEnemyCharacters(StageData data)
        {
            LogManager.LogProgress();

            StartCoroutine(SpawningEnemyCharacters(data));
        }

        private IEnumerator SpawningEnemyCharacters(StageData data)
        {
            IsEnemyCharactersSpawning = true;
            
            var count = data.WaveData.Count;
            for (var i = 0; i < count; i++)
            {
                yield return StartCoroutine(SpawningEnemyCharacters(data.WaveData[i]));
            }
            
            while (SpawnedEnemyCharacterCount != 0)
            {
                yield return _instruction;
            }

            IsEnemyCharactersSpawning = false;
        }
        
        private IEnumerator SpawningEnemyCharacters(WaveData data)
        {
            var count = data.SpawnData.Count;
            var delay = new WaitForSeconds(data.Delay);
            for (var i = 0; i < count; i++)
            {
                SpawnEnemyCharacter(data.SpawnData[i]);
                
                SpawnedEnemyCharacterCount++;
                _screen.DisplayCurrentEnemyCharacterCount(SpawnedEnemyCharacterCount);
            }
                    
            yield return delay;
                
            // If the player character dies, stop spawning waves and respawn the player character.
            while (PlayerCharacterCache is null)
            {
                yield return _instruction;
            }
        }

        private void SpawnEnemyCharacter(SpawnData data)
        {
            LogManager.LogProgress();
            
            var key = data.CharacterName;
            var original = ResourceManager.GameObjectResource.EnemyCharacter[key];
            var position = _extractor.GetSpawnPosition(data.SpawnedPositionIndex);
            var rotation = original.transform.rotation;
            var clone = ObjectManager.OnSpawn<EnemyCharacter>(original, position, rotation, transform);
            clone.SpawnData = data;
            clone.OnScoreChanged = SetChapterScore;
            clone.OnRemoveRecord = RemoveEnemyCharacterRecord;
            clone.OnReleaseCharacter = ReleaseEnemyCharacter;

            var instance = clone.gameObject;
            var id = instance.GetInstanceID();
            _records.Add(id, clone);
            
            instance.SetActive(true);
        }

        /// <summary>
        /// Queue an enemy character and request a respawn.
        /// </summary>
        /// <param name="instance"> The instance of the enemy character to respawn. </param>
        public void RespawnEnemyCharacter(GameObject instance)
        {
            LogManager.LogProgress();

            StartCoroutine(RespawningEnemyCharacter(instance));
        }

        private IEnumerator RespawningEnemyCharacter(GameObject instance)
        {
            var id = instance.GetInstanceID();
            var clone = _records[id];
            _records.Remove(id);
            
            _queue.Enqueue(clone.SpawnData);
            
            ObjectManager.OnRelease(instance);

            yield return _delay;
            
            SpawnEnemyCharacter(_queue.Dequeue());
        }
        
        private void ReleasePlayerCharacter(CharacterBase character)
        {
            LogManager.LogProgress();

            StartCoroutine(ReleasingPlayerCharacter(character));
        }

        private IEnumerator ReleasingPlayerCharacter(CharacterBase character)
        {
            PlayerCharacterCache = null;
            PlayerCharacterLifeCount--;
            
            var instance = character.gameObject;
            ObjectManager.OnRelease(instance);

            foreach (var record in _records)
            {
                record.Value.SetWaitState();
            }
            
            if (PlayerCharacterLifeCount != 0)
            {
                yield return StartCoroutine(SpawningPlayerCharacter());
                
                PlayerCharacterCache?.EnablePlayerCharacterControls();
                PlayerCharacterCache?.SetWaitState();
                
                foreach (var record in _records)
                {
                    record.Value.SetLatestState();
                }
            }
            else
            {
                _screen.TurnOff();
                _failedResultScreen.Play();

                while (true)
                {
                    yield return null;
                }
            }
        }

        private void RemoveEnemyCharacterRecord(CharacterBase character)
        {
            LogManager.LogProgress();
            
            var instance = character.gameObject;
            var id = instance.GetInstanceID();
            _records.Remove(id);
        }

        private void ReleaseEnemyCharacter(CharacterBase character)
        {
            LogManager.LogProgress();
            
            SpawnedEnemyCharacterCount--;
            EnemyCharacterDeathCount++;
            
            _screen.DisplayCurrentEnemyCharacterCount(SpawnedEnemyCharacterCount);
            
            var instance = character.gameObject;
            ObjectManager.OnRelease(instance);
        }

        private void SetChapterScore(int score)
        {
            LogManager.LogProgress();

            ChapterScore += score;
            
            _screen.DisplayChapterScore(ChapterScore);
        }
        
        /// <returns>
        /// The closest enemy character that has not passed the player character.
        /// </returns>
        private Vector3? GetClosestEnemyCharacterPosition()
        {
            LogManager.LogProgress();

            var count = _records.Count;
            if (count == 0)
            {
                return null;
            }

            var list = _records.Values.ToList();
            list.Sort(_comparison);

            Vector3? position = null;
            var x = PlayerCharacterCache.HorizontalPosition;
            for (var i = 0; i < list.Count; i++)
            {
                if (list[i].HorizontalPosition <= x)
                {
                    continue;
                }
                
                position = list[i].Position;

                break;
            }
            
            return position;
        }
        
        /// <summary>
        /// Sort enemy character positions in descending order based on the player character's position.
        /// </summary>
        private int CompareEnemyCharacterPosition(IHorizontalComparable a, IHorizontalComparable b)
        {
            var u = a.HorizontalPosition;
            var v = b.HorizontalPosition;
            
            return u < v ? -1 : 1;
        }
        
        /// <returns>
        /// The number of enemy characters spawned.
        /// </returns>
        private int SpawnedEnemyCharacterCount { get; set; }
        
        public int ChapterScore { get; private set; }
        
        public PlayerCharacter PlayerCharacterCache { get; private set; }
        
        /// <summary>
        /// The number of player character lives.
        /// </summary>
        public int PlayerCharacterLifeCount { get; private set; }

        /// <summary>
        /// The number of enemy character deaths.
        /// </summary>
        public int EnemyCharacterDeathCount { get; private set; }
        
        /// <summary>
        /// True if enemy characters in stage is spawning, otherwise false.
        /// </summary>
        public bool IsEnemyCharactersSpawning { get; private set; }
        
        /// <returns>
        /// True if the player character is spawning, otherwise false.
        /// </returns>
        public bool IsPlayerCharacterSpawning { get; private set; }
        
        /// <returns>
        /// True if the player character is moving to destination, otherwise false.
        /// </returns>
        public bool IsPlayerCharacterMoving { get; private set; }

        #region DELEGATE DECLARATION
        
        public delegate Vector3? ClosestEnemyCharacterPositionCallback();

        public delegate void RemoveRecordCallback(CharacterBase character);
        public delegate void ReleaseCharacterCallback(CharacterBase character);
        
        #endregion
    }
}