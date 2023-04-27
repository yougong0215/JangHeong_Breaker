using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    

    [SerializeField] public StageSO StageData = null;
    [SerializeField] public int PaseCount = 0;

    private void Awake()
    {
        for(int i =0; i < StageData.Game.Count; i++)
        {
            for (int j = 0; j < StageData.Game[i].Line.Count; j++)
            {
                for (int k = 0; k < StageData.Game[i].Line[j].Enemy.Count; k++)
                {
                    PoolManager.Instance.CreatePool(StageData.Game[i].Line[j].Enemy[k].Object, 5);
                }
            }
        }
    }

    IEnumerator Sommon(EnemyData obj, bool SommonBool = false)
    {
        if(SommonBool == true)
        {
            yield return new WaitForSeconds(obj.FirstTime);
        }
        else
        {
            yield return new WaitForSeconds(obj.reviveTime);
        }

        obj.sommonCount--;
        if (obj.sommonCount >= 0)
        {
            PoolManager.Instance.Pop(obj.Object.gameObject.name);
            StartCoroutine(Sommon(obj));
        }
    }

}       
