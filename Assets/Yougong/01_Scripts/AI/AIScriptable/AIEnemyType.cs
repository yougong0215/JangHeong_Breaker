using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum UnitType
{
    Human = 1,
    Machine = 2,
    Monste = 3
}

namespace AI
{
    namespace Enemy
    {
        [CreateAssetMenu(fileName = "StageEnemyScriptable", menuName = "AIEnemy/EnemyList")]
        public class AIEnemyType : ScriptableObject
        {
            [SerializeField] UnitType _unit;
                

        }
    }

}