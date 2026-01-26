using UnityEngine;

public class EnemyIdleState : IEnemyState
{
    private readonly Enemy _enemy;
    private float _idleDuration;

    public EnemyIdleState(Enemy enemy)
    {
        _enemy = enemy;
    }
    public void Enter()
    {
        _idleDuration = _enemy.Config.IdleDuration;

    }

    public void Exit()
    {
    }

    public void Update()
    {
        CheckForPlayer();

        if(_idleDuration<=0f)
        {
            _enemy.ChangeState(new EnemyPatrolState(_enemy));
        }
        else
        {
            _idleDuration -= Time.deltaTime;
        }
    }
    private void CheckForPlayer()
    {
        float distanceToPlayer = Vector2.Distance(
            _enemy.transform.position,
            _enemy.Player.position);

        if (distanceToPlayer <= _enemy.Config.ChaseRadius)
        {
            _enemy.ChangeState(new EnemyChaseState(_enemy));
        }
    }
}
