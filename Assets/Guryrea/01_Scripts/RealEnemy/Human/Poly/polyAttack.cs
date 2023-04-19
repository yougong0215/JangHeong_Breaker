using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polyAttack : Enemy, IState
{

    public void OnStateEnter()
    {
        StartCoroutine(AttackCorutine());
    }

    public void OnStateExit()
    {

    }

    public void OnStateUpdate()
    {

    }

    IEnumerator AttackCorutine()
    {
        _ani.SetTrigger("Attack");
        yield return new WaitForSeconds(_set.AttackCooltime);
        _stateMachine.SetState(dicState[EnemyState.idle]);
    }

}
