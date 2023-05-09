using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mummy : Enemy
{
    protected override void Start()
    {
        base.Start();
        _states = new IState[3];

        _states[(int)EnemyState.idle] = new MymmyState.Idle();
        _states[(int)EnemyState.move] = new MymmyState.Move();
        _states[(int)EnemyState.attack] = new MymmyState.Attack();

        ChangeState((int)EnemyState.idle);
    }
}
