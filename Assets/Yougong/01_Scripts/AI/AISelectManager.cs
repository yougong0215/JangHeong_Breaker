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

        [SerializeField] List<EnemyBase> ToUsing = null;     // 3개 추려서 1번째 정렬에 사용
        [SerializeField] List<EnemyBase> UseAbleList = null; // 쓸수 있는거 전투력 순으로 정렬
        [SerializeField] List<EnemyBase> UsedList = null;    // 쓴거
        

        [Header("[ ScriptableObject ]")] // 예네의 EnemyData 추출행야됨
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


            _batchAble = true;
        }

        IEnumerator Start()
        {
            yield return new WaitUntil(() => _batchAble);

            


        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if(_timer > _batchSpeed)
            {
                _batchAble = true;
                _timer = 0;
            }
        }

        // 뱅가드 먼저 < = 마나 수급
        // 스나이퍼    < = 주로 윗쪽 배치
        // 마법사      < = 주로 윗쪽 배치
        // 디팬더      < = ㅈㄴ 탱커임
        // 가더        < = 데미지 높은 딜러
        // 스페셜리스트 < = 맵기믹 이용하는 친구
        // 서폿        < = 버프 디버프



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
