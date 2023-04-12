using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : EnemyBase
{
    [SerializeField] private Transform tankGunPOS;
    [SerializeField] private GameObject _bulletOBJ;
    public override void Attack(Transform target)
    {
        gameObject.transform.LookAt(tankGunPOS.transform);
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
