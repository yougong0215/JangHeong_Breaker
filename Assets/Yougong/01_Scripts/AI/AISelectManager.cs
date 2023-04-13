using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using AI.Enemy;

namespace AI
{

    public class AISelectManager : MonoBehaviour
    {

        [Header("[ Read Only ]")]
        [SerializeField] List<AISelectPos> BatchPosition = null;

        [SerializeField] List<AIBatch> BatchPos = null;
        [SerializeField] List<AITower> TowerPos = null;
        [SerializeField] List<AIArea> AreaPos = null;

        [Header("[ ScriptableObject ]")]
        [SerializeField] AIEnemyType BatchigUnit;
        [SerializeField] AIEnemyType TowerUnit;
        [SerializeField] AIEnemyType AreaUnit;

        [Header("[ ManagerStat ]")]
        [SerializeField] float _cost = 100;
        [SerializeField] float _batchSpeed = 3;
        [SerializeField] float _regenCost = 5;


        bool _batchingAble = true;

        float _timer;

        IEnumerator Start()
        {

            yield return new WaitUntil(() => _batchingAble);

            
        }

        private void Awake()
        {
            BatchPos.Clear();
            TowerPos.Clear();
            AreaPos.Clear();
            BatchPosition.Clear();

            if(BatchigUnit.Mode != AIUnitMode.Batch)
            {
                Debug.Log("해당 타입은 [AIUnitMode.Batch] 타입이 아님");
            }
            if (BatchigUnit.Mode != AIUnitMode.BatchTower)
            {
                Debug.Log("해당 타입은 [AIUnitMode.BatchTower] 타입이 아님");
            }
            if (BatchigUnit.Mode != AIUnitMode.AreaUnit)
            {
                Debug.Log("해당 타입은 [AIUnitMode.AreaUnit] 타입이 아님");
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
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if(_timer > _batchSpeed)
            {
                _batchingAble = true;
            }

            if(Input.GetKeyDown(KeyCode.K))
            {
                GameObject obj = Instantiate( BatchigUnit._listOfEnemy[0].Object.gameObject);
                BatchPos[0].Batching(obj);
                BatchigUnit._listOfEnemy[0].count--;
            }
        }


    }
}
