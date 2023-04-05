using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum UnitType
{
    Human = 1,
    Machine = 2,
    Monste = 3
}

enum AIUnitType
{
    Batch = 0,
    AreaUnit = 1,
    BatchTower = 2,
    NotSelect
}

public abstract class AISelectPos : MonoBehaviour
{
    [SerializeField] AIUnitType Type;

}
