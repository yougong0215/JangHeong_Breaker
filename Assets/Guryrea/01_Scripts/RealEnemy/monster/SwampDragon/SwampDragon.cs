using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwampDragon : Enemy
{
  

    protected override void Start()
    {
        base.Start();
        _states = new IState[3];
        _states[(int)EnemyState.idle] = new SwampDragonState.Idle();
        _states[(int)EnemyState.move] = new SwampDragonState.Move();
        _states[(int)EnemyState.attack] = new SwampDragonState.Attack();

        ChangeState((int)EnemyState.idle);
    }
}
