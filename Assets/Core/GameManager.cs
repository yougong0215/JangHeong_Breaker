using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private PlayerSelectedUnitList _psludList;

    public PlayerSelectedUnitList UnitSelectList => _psludList;

    private void Awake()
    {
        if(GameManager.Instance)
        {
            Destroy(this.gameObject);
        }


        _psludList = gameObject.AddComponent<PlayerSelectedUnitList>();
        
    }

    

}
