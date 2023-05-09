using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseKiller : Enemy
{
    protected override void Start()
    {
        base.Start();
        _states = new IState[3];
        _states[(int)EnemyState.idle] = new PoisionDragonState.Idle();
        _states[(int)EnemyState.move] = new PoisionDragonState.Move();
        _states[(int)EnemyState.attack] = new PoisionDragonState.Attack();

        ChangeState((int)EnemyState.idle);
    }
}
