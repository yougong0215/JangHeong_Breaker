using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour, IDamage
{
    

    [SerializeField] public StageSO StageData = null;
    [SerializeField] public int PaseCount = 0;

    [Header("INFO")]
    [SerializeField] float HP;
    float MaxHP;

   





    public void IDamage(float Damage)
    {
        HP -= Damage;
        // 10000
        // 3000

        // 3/10 * 100 => 30%
    }

    private void Awake()
    {
        MaxHP = HP;

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

    void SommonStart()
    {

        for (int j = 0; j < StageData.Game[PaseCount].Line.Count; j++)
        {
            for (int k = 0; k < StageData.Game[PaseCount].Line[j].Enemy.Count; k++)
            {
                StartCoroutine(Sommon(StageData.Game[PaseCount].Line[j].Enemy[k], true));
            }
        }
        PaseCount++;
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
