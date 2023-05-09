using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyRoader : Enemy
{
    protected override void Start()
    {
        base.Start();
        _states = new IState[3];
        _states[(int)EnemyState.idle] = new HeavyRoaderState.Idle();
        _states[(int)EnemyState.move] = new HeavyRoaderState.Move();
        _states[(int)EnemyState.attack] = new HeavyRoaderState.Attack();

        ChangeState((int)EnemyState.idle);
    }
}
