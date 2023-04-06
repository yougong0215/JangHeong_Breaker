using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : EnemyBase
{

    public override void Init()
    {
        _data.Damage = 5f;
        _data.MaxHp = 50f;
        _data.MaxHp = 5f;
        _data.Range = 15f;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Attack()
    {
        Debug.Log("Attack");
    }
}
