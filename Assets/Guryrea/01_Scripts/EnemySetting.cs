using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EnemySetting
{
    public LayerMask _enemyLay;
    public float MaxHp;
    public float Speed;
    public float Damage;
    public float AttackCooltime;
    public float Range;
    public float Cost;
}
