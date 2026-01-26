using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : IEnemyState
{
    private readonly Enemy _enemy;

    public EnemyChaseState(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }

    public void Update()
    {
        ChasePlayer();
        CheckForPlayer();
    }

    private void ChasePlayer()
    {
        Vector3 playerPosition = _enemy.Player.position;
        _enemy.MoveTowardsTarget(playerPosition);
    }
    private void CheckForPlayer()
    {
        float distance = Vector2.Distance(
            _enemy.transform.position,
            _enemy.Player.position);

        if (distance <= _enemy.Config.AttackRadius)
        {
            _enemy.ChangeState(new EnemyAttackState(_enemy));
            return;
        }

        if (distance > _enemy.Config.ChaseRadius)
        {
            _enemy.ChangeState(new EnemyIdleState(_enemy));
            return;
        }
    }
}
