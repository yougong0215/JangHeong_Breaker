using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MonsterType
{
    Jako,
    Named,
    Boss,
    God,
    JangHawon
}


[System.Serializable]
public class EnemyData
{
    [Header("Object")]
    public PoolAble Object;
    [Header("Type")]
    public MonsterType Type;
    [Header("Revive")]
    public float reviveTime;
    [Header("SommonTime")]
    public int FirstTime;
    [Header("SommonArr")]
    public int sommonCount; 
    
    
}

[System.Serializable]
public class LineData
{
    public List<EnemyData> Enemy = null;
}

[System.Serializable]
public class Pase
{
    public List<LineData> Line = null;
}


[CreateAssetMenu (fileName = "SO/StageData")]
public class StageSO : ScriptableObject
{
    public List<Pase> Game = null;
}
