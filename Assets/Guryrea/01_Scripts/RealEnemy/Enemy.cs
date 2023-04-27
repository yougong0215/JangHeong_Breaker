using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour, IDamage
{
    public enum EnemyState
    {
        idle,
        move,
        attack
    };

    private float _currentHP;
    public Transform _target;
    public Collider[] hit;
    public EnemySetting _set;


    [HideInInspector] public Animator _ani;
    [HideInInspector] public NavMeshAgent _agent;


    //public StateMachine _stateMachine;
    [HideInInspector]
    public EnemyState _state;
    public IState[] _states;
    private IState currentState;


    protected virtual void Awake()
    {
        _currentHP = _set.MaxHp;
        _ani = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _target = GameObject.Find("Castle").transform;
        //currentState = _states[(int)EnemyState.idle];
    }

    protected virtual void Start()
    {
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.OnStateUpdate(this);
        }
    }


    public void ChangeState(EnemyState newState)
    {
        if (_states[(int)newState] == null) return;

        if (currentState != null)
        {
            currentState.OnStateExit(this);
        }

        currentState = _states[(int)newState];
        currentState.OnStateEnter(this);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, _set.Range);
    }

    public void IDamage(float Damage)
    {
        _currentHP -= Damage;
    }

    public bool IsAttackRange()
    {
        // 현재 위치에서 공격 가능한 범위 내에 있는 대상들을 저장
        hit = Physics.OverlapSphere(transform.position, _set.Range, _set._enemyLay);
        // 대상이 없을 경우 true 반환
        return hit.Length > 0;
    }

    public Transform SetTarget()
    {
        Transform target = null;
        float minDistance = Mathf.Infinity;
        for (int i = 0; i < hit.Length; i++)
        {
            // 현재 위치와 대상의 거리 계산
            float distance = Vector2.Distance(transform.position, hit[i].transform.position);
            // 가장 가까운 대상을 찾음
            if (distance < minDistance)
            {
                minDistance = distance;
                target = hit[i].transform;
            }
        }
        // 가장 가까운 대상 반환
        return target;
    }

    public void AgentStop()
    {
        _agent.SetDestination(transform.position);
    }

    public void AgentGo()
    {
        _agent.SetDestination(_target.position);
    }

    public void LookEnemy(Transform target)
    {
        transform.LookAt(target, Vector3.up);
    }
}
