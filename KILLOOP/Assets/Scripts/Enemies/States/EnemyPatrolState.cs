using UnityEngine;

public class EnemyPatrolState : IEnemyState
{
    private readonly Enemy _enemy;

    public EnemyPatrolState(Enemy enemy)
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
        PatrolMovement();
        CheckForPlayer();
    }

    private void PatrolMovement()
    {
        Transform targetPoint = _enemy.CurrentPatrolPoint;

        _enemy.MoveTowards(targetPoint.position);

        float distance = Vector2.Distance(
            _enemy.transform.position,
            targetPoint.position);

        if (distance <= _enemy.Config.PointReachDistance)
        {
            _enemy.SwitchToNextPatrolPoint();
            _enemy.ChangeState(new EnemyIdleState(_enemy));
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
