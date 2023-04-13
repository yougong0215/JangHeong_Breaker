using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : EnemyBase
{
    [SerializeField] private Transform _likeDick;
    [SerializeField] private Transform _tankGunPOS;
    [SerializeField] private GameObject _bulletOBJ;
    public override void Attack(Transform target)
    {
        _likeDick.gameObject.transform.LookAt(target);
        var bullet = Instantiate(_bulletOBJ, _tankGunPOS.position, Quaternion.identity);
        bullet.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward, ForceMode.Impulse);
    }

    public override void Die()
    {
        throw new System.NotImplementedException();
    }


}
