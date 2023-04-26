using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using AI.Enemy;

namespace AI
{

    public class AISelectManager : MonoBehaviour
    {

        [Header("[ Read Only - Obj Pos ]")]
        [SerializeField] List<AISelectPos> BatchPosition = null;

        [SerializeField] List<AIBatch> BatchPos = null;
        [SerializeField] List<AITower> TowerPos = null;
        [SerializeField] List<AIArea> AreaPos = null;

        [Header("[ Read Only - Enemy ]")]

        [SerializeField] List<EnemyBase> ToUsing = null;     // 3�� �߷��� 1��° ���Ŀ� ���
        [SerializeField] List<EnemyBase> UseAbleList = null; // ���� �ִ°� ������ ������ ����
        [SerializeField] List<EnemyBase> UsedList = null;    // ����


        [Header("[ ScriptableObject ]")] // ������ EnemyData ������ߵ�
        [SerializeField] AIEnemyType BatchigUnit;
        [SerializeField] AIEnemyType TowerUnit;
        [SerializeField] AIEnemyType AreaUnit;

        [Header("[ ManagerStat ]")]
        [SerializeField] float _cost = 100;
        [SerializeField] float _batchSpeed = 3;
        [SerializeField] float _regenCost = 5;




        bool _batchAble = false;

        float _timer = 0.0f;


        private void Awake()
        {
            BatchPos.Clear();
            TowerPos.Clear();
            AreaPos.Clear();
            BatchPosition.Clear();

            if (BatchigUnit.Mode != AIUnitMode.Batch)
            {
                Debug.Log("�ش� Ÿ���� [AIUnitMode.Batch] Ÿ���� �ƴ�");
            }
            if (BatchigUnit.Mode != AIUnitMode.BatchTower)
            {
                Debug.Log("�ش� Ÿ���� [AIUnitMode.BatchTower] Ÿ���� �ƴ�");
            }
            if (BatchigUnit.Mode != AIUnitMode.AreaUnit)
            {
                Debug.Log("�ش� Ÿ���� [AIUnitMode.AreaUnit] Ÿ���� �ƴ�");
            }



            BatchPosition = transform.GetComponentsInChildren<AISelectPos>().ToList();

            for (int i = 0; i < BatchPosition.Count; ++i)
            {
                if (BatchPosition[i].GetComponent<AIBatch>())
                {
                    BatchPos.Add(BatchPosition[i].GetComponent<AIBatch>());
                }
                if (BatchPosition[i].GetComponent<AITower>())
                {
                    TowerPos.Add(BatchPosition[i].GetComponent<AITower>());
                }
                if (BatchPosition[i].GetComponent<AIArea>())
                {
                    AreaPos.Add(BatchPosition[i].GetComponent<AIArea>());
                }
            }


            _batchAble = true;
        }

        IEnumerator Start()
        {
            yield return new WaitUntil(() => _batchAble);




        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer > _batchSpeed)
            {
                _batchAble = true;
                _timer = 0;
            }
        }



        private void AISort()
        {
            List<AI.Enemy.Enemy> AllOfUnit = null;
            AllOfUnit.AddRange(BatchigUnit.Retruning());
            AllOfUnit.AddRange(TowerUnit.Retruning());
            AllOfUnit.AddRange(AreaUnit.Retruning());

            for (int i = AllOfUnit.Count - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (AllOfUnit[j].Object._data.Combatpower < AllOfUnit[j + 1].Object._data.Combatpower)
                    {
                        AI.Enemy.Enemy temp = AllOfUnit[j];
                        AllOfUnit[j] = AllOfUnit[j + 1];
                        AllOfUnit[j + 1] = temp;
                    }
                }
            }


        }






    }
}
