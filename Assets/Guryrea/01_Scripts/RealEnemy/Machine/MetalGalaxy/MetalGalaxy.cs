using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalGalaxy : Enemy
{
    protected override void Start()
    {
        base.Start();
        _states = new IState[3];

        _states[(int)EnemyState.idle] = new MetalGalaxyState.Idle();
        _states[(int)EnemyState.move] = new MetalGalaxyState.Move();
        _states[(int)EnemyState.attack] = new MetalGalaxyState.Attack();

        ChangeState((int)EnemyState.idle);
    }
}
