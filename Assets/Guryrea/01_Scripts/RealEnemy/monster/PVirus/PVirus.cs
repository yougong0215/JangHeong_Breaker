using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PVirus : Enemy
{
    protected override void Start()
    {
        base.Start();
        _states = new IState[3];
        _states[(int)EnemyState.idle] = new PVirusState.Idle();
        _states[(int)EnemyState.move] = new PVirusState.Move();
        _states[(int)EnemyState.attack] = new PVirusState.Attack();

        ChangeState((int)EnemyState.idle);
    }
}
