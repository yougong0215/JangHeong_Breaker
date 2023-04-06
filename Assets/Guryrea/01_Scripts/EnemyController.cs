using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemyBase _base;
    [SerializeField] LayerMask _lay;

    private Collider[] hit;
    private Transform _target;
    void Awake()
    {
        _base.Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private bool IsAttackRange()
    {

        hit = Physics.OverlapSphere(transform.position, _base._data.Range, _lay);
        if (hit.Length <= 0)
            return true;

        // if (Physics.CheckSphere(transform.position, _base._data.Range, _lay))
        // {
        //     return true;
        // }
        return false;
    }

    float temp;
    private void Think()
    {
        for (int i = 0; i < hit.Length; i++)
        {
            if (Vector2.Distance(transform.position, hit[i].transform.position) < Vector2.Distance(transform.position, _target.position) && IsAttackRange())
            {
                _target = hit[i].transform;
                _base.Move(_target);
            }
        }
    }
}
