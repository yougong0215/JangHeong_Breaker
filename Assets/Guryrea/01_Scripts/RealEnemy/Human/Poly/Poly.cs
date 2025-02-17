using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Poly : Enemy
{
    protected override void Start()
    {
        base.Start();
        _states = new IState[3];
        _states[(int)EnemyState.idle] = new PolyState.Idle();
        _states[(int)EnemyState.move] = new PolyState.Move();
        _states[(int)EnemyState.attack] = new PolyState.Attack();

        ChangeState((int)EnemyState.idle);

    }
}
