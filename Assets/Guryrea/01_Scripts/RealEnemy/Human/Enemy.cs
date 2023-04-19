using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    protected enum EnemyState
    {
        idle,
        move,
        attack
    };
    [SerializeField] protected EnemySetting _set;

    protected EnemyState _state;
    protected StateMachine _stateMachine;
    protected Animator _ani;
    protected NavMeshAgent _agent;
    protected Dictionary<EnemyState, IState> dicState = new Dictionary<EnemyState, IState>();

    private void Awake()
    {
        _ani = GetComponent<Animator>();
        IState attack = new polyAttack();
        IState idle = new polyIdle();

        // IState run = new StateRun();
        // IState sliding = new StateSliding();
        // IState jump = new StateJump();
        // IState dead = new StateDead();

        // //키입력 등에 따라서 언제나 상태를 꺼내 쓸 수 있게 딕셔너리에 보관
        dicState.Add(EnemyState.attack, attack);
        dicState.Add(EnemyState.idle, idle);

        // dicState.Add(PlayerState.Run, run);
        // dicState.Add(PlayerState.Sliding, sliding);
        // dicState.Add(PlayerState.Jump, jump);
        // dicState.Add(PlayerState.Dead, dead);

        //기본상태는 달리기로 설정.
        //_stateMachine = new StateMachine();
    }

    private void Update()
    {
        _stateMachine.DoOperateUpdate();
    }
}
