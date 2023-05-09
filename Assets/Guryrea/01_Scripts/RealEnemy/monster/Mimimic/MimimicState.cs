using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MimimicState
{
    public class MimimicState : MonoBehaviour
    {
        public int killcount = 0;



    }

    public class Attack : IState
    {
        MimimicState mimimicState = new MimimicState();
        public int killcount = 0;
        public override void OnStateEnter(Enemy _enemy)
        {
            //mimimicState.waitStart(_enemy);
            CoroutineHelper.StartCoroutine(WaitTime(_enemy));
            Debug.Log($"{GetType().ToString()} : Attack");
            // _enemy._ani.SetTrigger("Attack");
            // var target = _enemy.SetTarget()?.GetComponent<IDamage>();

            // if (target != null && !_enemy.SetTarget().GetComponent<Enemy>()._isDie)
            // {
            //     target?.IDamage(_enemy._set.Damage);
            //     if (_enemy.SetTarget().GetComponent<Enemy>()._isDie)
            //     {
            //         killcount++;

            //         foreach (Collider _co in _enemy.hit)
            //         {
            //             _co?.GetComponent<IDamage>().IDamage(10 * killcount);
            //         }
            //     }
            // }
            // _enemy.ChangeState(Enemy.EnemyState.idle);
        }

        public override void OnStateExit(Enemy _enemy)
        {

        }

        public override void OnStateUpdate(Enemy _enemy)
        {

        }

        IEnumerator WaitTime(Enemy _enemy)
        {
            _enemy._ani.SetTrigger("Attack");
            var target = _enemy.SetTarget()?.GetComponent<IDamage>();

            yield return new WaitForSeconds(0.1f);

            //!_enemy.SetTarget().GetComponent<Enemy>()._isDie
            if (target != null)
            {
                target?.IDamage(_enemy._set.Damage);
                if (_enemy.SetTarget().GetComponent<Enemy>()._isDie)
                {
                    killcount++;

                    foreach (Collider _co in _enemy.hit)
                    {
                        _co?.GetComponent<IDamage>().IDamage(10 * killcount);
                    }
                }
            }
            yield return new WaitForSeconds(0.1f);
            _enemy.ChangeState(Enemy.EnemyState.idle);
        }

    }

    public class Idle : IState
    {
        private float _lastAttack;
        public override void OnStateEnter(Enemy _enemy)
        {
            Debug.Log($"{GetType().ToString()} : idle");
            _enemy._ani.SetBool("move", false);
            _enemy.AgentStop();
        }

        public override void OnStateExit(Enemy _enemy)
        {

        }

        public override void OnStateUpdate(Enemy _enemy)
        {
            if (!_enemy.IsAttackRange())
                _enemy.ChangeState(Enemy.EnemyState.move);

            if (Time.time > _enemy._set.AttackCooltime + _lastAttack)
            {
                _lastAttack = Time.time;
                _enemy.ChangeState(Enemy.EnemyState.attack);
            }
        }
    }

    public class Move : IState
    {
        public override void OnStateEnter(Enemy _enemy)
        {
            Debug.Log($"{GetType().ToString()} : move");

            _enemy._ani.SetBool("move", true);
            _enemy.AgentGo();
        }

        public override void OnStateExit(Enemy _enemy)
        {

        }

        public override void OnStateUpdate(Enemy _enemy)
        {
            _enemy._ani.SetBool("move", true);
            _enemy.AgentGo();

            if (_enemy.IsAttackRange())
                _enemy.ChangeState(Enemy.EnemyState.idle);
        }
    }
}
