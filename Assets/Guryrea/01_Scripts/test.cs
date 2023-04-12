using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : EnemyBase
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform ShotPos;
    public override void Init()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Attack(Transform target)
    {
        gameObject.transform.LookAt(target);
        var bulletOBJ = Instantiate(bullet, ShotPos.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * 3f;
        Debug.Log("Attack!");
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }
}
