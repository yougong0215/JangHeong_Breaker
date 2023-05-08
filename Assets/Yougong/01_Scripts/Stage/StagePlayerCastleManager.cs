using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePlayerCastleManager : MonoBehaviour, IDamage
{
    [SerializeField] int HP;


    private void OnEnable()
    {
        
    }

    public void IDamage(float Damage)
    {
        throw new System.NotImplementedException();
    }
}
