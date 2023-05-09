using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Union : Enemy
{
    protected override void Start()
    {
        base.Start();
        _states = new IState[3];
        _states[(int)EnemyState.idle] = new UnionState.Idle();
        _states[(int)EnemyState.move] = new UnionState.Move();
        _states[(int)EnemyState.attack] = new UnionState.Attack();

        ChangeState((int)EnemyState.idle);
    }
}
