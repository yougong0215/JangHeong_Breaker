using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace AI
{

    public class AISelectManager : MonoBehaviour
    {
        [SerializeField] List<AISelectPos> BatchPosition = null;

        [SerializeField] List<GameObject> Batch = null;
        [SerializeField] List<GameObject> Tower = null;
        [SerializeField] List<GameObject> Area = null;

        private void Awake()
        {
            Batch.Clear();
            Tower.Clear();
            Area.Clear();
            BatchPosition.Clear();


            BatchPosition = transform.GetComponentsInChildren<AISelectPos>().ToList();

            for (int i = 0; i < BatchPosition.Count; ++i)
            {
                if (BatchPosition[i].GetComponent<AIBatch>())
                {
                    Batch.Add(BatchPosition[i].gameObject);
                }
                if (BatchPosition[i].GetComponent<AITower>())
                {
                    Tower.Add(BatchPosition[i].gameObject);
                }
                if (BatchPosition[i].GetComponent<AIArea>())
                {
                    Area.Add(BatchPosition[i].gameObject);
                }
            }
        }




    }
}
