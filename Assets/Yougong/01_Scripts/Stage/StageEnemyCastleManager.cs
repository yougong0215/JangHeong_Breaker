using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEnemyCastleManager : MonoBehaviour, IDamage
{
    

    [SerializeField] public StageSO StageData = null;
    [SerializeField] public int PaseCount = 0;

    [Header("INFO")]
    [SerializeField] float HP;
    [SerializeField] public List<int> PasePerCent = null;
    [SerializeField] LayerMask Enemy;
    float MaxHP;
    

   





    public void IDamage(float Damage)
    {
        HP -= Damage;
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
                    PoolManager.Instance.CreatePool(StageData.Game[i].Line[j].Enemy[k].Object, 5, true);
                }
            }
        }

        SommonStart();
    }



    private void Update()
    {
        if(((float)HP/(float)MaxHP) * 100 <= PasePerCent[PaseCount-1])
        {
            SommonStart();
        }
    }

    void SommonStart()
    {
        StopAllCoroutines();
        
        for (int j = 0; j < StageData.Game[PaseCount].Line.Count; j++)
        {
            StageData.Game[PaseCount].Line[j].SommonPos = gameObject.transform.GetChild(j);
            for (int k = 0; k < StageData.Game[PaseCount].Line[j].Enemy.Count; k++)
            {
                StartCoroutine(Sommon(StageData.Game[PaseCount].Line[j].Enemy[k], StageData.Game[PaseCount].Line[j].SommonPos, true));
            }
        }
        PaseCount++;
    }

    IEnumerator Sommon(EnemyData obj, Transform pos, bool SommonBool = false)
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
            GameObject objected = PoolManager.Instance.Pop(obj.Object.gameObject.name).gameObject;

            objected.gameObject.layer = Enemy;

            objected.transform.position = pos.position;
            StartCoroutine(Sommon(obj, pos));
        }
    }

}       
