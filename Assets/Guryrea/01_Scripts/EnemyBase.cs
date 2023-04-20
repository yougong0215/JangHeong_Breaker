using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public abstract class EnemyBase : MonoBehaviour
{
    public EnemySetting _data;
    private NavMeshAgent _Agent;

    private void Awake()
    {
        _Agent = GetComponent<NavMeshAgent>();
    }

    public virtual void Move(Transform target)
    {
        _Agent.SetDestination(target.position);
    }
    public virtual void Stop()
    {
        _Agent.SetDestination(transform.position);
    }

    public virtual void Init()
    {
        //_Agent.speed = _data.Speed;
    }
    public abstract void Attack(Transform target);

    public abstract void Die();
}
