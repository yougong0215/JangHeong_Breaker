using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "SO/PlayerSelectUnitList")]


public class PlayerSelectedUnitList : MonoBehaviour
{
    [SerializeField] List<GameObject> UnitList = new List<GameObject>();

    private void Awake()
    {
        for(int i =0; i < 5; i++)
        {
            UnitList.Add(null);
        }
    }


   public void AddUnits(GameObject obj, int i)
   {
        UnitList[i] = obj;
   }


}
