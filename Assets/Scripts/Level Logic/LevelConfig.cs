using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class LevelConfig : ScriptableObject
{
    public string LevelName;
    public float MaxRopeLength;
    public Level Level;
    public LevelConfig NextLevel;
    public Rope RopePrefab;

    public int LevelNumber { get; set; }

    public void Init(LevelConfig levelConfig)
    {
        LevelName = levelConfig.LevelName;
        MaxRopeLength = levelConfig.MaxRopeLength;
        Level = levelConfig.Level;
        NextLevel = levelConfig.NextLevel;
        RopePrefab = levelConfig.RopePrefab;
        LevelNumber = levelConfig.LevelNumber;
    }

}
