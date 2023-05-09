using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GVirus : Enemy
{
    protected override void Start()
    {
        base.Start();
        _states = new IState[3];
        _states[(int)EnemyState.idle] = new GVirusState.Idle();
        _states[(int)EnemyState.move] = new GVirusState.Move();
        _states[(int)EnemyState.attack] = new GVirusState.Attack();

        ChangeState((int)EnemyState.idle);
    }
}
