using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AI
{
    namespace Enemy
    {
        [System.Serializable]
        public class Enemy
        {
            [SerializeField] public EnemyBase Object;
            [SerializeField] public int count = 0;
        }


        [CreateAssetMenu(fileName = "StageEnemyScriptable", menuName = "AIEnemy/EnemyList")]
        public class AIEnemyType : ScriptableObject
        {
            [System.NonSerialized] public UnitType _unit;
            [SerializeField] public AIUnitMode Mode;

            [SerializeField] public List<Enemy> _listOfEnemy = null;

        }
    }

}