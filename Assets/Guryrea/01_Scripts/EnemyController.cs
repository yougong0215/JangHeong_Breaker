using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    enum State
    {
        idle,
        move,
        attack
    };
    // 적군이 이동할 목표물인 성
    [SerializeField] private Transform _castle;
    // 적군의 기본 정보
    [SerializeField] private EnemyBase _base;
    // 공격 가능한 대상을 판별하기 위한 레이어 마스크
    private float _curHP;
    private NavMeshAgent _Agent;

    // 충돌한 대상을 저장할 배열
    private Collider[] hit;
    // 현재 공격 대상
    private Transform _attackTarget;
    // 마지막 공격 시간
    private float _lastTime;

    State _state;

    private void Awake()
    {
        _curHP = _base._data.MaxHp;
        _base.Init();
        _state = State.move;
    }


    private void FixedUpdate()
    {

        // 공격 가능한 범위 내에 있고, 공격 쿨타임이 지났을 경우
        if (IsAttackRange() && Time.time > _lastTime + _base._data.AttackCooltime && _state == State.move)
        {
            _base.Stop();
            //Debug.Log("Aack!!!!");
            // 현재 시간을 마지막 공격 시간으로 저장
            _lastTime = Time.time;
            // 가장 가까운 대상을 공격
            _base.Attack(SetTarget());
            StartCoroutine(ChangeToMove());
        }

        if (_state == State.move)
            _base.Move(_castle);
    }

    // 공격 가능한 범위 내에 있는지 판별하는 함수
    private bool IsAttackRange()
    {
        // 현재 위치에서 공격 가능한 범위 내에 있는 대상들을 저장
        hit = Physics.OverlapSphere(transform.position, _base._data.Range, _base._data._enemyLay);
        // 대상이 없을 경우 true 반환
        return hit.Length > 0;
    }

    // 가장 가까운 대상을 찾아 반환하는 함수
    private Transform SetTarget()
    {
        Transform target = null;
        float minDistance = Mathf.Infinity;
        for (int i = 0; i < hit.Length; i++)
        {
            // 현재 위치와 대상의 거리 계산
            float distance = Vector2.Distance(transform.position, hit[i].transform.position);
            // 가장 가까운 대상을 찾음
            if (distance < minDistance)
            {
                minDistance = distance;
                target = hit[i].transform;
            }
        }
        // 가장 가까운 대상 반환
        return target;
    }

    IEnumerator ChangeToMove()
    {
        _state = State.attack;
        yield return new WaitForSeconds(1f);
        _state = State.move;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, _base._data.Range);
    }

}
