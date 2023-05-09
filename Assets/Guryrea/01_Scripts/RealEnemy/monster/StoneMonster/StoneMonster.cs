using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMonster : Enemy
{
    protected override void Start()
    {
        base.Start();
        _states = new IState[3];
        _states[(int)EnemyState.idle] = new StoneMonsterState.Idle();
        _states[(int)EnemyState.move] = new StoneMonsterState.Move();
        _states[(int)EnemyState.attack] = new StoneMonsterState.Attack();

        ChangeState((int)EnemyState.idle);
    }
}
