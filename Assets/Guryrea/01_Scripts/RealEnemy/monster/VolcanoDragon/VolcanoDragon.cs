using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoDragon : Enemy
{
    protected override void Start()
    {
        base.Start();

        _states = new IState[3];

        _states[(int)EnemyState.idle] = new VolcanoDragonState.Idle();
        _states[(int)EnemyState.move] = new VolcanoDragonState.Move();
        _states[(int)EnemyState.attack] = new VolcanoDragonState.Attack();

        ChangeState((int)EnemyState.idle);
    }
}
