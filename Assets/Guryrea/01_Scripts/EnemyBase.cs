using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public struct Data
{
    public float MaxHp;
    public float Speed;
    public float Damage;
    public float Range;

}

public abstract class EnemyBase : MonoBehaviour
{
    public Data _data;
    public NavMeshAgent _Agent;



    public virtual void Move(Transform target)
    {
        _Agent.SetDestination(target.position);
    }

    public abstract void Init();
    public abstract void Attack();
}
