using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimimic : Enemy
{

    protected override void Awake()
    {
        base.Awake();
        _states = new IState[3];
        _states[(int)EnemyState.idle] = new MimimicState.Idle();
        _states[(int)EnemyState.move] = new MimimicState.Move();
        _states[(int)EnemyState.attack] = new MimimicState.Attack();

        ChangeState((int)EnemyState.idle);
    }
}
