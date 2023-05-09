using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Migic : Enemy
{
    protected override void Start()
    {
        base.Start();
        _states = new IState[3];
        _states[(int)EnemyState.idle] = new MigicState.Idle();
        _states[(int)EnemyState.move] = new MigicState.Move();
        _states[(int)EnemyState.attack] = new MigicState.Attack();

        ChangeState((int)EnemyState.idle);
    }
}
