using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EnemySetting")]
public class EnemySetting : ScriptableObject
{
    public UnitType unitType;
    public LayerMask _enemyLay;
    public float MaxHp;
    public float Ammor;
    public float Speed;
    public float Combatpower;
    public float Damage;
    public float AttackCooltime;
    public float Range;
    public float Cost;
}
