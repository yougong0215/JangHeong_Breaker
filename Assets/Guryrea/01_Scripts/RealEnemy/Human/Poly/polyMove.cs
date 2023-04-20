using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polyMove : Enemy, IState
{
    public void OnStateEnter()
    {
        _agent.SetDestination(_target.position);
    }

    public void OnStateExit()
    {

    }

    public void OnStateUpdate()
    {
        if (IsAttackRange())
        {
            _stateMachine.SetState(dicState[EnemyState.idle]);
        }
    }


}
