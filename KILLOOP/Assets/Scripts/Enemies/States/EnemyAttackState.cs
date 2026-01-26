using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : IEnemyState
{
    private readonly Enemy _enemy;
    private float _cooldown;

    public EnemyAttackState(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void Enter()
    {
        _cooldown = 0f;
    }

    public void Update()
    {
        float distance = Vector2.Distance(
            _enemy.transform.position,
            _enemy.Player.position);

        if (distance > _enemy.Config.AttackRadius)
        {
            _enemy.ChangeState(new EnemyChaseState(_enemy));
            return;
        }

        _cooldown -= Time.deltaTime;
        if (_cooldown <= 0f)
        {
            Attack();
            _cooldown = _enemy.Config.AttackCooldown;
        }
    }

    private void Attack()
    {
        // spawn hitbox / deal damage
    }

    public void Exit() { }
}
