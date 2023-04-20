using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IState
{
    public abstract void OnStateEnter(Enemy _enemy);
    public abstract void OnStateUpdate(Enemy _enemy);
    public abstract void OnStateExit(Enemy _enemy);
}
