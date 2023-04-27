using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthDragon : Enemy
{

    protected override void Start()
    {
        base.Start();
        _states = new IState[3];

        _states[(int)EnemyState.idle] = new EarthDragonState.Idle();
        _states[(int)EnemyState.move] = new EarthDragonState.Move();
        _states[(int)EnemyState.attack] = new EarthDragonState.Attack();

        ChangeState((int)EnemyState.idle);
    }

}
