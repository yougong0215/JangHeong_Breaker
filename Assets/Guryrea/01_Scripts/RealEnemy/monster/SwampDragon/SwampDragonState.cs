using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwampDragonState
{
    public class Attack : IState
    {
        public override void OnStateEnter(Enemy _enemy)
        {
            Debug.Log($"{GetType().ToString()} : Attack");
            //_enemy._ani.SetTrigger("Attack");
            var target = _enemy.SetTarget().GetComponent<IDamage>();

            if (target != null)
            {
                target.IDamage(_enemy._set.Damage);
            }
            _enemy.ChangeState(Enemy.EnemyState.idle);
        }

        public override void OnStateExit(Enemy _enemy)
        {

        }

        public override void OnStateUpdate(Enemy _enemy)
        {

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
            if (_enemy.IsAttackRange())
                _enemy.ChangeState(Enemy.EnemyState.idle);
        }
    }
}