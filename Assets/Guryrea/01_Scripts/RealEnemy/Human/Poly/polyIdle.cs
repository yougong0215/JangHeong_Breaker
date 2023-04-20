using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polyIdle : Enemy, IState
{
    public void OnStateEnter()
    {

    }

    public void OnStateExit()
    {
    }

    public void OnStateUpdate()
    {
        if (_state != EnemyState.attack)
        {
            _stateMachine.SetState(dicState[EnemyState.attack]);
        }

        if (!IsAttackRange())
        {
            _stateMachine.SetState(dicState[EnemyState.move]);
        }
    }
}
