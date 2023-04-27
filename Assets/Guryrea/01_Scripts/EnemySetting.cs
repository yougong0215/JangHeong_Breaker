using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO/EnemySetting", menuName = "Stage")]
public class EnemySetting : ScriptableObject
{
    public LayerMask _enemyLay;
    public float MaxHp;
    public float Ammor;
    public float Speed;
    public float Damage;
    public float AttackCooltime;
    public float Range;
    public float Cost;

    [Space]
    [Header("전투력")]
    public float Combatpower;
}
