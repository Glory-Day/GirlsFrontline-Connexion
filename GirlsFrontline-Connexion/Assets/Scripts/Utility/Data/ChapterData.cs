using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utility.Data
{
    [CreateAssetMenu(fileName = "Chapter Data", 
                     menuName = "Scriptable Object/Data/Chapter Data")]
    public class ChapterData : ScriptableObject
    {
        [SerializeField] private StageData[] stageData = new StageData[5];
        [SerializeField] private StageData bossStageData;

        public StageData[] StageData => stageData;

        public StageData BossStageData => bossStageData;
    }

    #region SERIALIZABLE CLASS API

    [Serializable]
    public class SpawnData
    {
        [SerializeField] private string characterName;
        [SerializeField] private string destinationIndex;
        [SerializeField] private int spawnedPositionIndex;

        public string CharacterName 
        { 
            get => characterName;
            set => characterName = value;
        }
        
        public int? DestinationIndex
        {
            get
            {
                if (destinationIndex == string.Empty)
                {
                    return null;
                }
                
                return int.Parse(destinationIndex);
            }
            set => destinationIndex = value.ToString();
        }

        public int SpawnedPositionIndex => spawnedPositionIndex;
    }

    [Serializable]
    public class WaveData
    {
        [SerializeField] private float delay;
        [SerializeField] private List<SpawnData> spawnData = new List<SpawnData>();

        public float Delay => delay;
        
        public List<SpawnData> SpawnData => spawnData;
    }
        
    [Serializable]
    public class StageData
    {
        [SerializeField] private List<WaveData> waveData = new List<WaveData>();

        public List<WaveData> WaveData => waveData;
    }

    #endregion
}
