using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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